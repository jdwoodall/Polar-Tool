using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Polar_Tool
{
    public partial class formMain : Form
    {
        private void buildGrid(List<List<String>> polardata, int rows, int cols)
        {
            //
            // Copies the data in the array polardata into a data table and assigns
            // it to a DataGridView
            // rows and cols are the size of the data
            //
            int rowstart;
            int rowcount, colcount;
            double dnumber;
            int inumber;

            // reset and clear the datatable
            dt.Reset();

            // get the first valid row of the polardata
            rowstart = firstvalidrow(polardata, cols);

            // We use a DataTable to populate the DataGrid, so build the table

            // Create columns
            for (colcount = 0; colcount < cols; colcount++)
            {
                dt.Columns.Add(polardata[rowstart][colcount]);
            }
#if false

            // add the column including its name
            // the data should be a number except for possibly the [0,0] location
            try
                {
                    dnumber = Convert.ToDouble(polardata[rowstart][colcount]);
                    dt.Columns.Add(polardata[rowstart][colcount]);
                }
                catch (Exception)
                {
                    // value is not a valid number
                    if (colcount == 0)
                    {
                        dt.Columns.Add(polardata[rowstart][colcount]);
                    }
                }
            }
#endif

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
                        dnumber = Convert.ToDouble(polardata[rowcount][colcount]);
                        inumber = Convert.ToInt32(dnumber * 10.0);
                        dnumber = inumber / 10.0;
                        row[colcount] = dnumber;
                    }
                    // the data was not convertable to a decimal number, ie it was text
                    catch (FormatException e)
                    {
                        row[colcount] = polardata[rowcount][colcount];
                    }
                }
                // add the current row to the DataTable
                dt.Rows.Add(row);
            }

            // Remove row 0 as it was used for the labels/captions of the column headers
            dt.Rows.RemoveAt(0);

            // display the Grid
            displayGrid(dt);
        }

        private void displayGrid(DataTable dt)
        {
            int rowCount, colCount;

            // reset the Grid display
            polarGrid.DataSource = null;

            // Assign to grid view.  Note this method will NOT work with a polar chart (at least that I can figure).
            polarGrid.RowCount = dt.Rows.Count;
            polarGrid.DataSource = dt;

            //  the assignment of dt.Rows.Count seems for force an extra column so delete it
            polarGrid.Columns.RemoveAt(0);

            // Note the next actions have to be done AFTER the data table is assigned to the Grid View
            // so the GridView will have the proper dimensions.

            // Copy Row labels from column 0. 
            // Note that datatable does not include a row.name attribute, so there is no way to assign it in the data table
            // The best we can do is assign it in the DGV
            for (rowCount = 0; rowCount < polarGrid.Rows.Count; rowCount++)
            {
                polarGrid.Rows[rowCount].HeaderCell.Value = dt.Rows[rowCount][0];
                // polarGrid.Rows[rowcount].Cells[0].Value = "";
            }

            // delete the column we just copied the row labels from and from the data table.
             polarGrid.Columns.RemoveAt(0);
//            dt.Columns.RemoveAt(0);

            // make the data table columns unsortable.  be careful about using the passed column size since we have 
            // added or deleted columns.
            for (colCount = 0; colCount < polarGrid.Columns.Count; colCount++)
            {
                polarGrid.Columns[colCount].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // make the column headers visible
            polarGrid.ColumnHeadersVisible = true;

        }
    }
}

