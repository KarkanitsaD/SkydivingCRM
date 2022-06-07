using System;

namespace SkydivingCRM.UserService.Business.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string message) : base(message)
        {
        }
    }
}