using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validation
{
  public  class CustomException:Exception
    {
        private static readonly string DefaultMessage = "Custom exception was thrown.";

        public CustomException() : base(DefaultMessage)
        {

        }

        public CustomException(string message):base(message)
        {

        }
    }
}
