using System;

namespace Meek.Business
{
    public class UnableToCreateBusinessLogicException : Exception
    {
        private const string MESSAGE = "Unable to create Business Logic";
        
        public override string Message
        {
            get { return MESSAGE; }
        }
    }
}