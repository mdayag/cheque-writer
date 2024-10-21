using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace model
{
    public class SQLDataObjects
    {

        private Hashtable _arguments = new Hashtable();
        private string _querystring;
        private string _connectionstring;
        private string _sqlcommandtype;

        #region "Constructor"

        public SQLDataObjects(string queryString, string connectionString)
        {
            _querystring = queryString;
            _connectionstring = connectionString;
            _sqlcommandtype = "Text";

        }

        public SQLDataObjects(string queryString, string connectionString, SqlCommandType @sqlCommandType)
        {
            _querystring = queryString;
            _connectionstring = connectionString;
            _sqlcommandtype = @sqlCommandType.ToString().Equals("") ? "Text" : @sqlCommandType.ToString();
        }

        #endregion

        #region "Methods"

        //Adds Parameter to T-SQL
        public void AddParams(string name, object val)
        {
            Remove(name);
            _arguments.Add(name, val);
        }

        //Removes Parameter to T-SQL
        public void Remove(string name)
        {
            try
            {
                _arguments.Remove(name);
            }
            catch
            {
                throw (new Exception("No such item."));
            }
        }

        //Sets Connection with Database
        private SqlConnection SetConnection()
        {
            SqlConnection cnn = new SqlConnection();

            try
            {

                cnn.ConnectionString = _connectionstring + ";Min Pool Size=5;Max Pool Size=60;Connect Timeout=2;";
                cnn.Open();

            }
            catch (Exception)
            {
                if (cnn.State != ConnectionState.Closed) cnn.Close();
                cnn.ConnectionString = _connectionstring + ";Pooling=false;Connect Timeout=45;";
                cnn.Open();
            }

            return cnn;
        }

        public DataSet GetDataSet()
        {
            SqlConnection sqlConnection = SetConnection();
            SqlCommand sqlCommand = new SqlCommand(_querystring, sqlConnection);
            DataSet dataSet = new DataSet();

            if (_sqlcommandtype != "Text")
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            //Query Params
            IDictionaryEnumerator enumInterface = _arguments.GetEnumerator();

            while (enumInterface.MoveNext())
            {
                sqlCommand.Parameters.AddWithValue(enumInterface.Key.ToString(), enumInterface.Value.ToString());
            }

            //Connect to DB and run qry
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataSet;
        }

        public DataTable GetDataTable()
        {
            SqlConnection sqlConnection = SetConnection();
            SqlCommand sqlCommand = new SqlCommand(_querystring, sqlConnection);
            DataTable dataTable = new DataTable();

            if (_sqlcommandtype != "Text")
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            IDictionaryEnumerator enumInterface = _arguments.GetEnumerator();

            while (enumInterface.MoveNext())
            {
                sqlCommand.Parameters.AddWithValue(enumInterface.Key.ToString(), enumInterface.Value);
            }

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataTable;
        }

        public SqlDataReader GetDataReader()
        {
            SqlDataReader sqlDataReader;
            SqlConnection sqlConnection = SetConnection();
            SqlCommand sqlCommand = new SqlCommand(_querystring, sqlConnection);

            if (_sqlcommandtype != "Text")
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }

            IDictionaryEnumerator enumInterface = _arguments.GetEnumerator();

            while (enumInterface.MoveNext())
            {
                sqlCommand.Parameters.AddWithValue(enumInterface.Key.ToString(), enumInterface.Value.ToString());
            }

            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sqlDataReader;
        }

        public bool ExecuteQuery()
        {
            using (SqlConnection sqlconnection = SetConnection())
            {
                using (SqlCommand sqlcommand = new SqlCommand(_querystring, sqlconnection))
                {
                    bool issuccess = false;

                    if (!_sqlcommandtype.Equals("Text"))
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                    //Connect to the database and run the query.
                    //SqlCommand sqlcommand = new SqlCommand(_querystring, sqlconnection);
                    //Adds query parameters.
                    sqlcommand.CommandTimeout = 0;
                    IDictionaryEnumerator enumInterface = _arguments.GetEnumerator();

                    while (enumInterface.MoveNext())
                    {
                        sqlcommand.Parameters.AddWithValue(enumInterface.Key.ToString(), enumInterface.Value);
                    }

                    try
                    {
                        //sqlcommand.Connection.Open();
                        sqlcommand.ExecuteNonQuery();
                        issuccess = true;
                    }
                    catch (Exception ex)
                    {
                        issuccess = false;
                        throw ex;
                    }

                    return issuccess;
                }
            }
        }

        public string ExecuteQuery(string outputfield, int size)
        {
            string output;

            try
            {
                SqlConnection sqlconnection = SetConnection();
                SqlCommand sqlcommand = new SqlCommand(_querystring, sqlconnection);

                if (!_sqlcommandtype.Equals("Text"))
                    sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.CommandTimeout = 0;
                IDictionaryEnumerator enumInterface = _arguments.GetEnumerator();

                while (enumInterface.MoveNext())
                {
                    sqlcommand.Parameters.AddWithValue(enumInterface.Key.ToString(), enumInterface.Value);
                }

                sqlcommand.Parameters[outputfield].Direction = ParameterDirection.Output;
                sqlcommand.Parameters[outputfield].Size = size;

                sqlcommand.ExecuteNonQuery();

                output = sqlcommand.Parameters[outputfield].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }

        public long ExecuteQuery(string outputfield)
        {
            long output;

            try
            {
                SqlConnection sqlconnection = SetConnection();
                SqlCommand sqlcommand = new SqlCommand(_querystring, sqlconnection);

                if (!_sqlcommandtype.Equals("Text"))
                    sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.CommandTimeout = 0;
                IDictionaryEnumerator enumInterface = _arguments.GetEnumerator();

                while (enumInterface.MoveNext())
                {
                    sqlcommand.Parameters.AddWithValue(enumInterface.Key.ToString(), enumInterface.Value);
                }

                sqlcommand.Parameters[outputfield].Direction = ParameterDirection.Output;
                sqlcommand.Parameters[outputfield].Size = 36;
                sqlcommand.ExecuteNonQuery();

                output = Convert.ToInt64(sqlcommand.Parameters[outputfield].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }

        #endregion
    }
}
