using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace view
{
    public partial class frmReportLoading: Form
    {

        private Form currform;

        public frmReportLoading(Form frm)
        {
            InitializeComponent();
            currform = frm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            exitApplication();
        }

        public void exitApplication()
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Confirm Cancel", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void tsTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
