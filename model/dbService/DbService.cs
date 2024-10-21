using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common;

namespace model
{
    public class DbService
    {
        #region Members

        public static DbService NewInstance;
        private SQLDataObjects SQLDataObj;
        private readonly DbService ParameterTableEntity;
        private readonly Connections connections;
        private string ConnString;
        public string UnknownField = "";
        private GenericsClass genericClass = new GenericsClass();

        //private DataTable dTable;
        public event EventHandler<ErrorEventArgs> ErrorOccuredEvent; //Declare public "ErrorOccured" EvenHandler        

        #endregion

        #region Constructor

        public DbService()
        {
            //ParameterTableEntity = new m();
            connections = new Connections();
            ConnString = connections.SQLConnString();

        }

        //Create a new instance within this level
        public static DbService fxnCreateInstance()
        {
            NewInstance = new DbService();
            //returns new instance to subsystem
            return NewInstance;
        }

        #endregion

        #region Event Handler

        protected virtual void OnRaiseErrorOccuredEvent(object sender, ErrorEventArgs e)
            //Always call this in raising ErrorOccuredEvent
        {
            // Make a temporary copy of the event to avoid possibility of a subtle bug 
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<ErrorEventArgs> handler = ErrorOccuredEvent;
            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        #endregion

        #region Utilities

        private List<string> GetSPParameters(string StoredProcedure)
        {
            List<string> listParam = new List<string>();

            try
            {
                SQLDataObj = new SQLDataObjects("sproc_SYS_Parameters_Retrieve", ConnString, SqlCommandType.StoredProcedure);
                SQLDataObj.AddParams("@StoredProcedure", @StoredProcedure);

                using (SqlDataReader reader = SQLDataObj.GetDataReader())
                {
                    while (reader.Read())
                        listParam.Add(reader.GetString(0));

                    return listParam;
                }
            }

            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }

            return listParam;
        }

        #endregion

        #region Read

        public List<T> ListReturn<T>(string StoredProcedure, T model) where T : new()
        {
            List<T> list = new List<T>();
            try
            {
                List<string> listParam = GetSPParameters(StoredProcedure);
                SQLDataObj = new SQLDataObjects(StoredProcedure, ConnString, SqlCommandType.StoredProcedure);


                foreach (string item in listParam)
                    try
                    {
                        SQLDataObj.AddParams(item,
                                             model.GetType().GetProperty(item.Substring(1, item.Length - 1)).GetValue(
                                                 model, null));
                    }
                    catch (Exception ex)
                    {
                        UnknownField = item;
                    }

                using (SqlDataReader reader = SQLDataObj.GetDataReader())
                {
                    while (reader.Read())
                        list.Add(genericClass.ConvertToModel<T>(model, reader));

                    return list;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }

            return list;
        }

        public DataTable DataTableReturn<T>(string StoredProcedure, T model) where T : new()
        {
            DataTable dt = new DataTable();

            try
            {
                List<string> listParam = GetSPParameters(StoredProcedure);
                SQLDataObj = new SQLDataObjects(StoredProcedure, ConnString, SqlCommandType.StoredProcedure);

                //if (model == null)
                //{
                foreach (string item in listParam)
                    try
                    {
                        SQLDataObj.AddParams(item,
                                             model.GetType().GetProperty(item.Substring(1, item.Length - 1)).GetValue(
                                                 model, null));
                    }
                    catch (Exception ex)
                    {
                        UnknownField = item;
                    }
                //}

                using (dt = SQLDataObj.GetDataTable())
                {
                    return dt;
                }
            }

            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }

            return dt;
        }

        public DataTable DataTableReturn(string StoredProcedure)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLDataObj = new SQLDataObjects(StoredProcedure, ConnString, SqlCommandType.StoredProcedure);

                using (dt = SQLDataObj.GetDataTable())
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }

            return dt;
        }

        public void ExecuteQuery(string StoredProcedure)
        {
            try
            {
                SQLDataObj = new SQLDataObjects(StoredProcedure, ConnString, SqlCommandType.StoredProcedure);
                SQLDataObj.ExecuteQuery();
            }
            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
        }

        #endregion

        #region Insert / Update / Delete

        public long LongReturn<T>(string StoredProcedure, T model) where T : new()
        {
            long id = 0;
            string error = "";

            try
            {
                List<string> listParam = GetSPParameters(StoredProcedure);

                SQLDataObj = new SQLDataObjects(StoredProcedure, ConnString, SqlCommandType.StoredProcedure);

                foreach (string item in listParam)
                    try
                    {
                        try
                        {
                            SQLDataObj.AddParams(item,
                                                 model.GetType().GetProperty(item.Substring(1, item.Length - 1)).
                                                     GetValue(model, null));
                        }
                        catch (Exception ex)
                        {
                            Type type = typeof (T).BaseType;
                            SQLDataObj.AddParams(item,
                                                 type.GetType().GetProperty(item.Substring(1, item.Length - 1)).GetValue
                                                     (type, null));
                        }
                    }
                    catch (Exception ex)
                    {

                        if (item == "@Return")
                            SQLDataObj.AddParams("@Return", id);
                        else if (item == "@RETURN")
                            SQLDataObj.AddParams("@RETURN", id);
                        else
                            UnknownField = item;
                    }

                id = SQLDataObj.ExecuteQuery("@Return");
            }

            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                id = -1;
            }

            return id;
        }

        public long LongReturns<T>(string StoredProcedure, T model)
        {
            long id = 0;
            string error = "";

            try
            {
                List<string> listParam = GetSPParameters(StoredProcedure);

                SQLDataObj = new SQLDataObjects(StoredProcedure, ConnString, SqlCommandType.StoredProcedure);

                foreach (string item in listParam)
                    try
                    {
                        try
                        {
                            SQLDataObj.AddParams(item,
                                                 model.GetType().GetProperty(item.Substring(1, item.Length - 1)).
                                                     GetValue(model, null));
                        }
                        catch (Exception ex)
                        {
                            Type type = typeof (T).BaseType;
                            SQLDataObj.AddParams(item,
                                                 type.GetType().GetProperty(item.Substring(1, item.Length - 1)).GetValue
                                                     (type, null));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (item == "@Return")
                            SQLDataObj.AddParams("@Return", id);
                        else if (item == "@RETURN")
                            SQLDataObj.AddParams("@RETURN", id);
                        else
                            UnknownField = item;
                    }

                id = SQLDataObj.ExecuteQuery("@Return");
            }
            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                id = -1;
            }

            return id;
        }

        #endregion
    }
}
