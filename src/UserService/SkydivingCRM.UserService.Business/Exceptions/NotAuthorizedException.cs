using System;

namespace SkydivingCRM.UserService.Business.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string message) : base(message)
        {
        }
    }
}