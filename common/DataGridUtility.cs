using System;
using System.Data;
using System.Windows.Forms;

namespace common
{
    public class DataGridUtility
    {
        #region Members

        private ToolStripLabel _txtRec;
        private const int _maxRows = 20;

        #endregion

        #region Methods

        public DataTable SetPageData(DataTable dataTable, int pageNo)
        {
            try
            {
                if (dataTable != null)
                {
                    DataTable dt2 = dataTable.Clone();
                    int rowcnt = dataTable.Rows.Count;

                    if (rowcnt != 0)
                    {
                        int start = (pageNo * _maxRows) - _maxRows;


                        for (int i = start; i < pageNo * _maxRows; i++)
                        {
                            dt2.ImportRow(dataTable.Rows[i]);
                            if (i == rowcnt - 1)
                                break;
                        }
                    }
                    return dt2;
                }

                return null;

            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }
        }

        public void SetPagingInfo(DataTable dataTable, ToolStripLabel txtRecordNo, int CurrentPageIndex)
        {
            if (dataTable != null)
            {
                _txtRec = txtRecordNo;
                DataTable _dtg = dataTable;

                if (_dtg.Rows.Count % _maxRows > 0)
                {
                    _txtRec.Text = (CurrentPageIndex).ToString() + " of " + ((_dtg.Rows.Count / _maxRows) + 1).ToString();
                }
                else
                {
                    _txtRec.Text = (CurrentPageIndex).ToString() + " of " + ((_dtg.Rows.Count / _maxRows)).ToString();
                }
            }
        }

        public int SetCurrentPage(DataTable dataTable, ToolStripLabel txtRecordNo, int CurrentPageIndex)
        {

            int newPageIndx = 0;
            int rowcnt = 0;

            if (dataTable != null)
            {
                if (dataTable.Rows.Count % _maxRows > 0)
                {
                    rowcnt = (dataTable.Rows.Count / _maxRows) + 1;
                }
                else
                {
                    rowcnt = dataTable.Rows.Count / _maxRows;
                }

                if (CurrentPageIndex + 1 > rowcnt)
                {
                    newPageIndx = CurrentPageIndex;
                }
                else
                {
                    newPageIndx = CurrentPageIndex + 1;
                }

                SetPagingInfo(dataTable, txtRecordNo, newPageIndx);
            }

            return newPageIndx;
        }

        public int SetPreviousPage(DataTable dataTable, ToolStripLabel txtRecordNo, int CurrentPageIndex)
        {
            int newPageIndx = 0;

            if (dataTable != null)
            {
                if (CurrentPageIndex - 1 == 0)
                {
                    newPageIndx = CurrentPageIndex;
                }
                else
                {
                    newPageIndx = CurrentPageIndex - 1;
                }

                SetPagingInfo(dataTable, txtRecordNo, newPageIndx);
            }

            return newPageIndx;
        }

        public int SetMaxPage(DataTable dataTable, ToolStripLabel txtRecordNo, int CurrentPageIndex)
        {
            int newPageIndx = 0;
            int rowcnt = 0;

            if (dataTable != null)
            {
                if (dataTable.Rows.Count % _maxRows > 0)
                {
                    rowcnt = (dataTable.Rows.Count / _maxRows) + 1;
                }
                else
                {
                    rowcnt = dataTable.Rows.Count / _maxRows;
                }

                newPageIndx = rowcnt;

                SetPagingInfo(dataTable, txtRecordNo, newPageIndx);
            }

            return newPageIndx;
        }

        public int SetMinPage(DataTable dataTable, ToolStripLabel txtRecordNo, int CurrentPageIndex)
        {
            int newPageIndx = 0;

            if (dataTable != null)
            {
                SetPagingInfo(dataTable, txtRecordNo, 1);
                newPageIndx = 1;
            }

            return newPageIndx;
        }

        public int JumpToPage(DataTable dataTable, ToolStripLabel txtRecordNo, int CurrentPageIndex, int Index)
        {
            int newPageIndx = 0;
            int rowcnt = 0;

            if (dataTable != null)
            {
                if (dataTable.Rows.Count % _maxRows > 0)
                {
                    rowcnt = (dataTable.Rows.Count / _maxRows) + 1;
                }
                else
                {
                    rowcnt = dataTable.Rows.Count / _maxRows;
                }

                if (Index > rowcnt || Index < 1)
                {
                    newPageIndx = CurrentPageIndex;
                }
                else
                {
                    newPageIndx = Index;
                }

                SetPagingInfo(dataTable, txtRecordNo, newPageIndx);
            }

            return newPageIndx;
        }

        #endregion
    }
}
