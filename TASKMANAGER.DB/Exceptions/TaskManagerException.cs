using System;

namespace TASKMANAGER.DB.Exceptions
{
    public class TaskManagerException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public TaskManagerException(ErrorCode errorCode)
            : this(errorCode, string.Empty)
        {
        }

        public TaskManagerException(ErrorCode errorCode, string message) : base(message, null)
        {
            ErrorCode = errorCode;
        }
    }
}
