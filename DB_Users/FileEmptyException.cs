using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Users
{
    class FileEmptyException : Exception
    {
        private string _message;
        public override string Message { get => _message; }

        public FileEmptyException()
        {
            _message = "File empty";
        }

        public FileEmptyException(string message)
        {
            _message = message;
        }
    }
}
