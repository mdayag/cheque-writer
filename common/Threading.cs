using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace common
{
    public class Threading
    {
        private Form currform;
        private BackgroundWorker _bgworker;
        private delegate void MethodToCall();

        private Form _frmloading;
        private MethodToCall _mydelegate;
        private readonly List<Action> _myactionlist;

        public Threading(Form frm, List<Action> _action, Form frmloading)
        {
            currform = frm;
            _myactionlist = _action;
            _frmloading = frmloading;
            _bgworker = new BackgroundWorker();
            _bgworker.WorkerSupportsCancellation = true;

            _bgworker.DoWork += new DoWorkEventHandler(DoThis);
            _bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
        }

        private void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            //Thread.Sleep(1000);
            try
            {
                if (_frmloading.InvokeRequired)
                {
                    MethodInvoker _myinv = new MethodInvoker(_frmloading.Dispose);
                    _frmloading.Invoke(_myinv);
                }
                else
                {
                    _frmloading.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void ProcessNow()
        {
            _bgworker.RunWorkerAsync();
        }

        private void DoThis(object sender, DoWorkEventArgs e)
        {
            Thread t = new Thread(LoadPop);
            t.Start();
            Thread.Sleep(1000);

            foreach (Action _action in _myactionlist)
            {
                try
                {
                    _mydelegate = new MethodToCall(_action);
                    //if (currform.InvokeRequired)
                    //{
                    //    currform.Invoke(_mydelegate);
                    //}
                    //else
                    //{
                    //    _mydelegate.Invoke();
                    //}

                    currform.Invoke(_mydelegate);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void LoadPop()
        {
            try
            {
                _frmloading.ShowDialog();
                _bgworker.CancelAsync();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
