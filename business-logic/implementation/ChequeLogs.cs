using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using common;
using interfaces;
using viewModel;

namespace business_logic
{
    public class ChequeLogs : IChequeLogs
    {
        public void SaveChequeLogs(ChequeLogsViewModel vm)
        {
            var dir = Path.GetDirectoryName(Application.ExecutablePath);
            dir += dir.EndsWith(@"\") ? @"ChequeLogs\" : @"\ChequeLogs\";

            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception ex)
                {
                    dir = @"C:\ChequeLogs\";
                    //in case the directory is unreachable
                    Directory.CreateDirectory(dir);
                }
            }

            string path = dir + DateTime.Now.ToString("yyyyMMdd") + ".dll";

            //This text is added only once to the file.
            if (!File.Exists(path))
            {
                //Create a file to write to.
                using (var sw = new StreamWriter(path))
                {
                    sw.WriteLine(vm.BankId + "|" + vm.Bank + "|" + vm.ChequeNumber + "|" + vm.Brstn + "|" + Convert.ToString(vm.DateIssued) + "|" + vm.Payee + "|" + Convert.ToString(vm.Amount) + "|" + vm.AmountInWords);
                }
            }
            else
            {
                //This text is always added, making the file longer over time, if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(vm.BankId + "|" + vm.Bank + "|" + vm.ChequeNumber + "|" + vm.Brstn + "|" + Convert.ToString(vm.DateIssued) + "|" + vm.Payee + "|" + Convert.ToString(vm.Amount) + "|" + vm.AmountInWords);
                }
            }
        }

        public List<ChequeLogsViewModel> GetChequeLogsByDateRange(string searchString, DateTime dateFrom, DateTime dateTo)
        {
            var dir = Path.GetDirectoryName(Application.ExecutablePath);
            dir += dir.EndsWith(@"\") ? @"ChequeLogs\" : @"\ChequeLogs\";

            if (!Directory.Exists(dir))
            {
                dir = @"C:\ChequeLogs\";
                //in case the directory is unreachable
                Directory.CreateDirectory(dir);
            }

            var dateList = new List<int>();
            var iDateFrom = Convert.ToInt32(dateFrom.ToString("yyyyMMdd"));
            var iDateTo = Convert.ToInt32(dateTo.ToString("yyyyMMdd"));
            var dateIncrementor = iDateFrom;

            while (dateIncrementor <= iDateTo)
            {
                dateList.Add(dateIncrementor);
                dateIncrementor += 1;
            }

            var list = new List<ChequeLogsViewModel>();

            foreach (var dte in dateList)
            {
                string path = dir + dte + ".dll";

                if (File.Exists(path))
                {
                    using (var f = new StreamReader(path))
                    {
                        string line = string.Empty;

                        while ((line = f.ReadLine()) != null)
                        {
                            var parts = line.Split('|');

                            if (
                                    (searchString == string.Empty || searchString == "")
                                    || 
                                    (
                                        parts[1].Contains(searchString)
                                        ||
                                        parts[2].Contains(searchString)
                                        ||
                                        parts[3].Contains(searchString)
                                        ||
                                        parts[5].Contains(searchString)
                                    )
                                )
                            {
                                var vm = new ChequeLogsViewModel
                                {
                                    BankId = Convert.ToInt32(parts[0]),
                                    Bank = Convert.ToString(parts[1]),
                                    ChequeNumber = Convert.ToString(parts[2]),
                                    Brstn = Convert.ToString(parts[3]),
                                    DateIssued = Convert.ToDateTime(parts[4]),
                                    Payee = Convert.ToString(parts[5]),
                                    Amount = Convert.ToDecimal(parts[6]),
                                    AmountInWords = Convert.ToString(parts[7])
                                };

                                list.Add(vm);
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}