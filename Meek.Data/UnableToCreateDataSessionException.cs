using System;

namespace Meek.Data
{
    public class UnableToCreateDataSessionException : Exception
    {
        private const string MESSAGE = "Unable to Create DataSession";
        
        public override string Message
        {
            get { return MESSAGE; }
        }
    }
}