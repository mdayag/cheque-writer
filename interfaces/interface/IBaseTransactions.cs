using System.Data;

namespace interfaces
{
	public interface IBaseTransactions
	{
        string _formName { get; set; }

        bool _showNewEntry { set; }

        DataTable _dt { get; set; }

        string _message { get; set; }
	}
}
