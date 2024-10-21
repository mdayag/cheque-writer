using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using common;
using interfaces;
using model;

namespace presenter
{
    public abstract class BasePresenterTransactions<M, V> where M : TransactionBaseModel, new() where V : IBaseTransactions
    {
        #region Members

        public abstract DbService DbService
        {
            get;
        }

        public abstract GenericsClass GenericUtilities
        {
            get;
        }

        public abstract EnumFormMode FormMode
        {
            get;
            set;
        }

        public abstract long Id
        {
            get;
            set;
        }

        public abstract V View
        {
            get;
            set;
        }

        public abstract bool ViewShown
        {
            get;
            set;
        }

        public abstract M Model
        {
            get;
            set;
        }

        public abstract List<M> ListModel { get; set; }

        public delegate void Read();

        public Read InitilizeLookUp;

        public Read LoadAllData;

        public Read LoadAllDataData;

        public Read LoadThread;

        public delegate void Reada(bool c);

        public Reada LoadAll;

        public bool _cndFormLoad = false;

        public int _rowIndex;
        public int _pageTotal;

        public long temp;

        public DataTable _dtMscREceipt;

        //For Paging

        public DataGridUtility _dtgUtil = new DataGridUtility();

        public int _curPage = 1;

        public DataTable _dataTableClone = new DataTable();

        public DataTable _workingTableClone = new DataTable();

        //===========================

        #endregion

        #region Constructors

        #endregion

        #region Create

        public void Insert(string StoredProcedure)
        {
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    Id = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(Id);

                    if (Id > 0)
                    {
                        FormMode = EnumFormMode.Edit;
                        View._showNewEntry = Utilities.ConfirmNewEntry(View._message);
                    }
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void Insert<T>(string StoredProcedure, T model)
        {
            try
            {
                if (GenericUtilities.IsValid(model, View))
                {
                    Id = DbService.LongReturns(StoredProcedure, model);
                    View._message = Utilities.Result(Id);

                    if (Id > 0)
                    {
                        FormMode = EnumFormMode.Edit;
                        View._showNewEntry = Utilities.ConfirmNewEntry(View._message);
                    }
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void InsertWithPrompt(string StoredProcedure)
        {
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    Id = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(Id);

                    if (Id > 0)
                    {
                        FormMode = EnumFormMode.Edit;
                        View._showNewEntry = Utilities.ConfirmNewEntry(View._message);
                    }
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void InsertNoPrompt(string StoredProcedure)
        {
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    Id = DbService.LongReturn(StoredProcedure, Model);
                    FormMode = EnumFormMode.Edit;
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void InsertNoPromptTemplate(string StoredProcedure)
        {
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    DbService.LongReturn(StoredProcedure, Model);
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public int InsertWithErrorValidation(string StoredProcedure)
        {
            int iReturn = 0;

            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    Id = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(Id);

                    if (Id != 0)
                    {
                        FormMode = EnumFormMode.New;
                        View._showNewEntry = Utilities.ConfirmNewEntry(View._message);
                        iReturn = 1;
                    }
                    else
                    {
                        iReturn = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                iReturn = 0;
                View._message = ex.Message;
            }
            return iReturn;
        }

        #endregion

        #region Read

        public void Load(string StoredProcedure)
        {
            try
            {
                _dataTableClone = DbService.DataTableReturn(StoredProcedure);

                View._dt = _dtgUtil.SetPageData(_dataTableClone, _curPage);

                ViewShown = true;
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void Load(string StoredProcedure, bool isWithParam)
        {
            try
            {
                View._dt = DbService.DataTableReturn(StoredProcedure, Model);

                ViewShown = true;
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public DataTable LoadNoEntry(string StoredProcedure)
        {
            try
            {
                return DbService.DataTableReturn(StoredProcedure, Model);
            }
            catch (Exception ex)
            {
                View._message = ex.Message;

                return null;
            }
        }

        public void LoadList()
        {
            try
            {
                GenericUtilities.ConvertToList(ListModel, View._dt);
            }
            catch (Exception ex) { }
        }

        public void LoadEntry(V view, V viewParent)
        {
            try
            {
                this.View = view;

                if (InitilizeLookUp != null)
                {
                    _cndFormLoad = false;

                    InitilizeLookUp();
                }

                _cndFormLoad = true;
                GenericUtilities.PassView(View, viewParent);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Update

        public void Update(string StoredProcedure)
        {
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    temp = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(temp);

                    if (temp > 0) View._showNewEntry = Utilities.ConfirmNewEntry(View._message);
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void UpdateNoPrompt(string StoredProcedure)
        {
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    temp = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(temp);
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public int UpdateWithErrorValidation(string StoredProcedure)
        {
            int iReturn = 0;
            try
            {
                if (GenericUtilities.IsValid(Model, View))
                {
                    Id = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(Id);

                    if (Id == 1)
                    {
                        //FormMode = EnumFormMode.New;
                        //View._showNewEntry = Helper.Utilities.ConfirmNewEntry(View._message);
                        View._showNewEntry = false;
                        iReturn = 1;
                    }
                    else
                    {
                        iReturn = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                iReturn = 0;
                View._message = ex.Message;
            }
            return iReturn;
        }

        #endregion

        #region Delete

        public void Delete(string StoredProcedure)
        {
            try
            {
                if (Utilities.ConfirmDelete())
                {
                    temp = DbService.LongReturn(StoredProcedure, Model);
                    View._message = Utilities.Result(temp);
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void Delete<T>(string StoredProcedure, T model)
        {
            try
            {
                if (Utilities.ConfirmDelete() == true)
                {
                    temp = DbService.LongReturns(StoredProcedure, model);
                    View._message = Utilities.Result(temp);
                }
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        public void DeleteNoPrompt(string StoredProcedure)
        {
            try
            {
                temp = DbService.LongReturn(StoredProcedure, Model);
                View._message = Utilities.Result(temp);
            }
            catch (Exception ex)
            {
                View._message = ex.Message;
            }
        }

        #endregion

        #region Functions

        public void ConverViewToModel()
        {
            this.Model = new M();
        }

        public void CloseEntry(V parent)
        {
            if (parent != null)
            {
                View = parent;
                if (LoadAllData != null) LoadAllData();
            }

        }

        public void CloseEntryNew(V parent)
        {
            if (parent != null)
            {
                View = parent;

                if (LoadAll != null)
                {
                    LoadAll(false);
                }
            }
        }

        #endregion

        #region Addins

        public void ProcessMethod(Form frmload, Form _current, List<Action> _action)
        {
            Threading t = new Threading(_current, _action, frmload);
            t.ProcessNow();
        }

        #endregion
    }
}
