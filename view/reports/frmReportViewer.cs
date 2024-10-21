using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using common;
using CrystalDecisions.Shared;
using interfaces;
using presenter;

namespace view
{
    public partial class frmReportViewer : Form
    {
        #region Members

        private ReportPresenter _presenter;
        private IReport _viewParent;

        private bool _isPdfViewer = false;
        private bool _isPrintReceipt = false;
        private int _numOfCopies = 1;

        #endregion

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(ReportPresenter presenter, IReport view)
        {
            InitializeComponent();
            _presenter = presenter;
            _viewParent = view;
        }

        public frmReportViewer(ReportPresenter presenter, IReport view, bool isPdfViewer)
        {
            InitializeComponent();
            _presenter = presenter;
            _viewParent = view;
            _isPdfViewer = isPdfViewer;
        }

        public frmReportViewer(ReportPresenter presenter, IReport view, bool isPrintNow, int numOfCopies)
        {
            InitializeComponent();
            _presenter = presenter;
            _viewParent = view;

            _isPrintReceipt = isPrintNow;
            _numOfCopies = numOfCopies;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadReport()
        {
            ReportUtility reportUtility = new ReportUtility(crystalReportViewer1);
            List<ParameterField> paramList = _viewParent.listParameterField;

            if (_isPrintReceipt && _numOfCopies != 0)
            {
                reportUtility.setPrintNumOfCopies(_numOfCopies);
            }

            if (_isPdfViewer)
            {
                reportUtility.ReportsView(_viewParent._fileName, _viewParent._reportPath, paramList);

                reportUtility.LogonReportExport(ConfigurationManager.AppSettings["ServerName"]
                                , ConfigurationManager.AppSettings["DatabaseName"]
                                , ConfigurationManager.AppSettings["UserName"]
                                , ConfigurationManager.AppSettings["Password"]);

                Close();
            }
            else if (_viewParent._fileName == "Cheque.rpt")
            {
                reportUtility.ReportsView(_viewParent._fileName, _viewParent._reportPath, paramList, _isPrintReceipt);
                reportUtility.LogonReport();
            }
            else
            {
                reportUtility.ReportsView(_viewParent._fileName, _viewParent._reportPath, paramList, _isPrintReceipt);

                reportUtility.LogonReport(ConfigurationManager.AppSettings["ServerName"]
                                , ConfigurationManager.AppSettings["DatabaseName"]
                                , ConfigurationManager.AppSettings["UserName"]
                                , ConfigurationManager.AppSettings["Password"]);
            }
        }
    }
}
