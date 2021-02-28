using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApi.Utils;

namespace WebApi.Routes
{
    public class SampleRoutes
    {
        public static async Task GetHelloWorld(HttpContext httpContext)
        {
            await RouteUtils.ExecuteRoute<string>(httpContext, async () =>
            {
                return await Task.FromResult("Hello World");
            });
        }
    }
}