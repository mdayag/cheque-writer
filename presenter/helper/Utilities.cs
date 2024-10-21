using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace presenter
{
    public static class Utilities
    {
        public static bool ConfirmSave()
        {
            return MessageBox.Show("Are you sure you want to Save?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static DialogResult ConfirmClose(string result)
        {
            return MessageBox.Show(result + "Are you sure you want to proceed?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public static bool ConfirmChangeOfType()
        {
            return MessageBox.Show("Are you sure you want to change ticket type?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool ConfirmDelete()
        {
            return MessageBox.Show("Are you sure you want to delete?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool ConfirmReactivate()
        {
            return MessageBox.Show("Are you sure you want to reactivate?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool ConfirmOveriding()
        {
            return MessageBox.Show("Are you sure you want to overide?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool ConfirmNewEntry(string result)
        {
            return MessageBox.Show(result + "Information Saved. Do you want to add a new record?", "Confirm",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        public static bool ConfirmPosting()
        {
            return MessageBox.Show("Are you sure you want to Post?", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool ConfirmSynch()
        {
            return MessageBox.Show("Are you sure you want to Synch? This would take several minutes.", "Question",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        } 

        public static string Result(bool isSynch, long ID)
        {
            string sResult = "";

            if(isSynch && ID > 0)
            {
                sResult = "Successfully synchronized! ";
            }
            else
            {
                sResult = "Problem occured at the back end. Please contact your administrator.";
            }

            return sResult;
        }

        public static string Result(long result)
        {
            string sResult = "";

            switch (result)
            {
                case -1:
                    sResult = "Problem occured at the back end. Please contact your administrator.";
                    MessageBox.Show("Record not saved. " + sResult, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    sResult = "Record already exists.";
                    MessageBox.Show("Record not saved. " + sResult, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -3:
                    sResult = "CRNo already exists.";
                    MessageBox.Show("Record not saved. " + sResult, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -4:
                    sResult = "Incorrect password.";
                    MessageBox.Show("Record not saved. " + sResult, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -5:
                    sResult = "Record was previously Posted";
                    MessageBox.Show(sResult, "Posting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -6:
                    sResult = "Unable to Post!, Tabulator Amount is UNMATCHED with Revisor Amount";
                    MessageBox.Show(sResult, "Posting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -7:
                    sResult = "Successfully Posted! ";
                    MessageBox.Show(sResult,"Posting",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
                case -8:
                    sResult = "Receipt Inventory not Exists. ";
                    MessageBox.Show(sResult, "Receipt Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -9:
                    break;
                default:
                    sResult = "Successfully saved! ";
                    break;
            }

            return sResult;
        }

        public static void FilterDataTable(DataTable dt, List<string> _filter)
        {
            dt.DefaultView.RowFilter = "";

            foreach (string lfilter in _filter)
            {
                dt.DefaultView.RowFilter = lfilter;
            }

            dt = dt.DefaultView.ToTable();
        }
    }
}
