using System;

namespace model
{
    public class ErrorEventArgs : EventArgs
    {
        private Exception m_Exception;

        public ErrorEventArgs(Exception exception)
        {
            m_Exception = exception;
        }

        public Exception Exception
        {
            get { return m_Exception; }
            set { m_Exception = value; }
        }
    }
}
