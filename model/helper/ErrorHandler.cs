using System;
using System.Diagnostics;

namespace model
{
    public class ErrorHandler
    {
        public static void Handle(Exception applicationException)
        {
            try
            {
                ErrorLog(applicationException.Message, applicationException.StackTrace);
                return;
            }
            catch
            {
                //Throw applicationException
            }
        }

        private static void ErrorLog(string messageException, string sourceException)
        {
            string errDirectoryPath = null;
            string Filename = null;

            //errDirectoryPath = System.IO.Directory.GetCurrentDirectory() + "\ACMErrorDirectory\"
            errDirectoryPath = "D:\\ErrorDirectory\\";
            Filename = errDirectoryPath + "ErrorLogFile";

            if (System.IO.Directory.Exists(errDirectoryPath))
            {
                WriteErrorToFile(messageException, sourceException, Filename);
            }
            else
            {
                //Create Path and file if not exists.
                System.IO.Directory.CreateDirectory(errDirectoryPath);
                WriteErrorToFile(messageException, sourceException, Filename);
            }
        }

        private static void WriteErrorToFile(string messageException, string sourceException, string filename)
        {
            System.IO.StreamWriter ErrorStreamWriter = default(System.IO.StreamWriter);

            if (!System.IO.File.Exists(filename))
            {
                ErrorStreamWriter = System.IO.File.CreateText(filename);
                ErrorStreamWriter.WriteLine("Begin ///////////////////// Begin");
                ErrorStreamWriter.Close();
                ErrorStreamWriter = System.IO.File.AppendText(filename);
                //string test =  
                ErrorStreamWriter.WriteLine("Datetime of error encountered : " + System.DateTime.Now.ToString("u"));
                ErrorStreamWriter.WriteLine("Error message : " + messageException);

                try
                {
                    ErrorStreamWriter.WriteLine("Error source : " + sourceException.Substring(sourceException.IndexOf("PC2"), sourceException.Length - sourceException.IndexOf("PC2")));
                }
                catch
                {
                    ErrorStreamWriter.WriteLine("Error source : " + sourceException.ToString());
                }

                ErrorStreamWriter.WriteLine("End   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ End");
                ErrorStreamWriter.Close();
            }
            else
            {
                ErrorStreamWriter = System.IO.File.AppendText(filename);
                ErrorStreamWriter.WriteLine("Begin ///////////////////// Begin");
                ErrorStreamWriter.WriteLine("Datetime of error encountered : " + DateTime.Today.ToString("u"));
                ErrorStreamWriter.WriteLine("Error message : " + messageException);

                try
                {
                    ErrorStreamWriter.WriteLine("Error source : " + sourceException.Substring(sourceException.IndexOf("PC2"), sourceException.Length - sourceException.IndexOf("PC2")));
                }
                catch
                {
                    ErrorStreamWriter.WriteLine("Error source : " + sourceException.ToString());
                }

                ErrorStreamWriter.WriteLine("End   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ End");
                ErrorStreamWriter.Close();
            }
        }

        private static bool WriteToEventLog(string Entry)
        {
            EventLog objEventLog = new EventLog();
            string AppName = "TIP";
            EventLogEntryType EventType = EventLogEntryType.Error;
            string LogName = "TIP";

            try
            {
                //Register the App as an Event Source
                if (!EventLog.SourceExists(AppName))
                {
                    EventLog.CreateEventSource(AppName, LogName);
                }
                objEventLog.Source = AppName;
                //WriteEntry is overloaded; this is one of 10 ways to call it
                objEventLog.WriteEntry(Entry, EventType);
                return true;
            }
            catch (Exception Ex)
            {
                ErrorLog(Ex.Message.ToString(), Ex.StackTrace.ToString());
                return false;
            }
        }
    }
}
