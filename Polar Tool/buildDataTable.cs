using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Polar_Tool
{
    public partial class formMain : Form
    {
        private void buildDataTable(List<List<String>> polarData, int rows, int cols)
        {
            //
            // Copies the data in the array polarData into a data table and assigns
            // it to a DataGridView
            // rows and cols are the size of the data
            //
            int rowStart;               // starting row in polarData
            int rowCount, colCount;     // row and column count variables
            int thisRow, thisCol;       // to save some repeated computations
            double dnumber;             // used for converting speed to double with 10ths only
            int inumber;                // used for converting speed to double

            try
            {
                dt.Dispose();
            }
            catch (Exception)
            {
               // dt did not exist, do nothing
            }

            // create a new instance of the table
            dt = new DataTable("polarDataTable");

            // reset and clear the datatable
            dt.Reset();

            // get the first valid row of the polarData
            rowStart = firstvalidrow(polarData, cols);

            // This just adds the columns to the table.  The data is added below.
            for (colCount = 1; colCount < cols; colCount++)
            {
                thisCol = colCount - 1;

                // add the col and set the ordinal
                dt.Columns.Add(polarData[rowStart][colCount]);
                dt.Columns[thisCol].SetOrdinal(thisCol);
                // column names are the first usable row of polarData
                dt.Columns[thisCol].ColumnName = polarData[rowStart][colCount];
            }

            // Add the rows only.  The data is added below
            for (rowCount = rowStart; rowCount < rows - rowStart; rowCount++)
            {
                // add the rows using the row index
                dt.Rows.Add(rowCount - rowStart);
            }

            // Create columns names.  Should be in the first usable row of polarData
            // The first colulmn are the angles and used for row headings and are NOT in this table
            for (colCount = 1; colCount < cols; colCount++)
            {
                // save some repeated calculations
                thisCol = colCount - 1;

                // Populate the Row getting the data.  There is no Row name in the DataTable Class
                for (rowCount = rowStart; rowCount < rows - rowStart; rowCount++)
                {
                    // so we don't have to compute this all the time
                    thisRow = rowCount - rowStart;
                    try
                    {
                        // limit to one decimal point...who needs data in hundreths?
                        dnumber = Convert.ToDouble(polarData[rowCount][colCount]);
                        inumber = Convert.ToInt32(dnumber * 10.0);
                        dnumber = inumber / 10.0;
                    }
                    // the data was not convertable to a decimal number, ie it was text
                    catch (FormatException)
                    {
                        MessageBox.Show("Data Row Insertion Error: " + polarData[rowCount][colCount] + ". Data ignored.");
                        dnumber = 0;
                    }

                    // assign the value
                    dt.Rows[thisRow][thisCol] = dnumber;

                }  // rows
            } // columns

            // delete the first row tha the column names came from
            dt.Rows.RemoveAt(0);

            printTable(dt);

            // display the Grid
            displayGrid(dt, dt.Rows.Count, dt.Columns.Count);
        }

        private void printTable(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.Write("Row: " + i + " ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(j + ": " + dt.Rows[i][j] + ", ");
                }
                Console.WriteLine("");
            }
        }

        private void displayGrid(DataTable dt, int rows, int cols)
        {
            int rowCount, colCount;
            int rowStart;                           // first valid row from polarData


            // reset the Grid display
            polarGrid.DataSource = null;

            // get the first valid row of the polarData
            rowStart = firstvalidrow(polarData, cols);

            // Assign to grid view.  Note this method will NOT work with a polar chart (at least that I can figure).
            var dtField = polarGrid.DataSource = dt;

            // check for error assigning dt

            // Note the next actions have to be done AFTER the data table is assigned to the Grid View
            // so the GridView will have the proper dimensions.

            // Copy Row labels from column 0 of polarData.  This data is not in the datatable
            // The first row in polarData is the wind speed and is skipped.
            for (rowCount = rowStart + 1; rowCount < rows-rowStart+1; rowCount++)
            {
                polarGrid.Rows[rowCount-rowStart-1].HeaderCell.Value = polarData[rowCount][0];
            }

            // make the datagridview columns unsortable.  be careful about using the passed column size since we have 
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

