using System.Collections.Generic;
using common;
using CrystalDecisions.Shared;

namespace interfaces
{
    public interface IReport : IBaseTransactions
	{
        long _id { get; set; }

        string _reportName { get; set; }

        string _fileName { get; set; }

        string _reportPath { get; set; }

        List<ParameterField> listParameterField { get; set; }

        EnumFormMode _formMode_ReportViewer { get; set; }
	}
}
