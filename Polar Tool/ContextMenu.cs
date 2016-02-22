using System;

namespace Polar_Tool
{
    partial class formMain
    {
        //
        // items and objects for the context strip menu
        //
        //
        // Got here by selecting "Insert->Row" from the context menu.  This only shows the dialog.  The
        // results are available on the "click event", below
        //
        private void ToolStripMenuItemInsRow_Click(object sender, EventArgs e)
        {
            insDelGroupBox.Text = "Insert Row Heading and press OK to continue or cancel to exit.";
            colRowHeading.Text = "New Row Heading?";
            radioBtnRow.Checked = true;
            radioBtnIns.Checked = true;
            insDelGroupBox.Show();
        }

        private void ToolStripMenuItemInsCol_Click(object sender, EventArgs e)
        {
            insDelGroupBox.Text = "Insert Column Heading and press OK to continue or cancel to exit.";
            colRowHeading.Text = "New Column Heading?";
            radioBtnCol.Checked = true;
            radioBtnIns.Checked = true;
            insDelGroupBox.Show();
        }

        private void ToolStripMenuItemDelRow_Click(object sender, EventArgs e)
        {
            insDelGroupBox.Text = "Enter row heading to delete and press OK to continue or Cancel to exit.";
            colRowHeading.Text = "Row heading do delete?";
            radioBtnRow.Checked = true;
            radioBtnDel.Checked = true;
            insDelGroupBox.Show();
        }

        private void ToolStripMenuItemDelCol_Click(object sender, EventArgs e)
        {
            insDelGroupBox.Text = "Enter column heading to delete and press OK to continue or Cancel to exit.";
            colRowHeading.Text = "Column heading do delete?";
            radioBtnCol.Checked = true;
            radioBtnDel.Checked = true;
            insDelGroupBox.Show();
        }
        //
        // click event "OK" button in the pop-up dialog box.
        //
        private void insDelBtnOK_Click(object sender, EventArgs e)
        {
            int row, col;
            String heading;

            // hide the dialog box
            insDelGroupBox.Hide();

            // get the heading value from the dialog box
            heading = insDelHeadingValue.Text;

            // get the location of the currently selected cell
            row = polarGrid.SelectedCells[0].RowIndex;
            col = polarGrid.SelectedCells[0].ColumnIndex;

            // Since there is only return, find out what to do
            if (radioBtnIns.Checked)
            {
                if (radioBtnRow.Checked)
                {
                    polarDataInsertRow(row, heading);
                }
                else if (radioBtnCol.Checked)
                {
                    polarDataInsertColumn(col, heading);
                }
            }
            else if (radioBtnDel.Checked)
            {
                if (radioBtnRow.Checked)
                {
                    polarDataDeleteRow(row, heading);
                }
                else if (radioBtnCol.Checked)
                {
                    polarDataDeleteColumn(col, heading);
                }
            }
        }


        private void insDelBtnCancel_Click(object sender, EventArgs e)
        {
            // hide the dialog box
            insDelGroupBox.Hide();
        }


        private void rowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void columnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void insDelGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }

}
