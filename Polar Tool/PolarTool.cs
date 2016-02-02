using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

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


        private void polarGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            openFileDialog1.FileName = "*.csv";
            openFileDialog1.Filter = "CSV files(*.csv)|*.csv|Text files(*.txt)|*.txt| All files(*.*)|*.*";

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
            polardata = csvt.CSVRead(filename, NumRows, NumCols);

            // build the Grid and Polar Charts
            buildGrid(polardata, csvt.actRows, csvt.actCols);
            buildPolar(polardata, csvt.actRows, csvt.actCols);

            // show the chart view by default
            polarChart.Hide();
            polarGridGroup.Show();
        }


        //
        //  File -> Eixt
        //
        private void fileStripExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        //
        // Copies the data in the array polardata into a data table and assigns
        // it to a DataGridView
        // rows and cols are the size of the data
        //
        private void buildGrid(string[,] polardata, int rows, int cols)
        {
            int rowstart;
            int rowcount, colcount;
            DataTable dt = new DataTable();
            double dnumber;
            int inumber;

            // Check to see if the first rwo actually contains data.  I may be comments.
            // The first token is allowed to be text, usually TWS/TWA, but the rest needs to be numbers
            rowstart = 0;
            for (colcount = 1; colcount < cols; colcount++)
            {
                if ( polardata[0, colcount] == null ) 
                {
                    rowstart = 1;
                }
            }

            // We use a DataTable to populate the DataGrid, so build the table
            // create columns
            for (colcount = 0; colcount < cols; colcount++)
            {
                dt.Columns.Add();
            }
            
            // copy the data from the polardata array in to the data table, row by row
            for (rowcount = rowstart; rowcount < rows; rowcount++)
            {
                // create a DataRow using .NewRow()
                DataRow row = dt.NewRow();

                // iterate over all columns to fill the row
                for (colcount = 0; colcount < cols; colcount++)
                {
                    try
                    {
                        // limit to one decimal point...who needs data in hundreths?
                        dnumber = Convert.ToDouble(polardata[rowcount, colcount]);
                        inumber = Convert.ToInt32(dnumber * 10.0);
                        dnumber = inumber / 10.0;
                        row[colcount] = dnumber;
                    }
                    // the data was not convertable to a decimal number, ie it was text
                    catch(FormatException e)
                    {
                        row[colcount] = polardata[rowcount, colcount];
                    }
                }

                // add the current row to the DataTable
                dt.Rows.Add(row);
            }

            // Copy the column labels from the first row to the column labels
            // Note that the datatable always starts at 0.  If we ignored the first 
            // row of polardata, it is not included in DT.
            for (colcount = 0; colcount < cols; colcount++)
            {
                dt.Columns[colcount].ColumnName = dt.Rows[0][colcount].ToString();
            }

            // delete the row we just copied the labels from
            dt.Rows.RemoveAt(0);

            // Assign to grid view.  Note this method will NOT work with a polar chart (at least that I can figure).
            polarGrid.DataSource = dt;

            // Note the next actions have to be done AFTER the data table is assigned to the Grid View
            // so the GridView will have the proper dimensions.

            // Copy Row labels from column 0. 
            // Note that datatable does not include a row.name attribute, so there is no way to assign it in the data table
            // The best we can do is assign it in the DGV
            for (rowcount = 0; rowcount < polarGrid.Rows.Count; rowcount++)
            {
                polarGrid.Rows[rowcount].HeaderCell.Value = dt.Rows[rowcount][0];
                polarGrid.Rows[rowcount].Cells[0].Value = "";
            }

            // delete the column we just copied the labels from....I have changed this.  
            polarGrid.Columns.RemoveAt(0);

            // make the data table columns unsortable.  be careful about using the passed column size since we have 
            // added or deleted columns
            for (colcount = 0; colcount < polarGrid.Columns.Count; colcount++)
            {
                polarGrid.Columns[colcount].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // make the column headers visible
            polarGrid.ColumnHeadersVisible = true;
        }



        //
        //  Build the polar chart
        //
        private void buildPolar(string[,] polardata, int rows, int cols)
        {
            int rowstart;
            int rowcount, colcount;
            Boolean ignoreFirstRow = false;
            double theta;
            double r;

            // Check to see if the first row actually contains data.  I may be comments.
            // The first token is allowed to be text, usually TWA/TWS, but the rest needs to be numbers
            rowstart = 0;
            for (colcount = 1; colcount < cols; colcount++)
            {
                if (polardata[0, colcount] == null)
                {
                    rowstart = 1;
                }
            }

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
//                    Console.Write("Row: " + rowcount + ". Column: " + colcount + ". Data: " + polardata[0, colcount]);

                    // explicitly convert the strings to double
                    theta = Convert.ToDouble(polardata[rowcount, 0]);
                    r = Convert.ToDouble(polardata[rowcount, colcount]);

                    polarSeries[colcount - 1].Points.AddXY(theta, r);
//                    Console.WriteLine("Data added: " + theta + ", " + r);
//                    Console.WriteLine("Series Data: " + polarSeries[colcount-1].Points[rowcount-rowstart-1].XValue + ", " + polarSeries[colcount-1].Points[rowcount-rowstart-1].YValues[0]);
                }
            }
        }
    }
}
