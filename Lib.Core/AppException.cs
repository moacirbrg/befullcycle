using System;

namespace Lib.Core
{
    public class AppException : Exception
    {
        public AppStatus Status { get; }

        public AppException(AppStatus status, string message = null, Exception inner = null) : base(message, inner)
        {
            Status = status;
        }
    }
}