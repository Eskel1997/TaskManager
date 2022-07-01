using System.Net;

namespace TASKMANAGER.DB.Exceptions
{
    public partial class ErrorCode
    {
        public string Message { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }

        public ErrorCode(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public static ErrorCode NotFound => new ErrorCode("Not Found", HttpStatusCode.NotFound);
        public static ErrorCode Unauthorized => new ErrorCode("Unauthorized", HttpStatusCode.Unauthorized);
        public static ErrorCode BadRequest => new ErrorCode("Bad Request", HttpStatusCode.BadRequest);
        public static ErrorCode NoPermission => new ErrorCode("No Permission", HttpStatusCode.Forbidden);
        public static ErrorCode IncorrectAuthCredentials => new ErrorCode("Incorrect username or password", HttpStatusCode.BadRequest);
        public static ErrorCode EntityExist => new ErrorCode("This relation already exist",HttpStatusCode.BadRequest);
    }
}
