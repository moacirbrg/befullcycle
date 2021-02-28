using Lib.Core;

namespace WebApi.Models
{
    public class AppResult<T>
    {
        public AppStatus Status { get; set; }
        public T Data { get; set; }
    }
}