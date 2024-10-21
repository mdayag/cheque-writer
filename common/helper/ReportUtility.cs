using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using PaperSize = CrystalDecisions.Shared.PaperSize;

namespace common
{
    public class ReportUtility
    {
        #region Declaration

        private CrystalReportViewer cRViewer;
        private ReportDocument rptDoc;
        private ConnectionInfo myConInfo;
        private String rptPath;
        private bool _isReceiptPrint = false;
        private int rawKind = 0;
        private int printCopies = 0;
        string papername;

        TableLogOnInfos crtableLogoninfos;
        TableLogOnInfo crtableLogoninfo;
        Tables CrTables;

        private DataTable _dT;
        private SqlConnection _con;
        private SqlCommand _com;
        private SqlDataAdapter _dA;
        private string _myreportname;
        #endregion

        public ReportUtility(CrystalReportViewer crystalReportViewer)
        {
            cRViewer = crystalReportViewer;
            cRViewer.ShowRefreshButton = false;
            cRViewer.ShowTextSearchButton = false;
            cRViewer.ShowGroupTreeButton = false;
            myConInfo = new ConnectionInfo();
            rptDoc = new ReportDocument();
            crtableLogoninfos = new TableLogOnInfos();
            crtableLogoninfo = new TableLogOnInfo();
        }

        public void setPrintNumOfCopies(int numOfCopies)
        {
            printCopies = numOfCopies;
        }

        public void ReportsView(string reportName, string reportPath, List<ParameterField> parameters)
        {
            try
            {
                rptPath = reportPath + "\\";
                rptDoc.Load(reportPath + "\\" + reportName);
                _myreportname = reportName;

                ParameterFields crParams = new ParameterFields();

                foreach (ParameterField parameterField in parameters)
                {
                    crParams.Add(parameterField);

                    ParameterValues currentValues = parameterField.CurrentValues;
                    ParameterDiscreteValue discreteValue = (ParameterDiscreteValue)currentValues[0];
                    object value = discreteValue.Value;
                    rptDoc.SetParameterValue(parameterField.Name, value);
                }

                cRViewer.ParameterFieldInfo = crParams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReportsView(string reportName, string reportPath, List<ParameterField> parameters, bool isReceipt)
        {
            try
            {
                rptPath = reportPath + "\\";
                rptDoc.Load(reportPath + "\\" + reportName);
                _myreportname = reportName;
                ParameterFields crParams = new ParameterFields();

                foreach (ParameterField parameterField in parameters)
                {
                    crParams.Add(parameterField);

                    ParameterValues currentValues = parameterField.CurrentValues;
                    ParameterDiscreteValue discreteValue = (ParameterDiscreteValue)currentValues[0];
                    object value = discreteValue.Value;
                    rptDoc.SetParameterValue(parameterField.Name, value);
                }

                cRViewer.ParameterFieldInfo = crParams;

                cRViewer.ToolPanelView = ToolPanelViewType.None;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _isReceiptPrint = isReceipt;
        }

        public void ReportsView(string reportName, string reportPath, string reportQry, string connectionString)
        {
            rptPath = reportPath;
            rptDoc.Load(rptPath);
            rptDoc.SetDataSource(GenerateDataTable(reportQry, connectionString));
            _myreportname = reportName;
        }

        public void LogonReport()
        {
            try
            {
                myConInfo.AllowCustomConnection = true;
                CrTables = rptDoc.Database.Tables;

                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = myConInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                if (_isReceiptPrint)
                {
                    if (_myreportname == "Cheque.rpt")
                    {
                        papername = Convert.ToString(PaperSize.PaperLetter);
                        printReport();
                    }
                    else
                    {
                        papername = Convert.ToString(PaperSize.PaperLetter);
                        printReport();
                    }
                }
                else
                {
                    if (_myreportname == "Cheque.rpt")
                    {
                        papername = Convert.ToString(PaperSize.PaperLetter);
                    }

                    cRViewer.ReportSource = rptDoc;
                    cRViewer.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogonReport(string serverName, string databaseName, string userName, string password)
        {
            try
            {
                myConInfo.AllowCustomConnection = true;
                myConInfo.ServerName = serverName;
                myConInfo.DatabaseName = databaseName;
                myConInfo.UserID = userName;
                myConInfo.Password = password;
                CrTables = rptDoc.Database.Tables;

                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = myConInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                if (_isReceiptPrint)
                {
                    if (_myreportname == "SalesReceipt.rpt")
                    {
                        papername = Convert.ToString(PaperSize.PaperLegal);
                        printReport();
                    }
                    else
                    {
                        if (printCopies == 0)
                        {
                            rptDoc.PrintToPrinter(1, false, 0, 0);
                        }
                        else
                        {
                            rptDoc.PrintToPrinter(printCopies, false, 0, 0);
                        }

                        cRViewer.ReportSource = rptDoc;
                        cRViewer.Refresh();
                    }
                }
                else
                {
                    cRViewer.ReportSource = rptDoc;
                    cRViewer.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogonReportExport(string serverName, string databaseName, string userName, string password)
        {
            try
            {
                myConInfo.AllowCustomConnection = true;
                myConInfo.ServerName = serverName;
                myConInfo.DatabaseName = databaseName;
                myConInfo.UserID = userName;
                myConInfo.Password = password;
                CrTables = rptDoc.Database.Tables;

                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = myConInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                string _dir = Application.StartupPath;
                string _fileName = _myreportname.Substring(0, _myreportname.Length - 3) + "pdf";

                string _exportPath = _dir + @"\" + _fileName;

                foreach (var process in Process.GetProcessesByName("Acrobat"))
                {
                    if (process.MainWindowTitle.Contains(_fileName))
                        process.Kill();
                }

                rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, _exportPath);

                Process.Start(_exportPath);

                rptDoc.Close();
                rptDoc.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void printReport()
        {
            PrintDocument printDoc = new PrintDocument();
            PaperSize pkSize = new PaperSize();
            int i;

            for (i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                if (printDoc.PrinterSettings.PaperSizes[i].PaperName == papername)
                {
                    rawKind = (int)GetField(printDoc.PrinterSettings.PaperSizes[i], "kind");
                }
            }

            cRViewer.ReportSource = rptDoc;
            cRViewer.Refresh();

            rptDoc.PrintOptions.PaperSize = (PaperSize)rawKind;

            if (printCopies == 0)
            {
                rptDoc.PrintToPrinter(1, false, 0, 0);
            }
            else
            {
                rptDoc.PrintToPrinter(printCopies, false, 0, 0);
            }

            cRViewer.Dispose();
        }

        private void viewCustomizedReport()
        {
            PrintDocument printDoc = new PrintDocument();
            PaperSize pkSize = new PaperSize();
            int i;

            for (i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                if (printDoc.PrinterSettings.PaperSizes[i].PaperName == papername)
                {
                    rawKind = (int)GetField(printDoc.PrinterSettings.PaperSizes[i], "kind");
                }
            }

            cRViewer.ReportSource = rptDoc;
            cRViewer.Refresh();
            rptDoc.PrintOptions.PaperSize = (PaperSize)rawKind;
        }

        private object GetField(Object obj, String fieldName)
        {
            FieldInfo fi = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            return fi.GetValue(obj);
        }

        private DataTable GenerateDataTable(string reportQry, string connectionString)
        {
            _con = new SqlConnection(connectionString);
            _com = new SqlCommand(reportQry, _con);

            try
            {
                _con.Open();
                _com.CommandType = CommandType.Text;
                _dA = new SqlDataAdapter(_com);
                _dT = new DataTable();
                _dA.Fill(_dT);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _dT;
        }
    }
}
