using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Exceptions
{
    public class CustomException : Exception
    {
        private string ExMessage { get; set; }
        public CustomException() : base() { }
        public CustomException(string message) : base()
        {
            ExMessage = message;
        }
        public override string Message
        {
            get
            {
                return ExMessage;
            }
        }
        public override string StackTrace
        {
            get
            {
                return "";
            }
        }
    }
}
