using System;

namespace viewModel
{
    public class ChequeLogsViewModel
    {
        public int BankId { get; set; }

        public string Bank { get; set; }

        public string ChequeNumber { get; set; }

        public string Brstn { get; set; }

        public DateTime DateIssued { get; set; }

        public string Payee { get; set; }

        public decimal Amount { get; set; }

        public string AmountInWords { get; set; }
    }
}
