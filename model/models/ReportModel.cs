namespace model
{
    public class ReportModel : TransactionBaseModel
    {
        public long Id { get; set; }

        public string ReportName { get; set; }

        public string FileName { get; set; }

        public string ReportPath { get; set; }
    }
}
