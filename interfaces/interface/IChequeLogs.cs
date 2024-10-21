using System;
using System.Collections.Generic;
using viewModel;

namespace interfaces
{
	public interface IChequeLogs
	{
	    void SaveChequeLogs(ChequeLogsViewModel vm);

	    List<ChequeLogsViewModel> GetChequeLogsByDateRange(string searchString, DateTime dateFrom, DateTime dateTo);
	}
}