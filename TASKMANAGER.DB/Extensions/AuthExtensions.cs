using System;
using System.Security.Claims;
using TASKMANAGER.DB.Exceptions;

namespace TASKMANAGER.DB.Extensions
{
    public static class AuthExtensions
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            var id = principal.Identity.Name;

            if (string.IsNullOrEmpty(id))
            {
                throw new TaskManagerException(ErrorCode.IncorrectAuthCredentials);
            }

            return Convert.ToInt64(id);
        }
    }
}
