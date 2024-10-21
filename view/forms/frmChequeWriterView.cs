using System;
using interfaces;
using view.helpers;

namespace view.forms
{
    public partial class frmChequeWriterView : myForm
    {
        #region Members

        private readonly IChequeLogs _checkLogs;

        #endregion Members

        #region Constructor

        public frmChequeWriterView(IChequeLogs checkLogs)
        {
            InitializeComponent();
            _checkLogs = checkLogs;
        }

        #endregion Constructor

        #region Events

        private void frmChequeAutomationView_Load(object sender, EventArgs e)
        {
            dtgView.DataSource = _checkLogs.GetChequeLogsByDateRange(string.Empty, Convert.ToDateTime(dtpFrom.Value.ToString()), Convert.ToDateTime(dtpTo.Value.ToString()));
            dtpFrom.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dtgView.DataSource = _checkLogs.GetChequeLogsByDateRange(txtSearch.Text, Convert.ToDateTime(dtpFrom.Value.ToString()), Convert.ToDateTime(dtpTo.Value.ToString()));
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtgView.DataSource = _checkLogs.GetChequeLogsByDateRange(txtSearch.Text, Convert.ToDateTime(dtpFrom.Value.ToString()), Convert.ToDateTime(dtpTo.Value.ToString()));
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            dtgView.DataSource = _checkLogs.GetChequeLogsByDateRange(txtSearch.Text, Convert.ToDateTime(dtpFrom.Value.ToString()), Convert.ToDateTime(dtpTo.Value.ToString()));
        }

        #endregion Events
    }
}