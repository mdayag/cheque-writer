using System.Configuration;

namespace model
{
    public class Connections
    {
        private ConnectionStringSettings SQLConnection()
        {
            if (ConfigurationManager.ConnectionStrings["NumberToWordsConnectionString"] != null)
            {
                return ConfigurationManager.ConnectionStrings["NumberToWordsConnectionString"];
            }
            return null;
        }

        public string SQLConnString()
        {
            ConnectionStringSettings connectionStringSettings = SQLConnection();
            string conStr = connectionStringSettings.ConnectionString;
            return conStr;
        }
    }
}
