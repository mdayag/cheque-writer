using System.Collections.Generic;
using CrystalDecisions.Shared;
using common;
using interfaces;
using model;
using viewModel;

namespace presenter
{
    public class ReportPresenter : BasePresenterTransactions<ReportModel, IReport>
    {
        #region Members

        #region Common

        private IReport _view;
        private DbService _dbService;
        private ReportModel _model;
        private GenericsClass _genericUtilities = new GenericsClass();
        private List<ReportModel> _listModel = new List<ReportModel>();
        private EnumFormMode _formMode = EnumFormMode.New;
        private bool _viewShown = false;
        public long _id;

        #endregion

        #region Exclusive

        private ParameterField _paramFieldDateIssued;
        private ParameterDiscreteValue _paramValDateIssued;

        private ParameterField _paramFieldPayee;
        private ParameterDiscreteValue _paramValPayee;

        private ParameterField _paramFieldAmount;
        private ParameterDiscreteValue _paramValAmount;

        private ParameterField _paramFieldAmountInWords;
        private ParameterDiscreteValue _paramValAmountInWords;

        #endregion

        #endregion

        #region Properties

        #region Exclusive


        #endregion

        #region Overrides of BasePresenterTransactions<ReportModel,IReport>

        public override DbService DbService
        {
            get { return _dbService; }
        }

        public override GenericsClass GenericUtilities
        {
            get { return _genericUtilities; }
        }

        public override EnumFormMode FormMode
        {
            get { return _formMode; }
            set { _formMode = value; }
        }

        public override long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override IReport View
        {
            get { return _view; }
            set { _view = value; }
        }

        public override bool ViewShown
        {
            get { return _viewShown; }
            set { _viewShown = value; }
        }

        public override ReportModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public override List<ReportModel> ListModel
        {
            get { return _listModel; }
            set { _listModel = value; }
        }

        #endregion

        #endregion

        #region Contructors

        public ReportPresenter(IReport view)
            : this(view
                , new DbService()
                , new ReportModel()
                , new GenericsClass()
                , new List<ReportModel>())
        { }

        private ReportPresenter(IReport view, DbService service, ReportModel model, GenericsClass genericsClass, List<ReportModel> list)
        {
            _view = view;
            _dbService = service;
            _model = model;
            _genericUtilities = genericsClass;
            _listModel = list;
            _formMode = EnumFormMode.New;
            LoadAllData = Load;
            InitilizeLookUp = Initialize;
        }

        #endregion

        #region Functions/Methods

        #region Exclusive

        private void Initialize()
        {
            
        }

        public void SetParameterValues(ChequeLogsViewModel vm)
        {
            _view.listParameterField = new List<ParameterField>();

            
            if (_view._fileName == "Cheque.rpt")
            {
                _paramFieldDateIssued = new ParameterField();
                _paramValDateIssued = new ParameterDiscreteValue();

                _paramFieldDateIssued.ParameterFieldName = "@DateIssued";
                _paramValDateIssued.Value = vm.DateIssued;
                _paramFieldDateIssued.CurrentValues.Add(_paramValDateIssued);
                _view.listParameterField.Add(_paramFieldDateIssued);

                _paramFieldPayee = new ParameterField();
                _paramValPayee = new ParameterDiscreteValue();

                _paramFieldPayee.ParameterFieldName = "@Payee";
                _paramValPayee.Value = vm.Payee;
                _paramFieldPayee.CurrentValues.Add(_paramValPayee);
                _view.listParameterField.Add(_paramFieldPayee);

                _paramFieldAmount = new ParameterField();
                _paramValAmount = new ParameterDiscreteValue();

                _paramFieldAmount.ParameterFieldName = "@Amount";
                _paramValAmount.Value = vm.Amount;
                _paramFieldAmount.CurrentValues.Add(_paramValAmount);
                _view.listParameterField.Add(_paramFieldAmount);

                _paramFieldAmountInWords = new ParameterField();
                _paramValAmountInWords = new ParameterDiscreteValue();

                _paramFieldAmountInWords.ParameterFieldName = "@AmountInWords";
                _paramValAmountInWords.Value = vm.AmountInWords;
                _paramFieldAmountInWords.CurrentValues.Add(_paramValAmountInWords);
                _view.listParameterField.Add(_paramFieldAmountInWords);
            }
        }

        #endregion

        #region Common

        //Read
        public void Load()
        {
            //Load(Library.StoredProcedures.Transactions.Report.Read);
        }

        #endregion

        #endregion
    }
}
