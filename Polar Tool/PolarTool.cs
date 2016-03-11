using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

/***********************************************************************************************************************************************************************

    Notes about this stuff:

    This is a C# .Net Windows Form application.  It is currently using .net version 4.6.  It should run on anything newer than 4.0.  It is buld using Visual Studio 2015
    on Windows 10.  I have not tried to build it on any other platform, with any other tool.  It will probably work fine on anything after WinXP assuming you have the 
    latest .net stuff installed.  It should also compile on VS 2013, although I have not tried.  If you do try and find issues, please let me know.

    All references are in rows, cols.  This is import as it is easy to get them backwards and very hard to find if you do.
    There are three data sources that need to largely stay in sync:

    1.  The actual polar file is never modified.  The data is read from it once and stored in the list polarData.  This is cleared every time we open a new polar 
        file.
    2.  The global datatable, dt, is used to hold a copy of polarData.  The only reasone it exist is to serve as the data source the the various displays, 
        most notably the GridView display.  It is bound to the GridView by sitting the GridViews datasoure to dt.  This is deleted, if it exist, when we open
        a new polar file.
        It may be useful to access this data directly.  It does have row and column headers that are the first row and column of the polarData table.
    3.  The GridView, polarGrid, displays a copy of polarData, but is only accessed by the user adding rows, columns, or editing the data.  These changes
        should be stored in polarData and the datatble, dt, and subsequently, the gridview, polarGrid, should be rebuilt.
        The GridView can be used to access this data, but shouldn't be.
    4.  The polar chart, polarChart, is used only to display the polar diagrams and gets it data from the GridView.

    Both dt and polarData are availble through out the name space.  This was done so they don't have to be repeatedly built (slow) and there not additional copies 
    made by procedure calls (slow and memory intensive).

    Really important note.
    The .net DataGridView is row-centric.  Access is through the row attributes.  Column access is much more difficult and several methods avaiable to the row
    components are not available for the columns of this table.  This makes some since as it was designed to display data where the columns are the field names
    and the rows are the instances of data For example an employee record would have each employee shown as a row and the common field types like Name, Employee #, etc
    would be the column headings.  This is not quite the way it is used here and the columns are the wind speeds and the rows are the wind angle and each entry is 
    independent.  If there was a more generic .net grid display form, I would use it, but I have not found one yet and don't want to use a third party extension
    for this project.

    Another really important note.
    The only way I can find to actually delete the data from the a chart is to assign it's datasource as null.  Using the reset or clear functions do not seem
    to actually eliminate all the existing data.

    The numerical analysis is done by an opensource library from math.net.  The documentation is very sparse, almost non-existent, but it is fast and seems to 
    work.  There appears to be a lot of users for this.  I have validated the stuff used here, but nothing more.

    CSVT is a comma seperated values tool.  It may be included here are compiled as a DLL and a referenct added to the project.  I will release it on GitHub as soon
    as it is stable.

************************************************************************************************************************************************************************/

namespace Polar_Tool
{
    public partial class formMain : Form
    {

        //want this tool to stay in scope although it could be moved into File->Open
        CSVTools.CSVTools csvt = new CSVTools.CSVTools();

        //want this data to stay in scope
        static List<List<String>> polarData = new List<List<String>>();

        // This is the main datatable.  It is built in buildGrid.  Keep it in scope.
        static DataTable dt;

        public formMain()
        {
            InitializeComponent();
        }


        private void fileToolStrip_Click(object sender, EventArgs e)
        {

        }

        //
        // View -> Table
        //
        // shows the data table
        private void viewStripPolarTable_Click(object sender, EventArgs e)
        {
            polarChart.Hide();
            polarGridGroup.Show();
        }

        //
        // View->Chart
        //
        // shows the polar chart
        private void viewStripPolarChart_Click(object sender, EventArgs e)
        {
            polarGridGroup.Hide();
            polarChart.Show();
        }


        //
        //  File -> Save
        //
        private void fileStripSave_Click(object sender, EventArgs e)
        {
            int items;

            items = csvt.CSVWrite(polarData);
            if (items <= 0)
            {
                MessageBox.Show("No items written.");
            }
            else
            {
                MessageBox.Show(items + " items written.");
            }
        }



        //
        //  File -> Open
        //
        private void fileStripOpen_Click(object sender, EventArgs e)
        {
            String fileName;
            DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, 0);

            // this will read the CSV file into a two dimensional list called polarData.  It is declared as List<List<String>>
            polarData.Clear();
            polarData = csvt.CSVRead(out fileName);
            this.Text = "CSV Tool: " + fileName;

            // build the Grid and Polar Charts
            buildDataTable(polarData, csvt.actRows, csvt.actCols);
            buildPolar(polarData, csvt.actRows, csvt.actCols);

            //  Build the two smaller graphs with the initial values of 0,0
            buildColGraph(this, ee);
            buildRowGraph(this, ee);

            // show the Grid view by default
            polarChart.Hide();
            polarGridGroup.Show();
        }


        //
        //  File -> Exit
        //
        private void fileStripExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //
        //  this allows us to skip comments that may be in the first row of the polarData.
        //  The first valid row are the wind speeds and this is what this should be pointing to.
        //
        int firstValidRow(List<List<String>> data)
        {
            int rowstart = 0;
            int cols;

            cols = 0;
            // this should be the largest number of columns per row
            for (int i = 0; i < data.Count; i++)
            {
                if (cols < data[i].Count)
                {
                    cols = data[i].Count;
                }
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Count < cols)
                {
                    rowstart++;
                }
            }

            return rowstart;
        }

        //
        //  Build the polar chart.  This is NOT the polarGrid.  This IS the polarChart that displays circles.
        //
        private void buildPolar(List<List<String>> polarData, int rows, int cols)
        {

            int rowstart;
            int rowcount, colcount;
            double theta;
            double r;

            // get the first valid row
            rowstart = firstValidRow(polarData);

            // clear the chart - this has to be done to repopulate it with other data
            polarChart.Series.Clear();

            // declare and allocate the data series.  There is is one for each maximum col of data.
            Series[] polarSeries;
            polarSeries = new Series[cols];

            //  add data to the chart.  The data is organized by series of wind speeds.  Each data point is the angle and boat speed.
            //  the rows are at a specific wind angle, the column are the boat speed verus wind speed at that angle.  the wind speed is the firt row.
            //  the angle is the first column

            // the series are labeled by wind speed

            // go ACROSS the data picking up each row which
            for (colcount = 1; colcount < cols; colcount++)
            {
                // add a series to the polar chart.  The first row in each column is the is the wind speed.
                ////Console.WriteLine("Series added: " + polarData[0][colcount]);

                polarSeries[colcount - 1] = polarChart.Series.Add(polarData[rowstart][colcount]);
                polarSeries[colcount - 1].ChartType = SeriesChartType.Polar;

                //  Add the data points.  The series is added as an XY pair where X = the angle and Y = the boat speed
                for (rowcount = rowstart + 1; rowcount < rows; rowcount++)
                {
                    ////Console.WriteLine("Row: " + rowcount + ". Column: " + colcount + ". Data: " + polarData[rowcount][colcount]);

                    // explicitly convert the strings to double
                    theta = Convert.ToDouble(polarData[rowcount][0]);
                    try
                    {
                        r = Convert.ToDouble(polarData[rowcount][colcount]);
                        polarSeries[colcount - 1].Points.AddXY(theta, r);
                        ////Console.WriteLine("Data added: " + theta + ", " + r);
                        ////Console.WriteLine("Series Data: " + polarSeries[colcount - 1].Points[rowcount - rowstart - 1].XValue + ", " + polarSeries[colcount - 1].Points[rowcount - rowstart - 1].YValues[0]);
                    }
                    catch (Exception)
                    {
                        // if the conversion failed it is likely a trailing space or tab so ignore it
                        // note that this never happen if the csv tool is properly filtering whitespace
                    }
                }
            }
        }


        // show a column of the polarData as series fit to a spline graph
        private void btnGraphLine_Click(object sender, EventArgs e)
        {

        }

        //
        // NOTE:  This code is not currently used.  Save it though.
        //
        private void display_colGraph(object sender, EventArgs e, String btnText)
        {
            int firstrow;
            int numrows;
            int numcols;
            int displaycolumn;

            numrows = csvt.actRows;
            numcols = csvt.actCols;

            // clear the current chart
            chartColGraph.DataSource = null;
            chartColGraph.Series.Clear();

            // declare and allocate the data series.  There is is one for each maximum col of data.
            Series lineSeries;
            lineSeries = new Series();

            // Find the column name.  It should never be the first column.
            firstrow = firstValidRow(polarData);

            // default to first column
            displaycolumn = 1;

            // find column user requested
            for (int colcount = 1; colcount < numcols; colcount++)
            {
                if (polarData[firstrow][colcount] == btnText)
                {
                    displaycolumn = colcount;
                    break;
                }
            }

            // set the chart type to spline
            lineSeries = chartColGraph.Series.Add(polarData[firstrow][displaycolumn]);
            lineSeries.ChartType = SeriesChartType.Spline;

            // add data from polarData.  The first row are headings and need to be skipped.
            for (int rowcount = firstrow + 1; rowcount < numrows; rowcount++)
            {
                lineSeries.Points.AddXY(Convert.ToDouble(polarData[rowcount][displaycolumn]), Convert.ToDouble(polarData[rowcount][0]));
            }
        }



        // Find the maximum value of X in the Series that is passed.  This could be an extension to the Series class.
        private double FindMaxX(Series s)
        {
            double xmax;

            xmax = 0;
            for (int i = 0; i < s.Points.Count; i++)
            {
                if (s.Points[i].XValue > xmax)
                {
                    xmax = s.Points[i].XValue;
                }
            }
            return (xmax);
        }


        //  Find the maximum value of Y in the Series that is passed.  Could be an extension to the Series class or combined with code above.
        private double FindMaxY(Series s)
        {
            double ymax;

            ymax = 0;
            for (int i = 0; i < s.Points.Count; i++)
            {
                if (s.Points[i].YValues[0] > ymax)
                {
                    ymax = s.Points[i].YValues[0];
                }
            }
            return (ymax);
        }

        //
        // Create an independent copy of a Series.
        // Not at sure this actually works as intended.
        // This code is not currently used.
        //
        private Series DeepCopy(Series sin)
        {
            if (sin == null) { return (null); }
            Series sout = new Series();
            sout = new Series();
            ShallowCopy(sout, sin);
            return (sout);
        }


        //  Works but not currently ussed.
        private void ShallowCopy(Series sout, Series sin)
        {
            for (int i = 0; i < sin.Points.Count; i++)
            {
                sout.Points.Add();
                sout.Points[i].XValue = sin.Points[i].XValue;
                sout.Points[i].YValues = sin.Points[i].YValues;
            }

            //  identify it as a Shadow Copy.  Handing at times.
            sout.Name = "SC" + sin.Name;
        }

        //
        //  Print the contents of the Chart C
        //  This prints across, then down.
        //  It can generate a lot of data.
        //
        private void printGraph(Chart c)
        {
            for (int i = 0; i < c.Series.Count; i++)
            {
                //Console.Write("Index: " + i +" Series: " + c.Series[i].Name);
                //Console.WriteLine(" Count: " + c.Series[i].Points.Count);
                PrintSeries("Graph Data", c.Series[i]);
            }
        }

        //
        // Print the data in the series
        //
        private void PrintSeries(String caption, Series s)
        {
            //Console.WriteLine(caption + ".  Series " + s.Name);
            for (int i = 0; i < s.Points.Count; i++)
            {
                //Console.WriteLine("Point " + i + " : x=" + s.Points[i].XValue + ". y=" + s.Points[i].YValues[0]);
            }
        }

        private void buildRowGraph(object sender, DataGridViewCellEventArgs e)
        {
            // Build the Chart under the main form.  It shows the data moving along the selected row.
            // declare and allocate the data series.  There is is one for each maximum col of data.
            // e contains the column and row index for the selected cell in the DGV and needs to have 1 added to it.

            // variables used for regression analysis
            const int degree = 7;  // the degree of the polynomial.  there are degree+1 results in the result vector due to the constant term.
            double[] xarray;
            xarray = new double[polarData.Count];
            double[] yarray;
            yarray = new double[polarData.Count];
            double[] p;
            double[] r;
            int maxspeed;  // maximum speed listed in the polar chart
            int rowStart;

            //  if the column header is selected, the row index will be -1, do nothing.
            if (e.RowIndex == -1)
            {
                return;
            }

            // get the location where the data starts. This DOES NOT skip the header row, only any junk before it.
            rowStart = firstValidRow(polarData);

            // find the max speed shown in the polar data. Used to hold the estimated speeds after the regression
            // boat speeds are in the first valid row of polarData and we need the last entry.
            maxspeed = Convert.ToInt32(polarData[rowStart][polarData[rowStart].Count - 1]) + 1;

            // result array from regression
            r = new double[maxspeed];

            // define a new series for plotting the row graph
            Series rowSeries;
            rowSeries = new Series();
            rowSeries.Points.Clear();
            rowSeries.YValuesPerPoint = 1;

            // define a new series to plot the poly fit
            Series estSeries;
            estSeries = new Series();
            estSeries.Points.Clear();
            estSeries.YValuesPerPoint = 1;

            // clear the current data series
            chartRowGraph.Series.Clear();
            chartRowGraph.DataSource = null;

            // move across polarData getting the data
            // first column is wind angle so skip it.
            for (int i = 1; i < polarData[rowStart].Count; i++)
            {
                // Xarray holds the windspeed which is in the first row of polardata
                xarray[i] = Convert.ToDouble(polarData[rowStart][i]);

                // Yarray holds the boat speed from the field of polarData
                if (polarData[e.RowIndex+1][i] == null)
                {
                    polarData[e.RowIndex+1][i] = "0";
                }
                yarray[i] = Convert.ToDouble(polarData[e.RowIndex+1][i]);
                rowSeries.Points.AddXY(xarray[i], yarray[i]);
            }

            // compute the regression and build a series to display it.
            p = Fit.Polynomial(xarray, yarray, degree);

            // compute the estimated values based on the regression.
            for (int i = 0; i < maxspeed; i++)
            {
                r[i] = 0;
                for (int j = 0; j < degree + 1; j++)
                {
                    ////Console.Write("p[" + j + "] = " + p[j] + ", x[" + i + "] = " + xarray[i]);
                    r[i] += p[j] * Math.Pow(i, j);
                    ////Console.WriteLine(", r[" + i + "] = " + r[i]);
                }
                ////Console.WriteLine("r[" + i + "] = " + r[i]);
                estSeries.Points.AddXY(i, r[i]);
            }


            // Set the chart to type "Line".  Could also be a spline, but there will be discontinuities due to msoft
            // spine fitting appearing to be piecewise.
            rowSeries.ChartType = SeriesChartType.Line;
            rowSeries.Color = Color.FromName("Black");
            rowSeries.Name = "rowSeries";
            // PrintSeries("Row Series", rowSeries);

            estSeries.ChartType = SeriesChartType.Line;
            estSeries.Color = Color.FromName("Red");
            estSeries.Name = "estSeries";
            // PrintSeries("estSeries", estSeries);


            //  fix the broken .NET autorange function.
            chartRowGraph.ChartAreas[0].AxisY.Maximum = Math.Floor(FindMaxY(rowSeries) + 1.5);
            chartRowGraph.ChartAreas[0].AxisX.Minimum = 0;

            // set the line properties (yes, it really is Border...) and add the two chart series
            chartRowGraph.Series.Add(rowSeries);
            chartRowGraph.Series["rowSeries"].BorderWidth = 1;
            chartRowGraph.Series.Add(estSeries);
            chartRowGraph.Series["estSeries"].BorderDashStyle = ChartDashStyle.DashDotDot;
            chartRowGraph.Series["estSeries"].BorderWidth = 1;
        }


        private void buildColGraph(object sender, DataGridViewCellEventArgs e)
        {
            //  Build the chart on the right hand side of the data.
            //  This chart shows wind angle on the vertical axis and boat speed on the X axis.
            //  The wind angle is in the first column of the polarData while the speed is in the data fields, so we
            //  need to display one column of data based on e.ColumnIndex.

            // variables used for regression analysis
            const int degree = 7;  // the degree of the polynomial.  there are degree+1 results in the result vector due to the constant term.
            double[] xarray;
            xarray = new double[polarData.Count];
            double[] yarray;
            yarray = new double[polarData.Count];
            double[] p;
            double[] r;
            int minangle, maxangle;  // min and max wind angles

            double x, y;
            int rows, rowStart;

            // if a row header is selected, the index will be -1, do nothing.
            if (e.ColumnIndex == -1)
            {
                return;
            }

            // get the location where the data starts. This DOES NOT skip the header row, only any junk before it.
            rowStart = firstValidRow(polarData);

            // declare and allocate the data series.  There is is one for each maximum col of data.
            Series colSeries;
            colSeries = new Series();
            colSeries.Points.Clear();
            colSeries.YValuesPerPoint = 1;

            // define a new series to plot the poly fit
            Series estSeries;
            estSeries = new Series();
            estSeries.Points.Clear();
            estSeries.YValuesPerPoint = 1;

            // clear the current data series
            chartColGraph.Series.Clear();
            chartColGraph.DataSource = null;

            //  Polar data has the wind direction in column zero.
            //  The first row is the true wind speed and is skipped for this graph.
            //  The index coming from the GGV needs to have 1 added to it.
            //  The first valid row will contain wind speed and needs to be skipped.
            //Console.WriteLine("Data From ColGraph.  RS = " + rowStart + ". Count = " + polarData.Count);
            for (rows = rowStart + 1; rows < polarData.Count; rows++)
            {
                // x is the wind angle
                x = Convert.ToDouble(polarData[rows][0]);
                // y is the boat speed for a given wind angle and wind speed
                y = Convert.ToDouble(polarData[rows][e.ColumnIndex + 1]);
                colSeries.Points.AddXY(y, x);
                //Console.WriteLine("@row = " + rows + ". x = " + x + ". y = " + y);

                // x and y array are for the regression
                xarray[rows] = x;
                yarray[rows] = y;
            }

            // compute the regression and build a series to display it.
            p = Fit.Polynomial(xarray, yarray, degree);

            // find the max speed shown in the polar chart. Used to hold the estimated speeds after the regression
            maxangle = Convert.ToInt32(polarData[polarData.Count - 1][0]);
            minangle = Convert.ToInt32(polarData[rowStart + 1][0]);

            // result array from regression
            r = new double[maxangle - minangle + 1];

            // compute the estimated values based on the regression.
            // from the lowest angle included to the highest
            for (int i = minangle; i < maxangle; i++)
            {
                r[i - minangle] = 0;
                for (int j = 0; j < degree + 1; j++)
                {
                    ////Console.Write("p[" + j + "] = " + p[j] + ", x[" + i + "] = " + xarray[i]);
                    r[i - minangle] += p[j] * Math.Pow(i, j);
                    ////Console.WriteLine(", r[" + i + "] = " + r[i]);
                }
                ////Console.WriteLine("r[" + i + "] = " + r[i]);
                estSeries.Points.AddXY(r[i - minangle], i);
            }

            // make it appear as a line. Spline also works, but will have some dicontinuities as Msoft appears to be using
            // a piecewise spline rather than a Nurb.  NEXT UP - Find a decent NURB library.
            colSeries.ChartType = SeriesChartType.Line;
            colSeries.Color = Color.FromName("Black");

            estSeries.ChartType = SeriesChartType.Line;
            estSeries.Color = Color.FromName("Red");
            estSeries.Name = "estSeries";
            // PrintSeries("estSeries", estSeries);

            // this is because .NET auto range does not always work.
            chartColGraph.ChartAreas[0].AxisX.Maximum = Math.Floor(FindMaxX(colSeries) + 1.5);
            chartColGraph.ChartAreas[0].AxisX.Minimum = 0;

            chartColGraph.Series.Add(colSeries);

            chartColGraph.Series.Add(estSeries);
            chartColGraph.Series["estSeries"].BorderDashStyle = ChartDashStyle.DashDotDot;
            chartColGraph.Series["estSeries"].BorderWidth = 1;
        }


        //
        // swaps the X and Y values in the passed series
        // Note that if this series was created by a shallow copy, it will re-order the original data.  See Deep Copy.
        // Does work, but be very careful how you use it.  Not recommended for chart data unless your sure you have a deep copy.
        //
        private void SwapXY(Series s)
        {
            double tx;

            for (int i = 0; i < s.Points.Count; i++)
            {
                tx = s.Points[i].XValue;
                s.Points[i].XValue = s.Points[i].YValues[0];
                s.Points[i].YValues[0] = tx;
            }
        }

        //
        // column header click or double click
        //
        // polarData is a List of List of Strings, <List<List<String>>.  We want the inner list to represent rows and the outlist to represent columns so we have
        // a List of rows.  However, when you use the Insert() method with a column argument, it actually inserts a new row.  I am sure this is because, like everything else 
        // in .NET, it is build to handle a list of items that are from another source, like a SQL database.  Clearly, this is not what we want here.  When we look at the 
        // polarData data it seems organized the way I want it, but the insert functions do not work the way that seems intuitive.
        //
        private void polarGrid_ColumnHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Insert zero value column at cursor?", "Column Header Click", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                polarDataInsertColumn(e.ColumnIndex, "0");
            }
        }



        //
        // row header click or double click
        //
        private void polarGrid_RowHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Insert zero value row at cursor?", "Row Header Click", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                polarDataInsertRow(e.RowIndex, "0");
            }
        }



        void polarDataInsertRow(int rowIndex, String rowLabel)
        {
            List<String> listString = new List<String>();
            int rows, cols, rowStart;

            // initialize the string we are going to insert
            for (int i = 0; i < polarData[1].Count; i++)
            {
                listString.Add("0");
            }

            // get the location of the header row
            rowStart = firstValidRow(polarData);

            // add a row of zeros to polarData at the cursor.  Row zero is are heading so add one to the cursor.
            // also allow for junk before the header row.
            polarData.Insert(rowStart+rowIndex + 1, listString);

            // add the heading
            polarData[rowStart + rowIndex + 1][0] = rowLabel;

            // Get the new size
            cols = polarData[1].Count;
            rows = polarData.Count;
            Console.WriteLine("Insert Row @ " + rows + ", " + cols);
            polarDataPrint(polarData);

            // rebuild the data table.
            buildDataTable(polarData, rows, cols);
        }

        // Remove a row of data
        private void polarDataDeleteRow(int rowIndex, String rowLabel)
        {
            int rows, cols, count;

            // Row zero is the headings so don't remove them.
            count = polarData[rowIndex + 1].Count;

            polarData.RemoveAt(rowIndex + 1);

            // Get the new size
            cols = polarData[1].Count;
            rows = polarData.Count;
            Console.WriteLine("Delete Row @ " + rows + ", " + cols);
            polarDataPrint(polarData);

            // rebuild the data table.
            buildDataTable(polarData, rows, cols);
        }

        //  Insert a column of data
        private void polarDataInsertColumn(int colIndex, String colLabel)
        {
            List<String> listString = new List<String>();
            int rows, cols;

            listString.Add("0");

            // add the column label
            polarData[colIndex][0] = colLabel;

            for (int i = 0; i < polarData.Count; i++)
            {
                // add a columns of zeros to polarData at the cursor.  Column zero is are heading so add one to the cursor
                polarData[i].InsertRange(colIndex + 1, listString);
            }

            // Get the new dimensions
            cols = polarData[1].Count;
            rows = polarData.Count;
            //Console.WriteLine("Insert Column @ " + rows + ", " + cols);
            //polarDataPrint(polarData);

            // force rebuild of table
            buildDataTable(polarData, rows, cols);
        }


        // Remove a column of data
        private void polarDataDeleteColumn(int colIndex, String colLable)
        {
            int rows, cols;

            for (int i = 0; i < polarData.Count; i++)
            {
                // remove the element on the ith row at the colindex+1 position
                polarData[i].RemoveRange(colIndex + 1, 1);
            }

            // Get the new dimensions
            cols = polarData[1].Count;
            rows = polarData.Count;
            //Console.WriteLine("Insert Column @ " + rows + ", " + cols);
            //polarDataPrint(polarData);

            // force rebuild of table
            buildDataTable(polarData, rows, cols);
        }


        private void polarDataPrint(List<List<string>> polarData)
        {
            Console.WriteLine("polarData");
            for (int i = 0; i < polarData.Count; i++)
            {
                Console.Write("Row: " + i + ". ");
                for (int j = 0; j < polarData[i].Count; j++)
                {
                    Console.Write(", " + j + ": " + polarData[i][j]);
                }
                Console.WriteLine("");
            }
        }


        private void polarGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            // build the column graph
            buildColGraph(sender, e);
            //build the row graph
            buildRowGraph(sender, e);

            //polarData[e.RowIndex][e.ColumnIndex] = polarGrid[e.ColumnIndex, e.RowIndex].Value.ToString();

        }

        private void polarGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            buildColGraph(sender, e);
            buildRowGraph(sender, e);
        }

        private void polarMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
