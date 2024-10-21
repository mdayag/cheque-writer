using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using business_logic;
using common;
using interfaces;
using presenter;
using viewModel;
using Utilities = common.Utilities;
using view.helpers;

namespace view.forms
{
    public partial class frmChequeWriterEntry : myForm, IReport
    {
        #region Members

        private readonly IChequeLogs _checkLogs;
        private readonly ReportPresenter _presenter;
        private frmReportViewer _viewer;
        private List<ParameterField> _listParameterField;
        private const string _appName = "Cheque Writer";
        private bool _isConvertClicked = false;

        #endregion

        #region Constructor

        public frmChequeWriterEntry(IChequeLogs checkLogs)
        {
            InitializeComponent();
            _checkLogs = checkLogs;
            _presenter = new ReportPresenter(this);
            _listParameterField = new List<ParameterField>();

            gbMain.Visible = false;
            txtNumber.Text = "0.00";
            chkPrint.Checked = true;
        }

        #endregion

        #region Implementation of IBaseTransactions

        public string _formName { get; set; }

        public bool _showNewEntry { set; private get; }

        public DataTable _dt { get; set; }

        public string _message { get; set; }

        #endregion

        #region Implementation of IReport

        public long _id
        {
            get
            {
                return 1;
            }
            set
            {
                
            }
        }

        public string _reportName
        {
            get
            {
                return "Cheque.rpt";
            }
            set
            {
                
            }
        }

        public string _fileName
        {
            get
            {
                return "Cheque.rpt";
            }
            set
            {
                
            }
        }

        public string _reportPath
        {
            get
            {
                var dir = Path.GetDirectoryName(Application.ExecutablePath);
                dir += dir != null && dir.EndsWith(@"\") ? @"Reports" : @"\\Reports";

                if (!Directory.Exists(dir))
                {
                    try
                    {
                        Directory.CreateDirectory(dir);
                    }
                    catch (Exception ex)
                    {
                        dir = @"C:\\Reports";
                        //in case the directory is unreachable
                        Directory.CreateDirectory(dir);
                    }
                }

                return dir;
            }
            set
            {
                
            }
        }

        public List<ParameterField> listParameterField
        {
            get
            {
                return _listParameterField;
            }
            set
            {
                _listParameterField = value;
            }
        }

        public EnumFormMode _formMode_ReportViewer 
        { 
            get
            {
                return _presenter.FormMode;
            }
            set
            {
                if (Application.OpenForms.OfType<frmReportViewer>().Count() != 0)
                    _viewer.Dispose();

                _viewer = new frmReportViewer(_presenter, this, chkPrint.Checked, 1);

                _viewer.WindowState = chkPrint.Checked 
                                    ? 
                                    FormWindowState.Minimized
                                    :
                                    FormWindowState.Minimized;

                _viewer.Show();
            }
        }

        #endregion

        #region Events

        private void frmChequeAutomationEntry_Load(object sender, EventArgs e)
        {
            List<Action> _action = new List<Action>();
            _action.Add(LoadForm);
            _presenter.ProcessMethod(new frmReportLoading(this), this, _action);
        }

        private void LoadForm()
        {
            var banks = from Bank en in Enum.GetValues(typeof(Bank))
                        select new { id = (int)en, name = en.ToString() };

            cboBank.DataSource = banks.ToList();
            cboBank.ValueMember = "id";
            cboBank.DisplayMember = "name";
            
            gbMain.Visible = true;

            cboBank.SelectedValue = 14;
            cboBank.Focus();
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            Utilities.ValidateDecimal(txtNumber);
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    ConvertNumToWords();
                }
            }
            catch (Exception ex)
            { }
        }

        private void txtNumber_Leave(object sender, EventArgs e)
        {
            ConvertNumToWords();
        }

        private void ConvertNumToWords()
        {
            Double n = Double.Parse(Convert.ToDouble(txtNumber.Text).ToString("#,##0.00"));

            txtNumberInWords.Text = NumberToWordsWrapper.ConvertNumToWords(n);
            _isConvertClicked = true;
            decimal num = Convert.ToDecimal(txtNumber.Text);
            txtNumber.Text = num.ToString("N2");
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                List<Action> _action = new List<Action>();
                _action.Add(ProcessReport);
                _presenter.ProcessMethod(new frmReportLoading(this), this, _action);
            }
        }

        private void ProcessReport()
        {
            var vm = new ChequeLogsViewModel
            {
                BankId = Convert.ToInt32(cboBank.SelectedValue),
                Bank = cboBank.Text,
                ChequeNumber = txtChequeNumber.Text,
                Brstn = txtBrstn.Text,
                DateIssued = Convert.ToDateTime(dtpDateIssued.Value.ToString()),
                Payee = txtPayee.Text,
                Amount = Convert.ToDecimal(txtNumber.Text),
                AmountInWords = txtNumberInWords.Text
            };

            _checkLogs.SaveChequeLogs(vm);
            _presenter.SetParameterValues(vm);
            _formMode_ReportViewer = EnumFormMode.View;

            SetClearFields();
        }

        private bool IsValid()
        {
            bool ret = false;

            if (_isConvertClicked == false)
            {
                ConvertNumToWords();
            }

            if (string.IsNullOrEmpty(txtPayee.Text))
            {
                MessageBox.Show("Pay in order of is required!", _appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPayee.SelectAll();
                txtPayee.Focus();
            }
            else if (string.IsNullOrEmpty(txtNumber.Text) || txtNumber.Text == "0" || txtNumber.Text == "0.00")
            {
                MessageBox.Show("Amount is required!", _appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.Text = "0.00";
                txtNumber.SelectAll();
                txtNumber.Focus();
            }
            else if (string.IsNullOrEmpty(txtNumberInWords.Text))
            {
                MessageBox.Show("Amount in words is required!", _appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.Select();
                txtNumber.Focus();
            }
            else if (txtNumberInWords.Text == "ZERO")
            {
                MessageBox.Show("Amount in words cannot be zero!", _appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.SelectAll();
                txtNumber.Focus();
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        private  void SetClearFields()
        {
            txtChequeNumber.Text = string.Empty;
            txtBrstn.Text = string.Empty;
            dtpDateIssued.Value = DateTime.Now;
            txtPayee.Text = string.Empty;
            txtNumber.Text = "0.00";
            txtNumberInWords.Text = string.Empty;
            _isConvertClicked = false;
            cboBank.SelectAll();
            cboBank.Focus();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && !txtNumber.Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
        }

        #endregion
    }
}
