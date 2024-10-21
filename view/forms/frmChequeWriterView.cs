using System;
using common;
using System.Collections.Generic;
using System.Windows.Forms;
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
            gbMain.Visible = false;
        }

        #endregion Constructor

        #region Events

        private void frmChequeAutomationView_Load(object sender, EventArgs e)
        {
            List<Action> _action = new List<Action>();
            _action.Add(LoadForm);
            ProcessMethod(new frmReportLoading(this), this, _action);
        }

        private void LoadForm()
        {
            dtgView.DataSource = _checkLogs.GetChequeLogsByDateRange(string.Empty, Convert.ToDateTime(dtpFrom.Value.ToString()), Convert.ToDateTime(dtpTo.Value.ToString()));

            gbMain.Visible = true;
            dtpFrom.Focus();
        }

        private void ProcessMethod(Form frmload, Form _current, List<Action> _action)
        {
            Threading t = new Threading(_current, _action, frmload);
            t.ProcessNow();
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