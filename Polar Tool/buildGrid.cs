using System;
using System.Data;
using System.Windows.Forms;

namespace Polar_Tool
{
    public partial class formMain : Form
    {
        private void buildGrid(string[,] polardata, int rows, int cols)
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
            DataColumn tcol;

            // Use a DataTable to hold the data and assign it to DGV
            DataTable dt = new DataTable();

            //  Unassign the display grid from the datasource while we build it.
            //  This eliminates reuse problems with columns not being in the correct order.
            polarGrid.DataSource = null;

            // reset and clear the datatable
            dt.Reset();

            // get the first valid row
            rowstart = firstvalidrow(polardata, cols);

            // We use a DataTable to populate the DataGrid, so build the table

            // Create columns
            for (colcount = 0; colcount < cols; colcount++)
            {
                // add the column including its name
                // the name should be a number except for possibly the [0,0] location
                try
                {
                    dnumber = Convert.ToDouble(polardata[rowstart, colcount]);
                    tcol = dt.Columns.Add(polardata[rowstart, colcount]);
                }
                catch (Exception)
                {
                    // value is not a valid number
                    if (colcount == 0)
                    {
                        tcol = dt.Columns.Add(polardata[rowstart, colcount]);
                    }
                    else
                    {
                        tcol = dt.Columns.Add(polardata[rowstart, colcount + 1]);
                    }
                }

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
                    catch (FormatException e)
                    {
                        row[colcount] = polardata[rowcount, colcount];
                    }
                }
                // add the current row to the DataTable
                dt.Rows.Add(row);
            }

            // Remove row 0 as it was used for the labels/captions of the column headers
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

            // delete the column we just copied the row labels from.
            polarGrid.Columns.RemoveAt(0);

            // make the data table columns unsortable.  be careful about using the passed column size since we have 
            // added or deleted columns
            for (colcount = 0; colcount < polarGrid.Columns.Count; colcount++)
            {
                polarGrid.Columns[colcount].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // make the column headers visible
            polarGrid.ColumnHeadersVisible = true;

            // done with the data table.
            dt.Dispose();
        }
    }
}

