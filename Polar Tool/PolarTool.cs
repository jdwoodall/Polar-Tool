using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Polar_Tool
{
    public partial class formMain : Form
    {
        // use these for the  size of  the CSV array.  They need to be global to this space.
        // it has to big enough for any possible array.  It could probably be half this size.
        const int NumRows = 360;
        const int NumCols = 100;

        //want this tool to stay in scope although it could be moved into File->Open
        CSVTools.CSVTools csvt = new CSVTools.CSVTools();

        //want this data to stay in scope
        string[,] polardata = new string[NumRows, NumCols];

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
        //  File -> Open
        //
        private void fileStripOpen_Click(object sender, EventArgs e)
        {
            string filename;
            DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, 0);

            openFileDialog1.FileName = "*.csv";
            openFileDialog1.Filter = "CSV files(*.csv, *.txt, *.pol)|*.csv;*.txt;*.pol|All files(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                this.Text = "Polar Tool: " + filename;
            }
            else
            {
                // need error handling here
                filename = "";
                Close();
            }

            // this will read the CSV file into a two dimensional array
            polardata.Initialize();
            polardata = csvt.CSVRead(filename, NumRows, NumCols);

            // build the Grid and Polar Charts
            buildGrid(polardata, csvt.actRows, csvt.actCols);
            buildPolar(polardata, csvt.actRows, csvt.actCols);



            buildColGraph(this, ee);
            buildRowGraph(this, ee);
          

            // show the chart view by default
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

        int firstvalidrow(string[,] data, int cols)
        {
            int colcount;
            int rowstart;
                
            rowstart = 0;
            for (colcount = 1; colcount < cols; colcount++)
            {
                if (data[0, colcount] == null || data[0,colcount] == "")
                {
                    rowstart = 1;
                }
            }
            return rowstart;
        }
 

        //
        //  Build the polar chart
        //
        private void buildPolar(string[,] polardata, int rows, int cols)
        {
            int rowstart;
            int rowcount, colcount;
            double theta;
            double r;

            // get the first valid row
            rowstart = firstvalidrow(polardata, cols);

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
                // Console.WriteLine("Series added: " + polardata[0, colcount]);

                polarSeries[colcount - 1] = polarChart.Series.Add(polardata[rowstart, colcount]);
                polarSeries[colcount-1].ChartType = SeriesChartType.Polar;

                //  Add the data points.  The series is added as an XY pair where X = the angle and Y = the boat speed
                for (rowcount = rowstart + 1; rowcount < rows; rowcount++)
                {
                    //Console.WriteLine("Row: " + rowcount + ". Column: " + colcount + ". Data: " + polardata[rowcount, colcount]);

                    // explicitly convert the strings to double
                    theta = Convert.ToDouble(polardata[rowcount, 0]);
                    try
                    {
                        r = Convert.ToDouble(polardata[rowcount, colcount]);
                        polarSeries[colcount - 1].Points.AddXY(theta, r);
                    }
                    catch (Exception)
                    {
                        // if the conversion failed it is likely a trailing space or tab so ignore it
                        // note that this never happen if the csv tool is properly filtering whitespace
                    }
//                    Console.WriteLine("Data added: " + theta + ", " + r);
//                    Console.WriteLine("Series Data: " + polarSeries[colcount-1].Points[rowcount-rowstart-1].XValue + ", " + polarSeries[colcount-1].Points[rowcount-rowstart-1].YValues[0]);
                }
            }
        }


        // show a column of the polardata as series fit to a spline graph
        private void btnGraphLine_Click(object sender, EventArgs e)
        {

        }

        //
        // NOTE:  This code is not currently used.  Save it though.
        //
        private void display_colGraph (object sender, EventArgs e, String btnText)
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
            firstrow = firstvalidrow(polardata, numcols);

            // default to first column
            displaycolumn = 1;

            // find column user requested
            for (int colcount = 1; colcount < numcols; colcount++)
            {
                if (polardata[firstrow, colcount] == btnText)
                {
                    displaycolumn = colcount;
                    break;
                }
            }

            // set the chart type to spline
            lineSeries = chartColGraph.Series.Add(polardata[firstrow, displaycolumn]);
            lineSeries.ChartType = SeriesChartType.Spline;

            // add data from polardata.  The first row are headings and need to be skipped.
            for (int rowcount = firstrow+1; rowcount < numrows; rowcount++)
            {
                lineSeries.Points.AddXY(Convert.ToDouble(polardata[rowcount, displaycolumn]), Convert.ToDouble(polardata[rowcount, 0]));
            }
        }


        private void polarGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // build the column graph
            buildColGraph(sender, e);
            //build the row graph
            buildRowGraph(sender, e);
        }


        private void buildRowGraph(object sender, DataGridViewCellEventArgs e)
        {
            // Build the Chart under the main form.  It shows the data moving along the selected row.
            // declare and allocate the data series.  There is is one for each maximum col of data.

            Series rowSeries;
            rowSeries = new Series();
            rowSeries.Points.Clear();
            rowSeries.YValuesPerPoint = 1;

            // clear the current data series
            chartRowGraph.Series.Clear();
            chartRowGraph.DataSource = null;

            // move across the polarChart getting the data
            for (int i = 0; i < polarChart.Series.Count; i++)
            {
                rowSeries.Points.AddXY(polarChart.Series[i].Name, polarChart.Series[i].Points[e.RowIndex].YValues[0]);
            }

            // Set the chart to type "Line".  Could also be a spline, but there will be discontinuities due to msoft
            // spine fitting appearing to be piecewise.
            rowSeries.ChartType = SeriesChartType.Line;

            //  fix the broken .NET autorange function.
            chartRowGraph.ChartAreas[0].AxisY.Maximum = Math.Floor(FindMaxY(rowSeries) + 1.5);
            chartRowGraph.Series.Add(rowSeries);
        }


        private void buildColGraph(object sender, DataGridViewCellEventArgs e)
        {
            //  Build the chart to the right of the form.  This displays one column of data from the selected column
            //  indicate by e.ColumnIndex

            int i;
            double x, y;

            // declare and allocate the data series.  There is is one for each maximum col of data.
            Series colSeries;
            colSeries = new Series();
            colSeries.Points.Clear();
            colSeries.YValuesPerPoint = 1;

            // clear the current data series
            chartColGraph.Series.Clear();
            chartColGraph.DataSource = null;

            // copy the data to colSeries.  Do not assign directly from polarChart as it will mess up that graph
            // move DOWN the column, specified e.ColumnIndex, building the data.
            // there is not direct way to get the number of ROWS in a chart - that I can tell - only the colums, which we don't want.
            // so we use this rather shameful method to get the data
            i = 0;
            while (i >= 0)
            {
                try
                {
                    x = polarChart.Series[e.ColumnIndex].Points[i].XValue;
                    y = polarChart.Series[e.ColumnIndex].Points[i].YValues[0];
                    // note this is assigned backwards.  We want the wind angle on Y and the speed on X
                    colSeries.Points.AddXY(y, x);
                    Console.WriteLine("@i = " + i + ". x = " + x + ". y = " + y);
                    i++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Break at i = " + i);
                    i = -1;
                }
            }

            // make it appear as a line. Spline also works, but will have some dicontinuites as Msoft appears to be using
            // a piecewise spline rather than a Nurb.  NEXT UP - Find a decent NURB library.
            colSeries.ChartType = SeriesChartType.Line;

            // this is because .NET auto range does not always work.
            chartColGraph.ChartAreas[0].AxisX.Maximum = Math.Floor(FindMaxX(colSeries) + 1.5);
            chartColGraph.Series.Add(colSeries);
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
            ShallowCopy(sout,sin);
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
        // Print the contents of the Chart C
        //  This prints across, then down.
        //  It can generate a lot of data.
        //
        private void printGraph(Chart c)
        {
            for (int i = 0; i < c.Series.Count; i++)
            {
                Console.Write("Index: " + i +" Series: " + c.Series[i].Name);
                Console.WriteLine(" Count: " + c.Series[i].Points.Count);
                PrintSeries("Graph Data", c.Series[i]);
            }
        }

        //
        // Print the data in the series
        //
        private void PrintSeries(String caption, Series s)
        {
            Console.WriteLine(caption + ".  Series " + s.Name);
            for (int i = 0; i < s.Points.Count; i++)
            {
                Console.WriteLine("Point " + i + " : x=" + s.Points[i].XValue + ". y=" + s.Points[i].YValues[0]);
            }
        }


        //
        // swaps the X and Y values in the passed series
        // Note that this series was created by a shallow copy, it will re-order the original data.  See Deep Copy.
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

        private void rowChart_Click(object sender, EventArgs e)
        {

        }
    }
}
