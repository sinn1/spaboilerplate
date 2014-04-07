using System;

namespace SPABoilerplate.DAL.Common
{
    public class DataAccessException : Exception
    {
        public DataAccessError Error { get; private set; }

        public DataAccessException(DataAccessError error) 
            : base(error.ToString())
        {
            Error = error;
        }

        public DataAccessException(DataAccessError error, string message) 
            : base(message)
        {
            Error = error;
        }
    }
}
