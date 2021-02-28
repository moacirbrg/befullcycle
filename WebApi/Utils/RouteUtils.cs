using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Core;
using Lib.Utils.Validators;
using Microsoft.AspNetCore.Http;
using WebApi.Models;

namespace WebApi.Utils
{
    public static class RouteUtils
    {
        private static readonly ConcurrentDictionary<string, JsonSerializerOptions> RoutesSerializeOptions =
            new ConcurrentDictionary<string, JsonSerializerOptions>();

        public static async Task ExecuteRoute<T>(HttpContext httpContext, Func<Task<T>> route)
        {
            try
            {
                T result = await route();
                await Response<object>(httpContext, AppStatus.Ok, result);
            }
            catch (AppException ex)
            {
                Console.WriteLine($"Status: {ex.Status}, Data: {ex.Message}. Stack: {ex.StackTrace}");
                AppStatus status = AppStatusUtils.ConvertToPublicStatus(ex.Status);
                await Response<object>(httpContext, status, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}. Stack: {ex.StackTrace}");
                await Response<object>(httpContext, AppStatus.Error, null);
            }
        }

        public static async Task<T> GetValidatedPayload<T>(HttpContext httpContext, string routeName, Func<Validator[]> onFirstValidation)
        {
            JsonSerializerOptions options;
            
            if (!RoutesSerializeOptions.ContainsKey(routeName))
            {
                Validator[] validators = onFirstValidation();

                options = new JsonSerializerOptions();
                options.Converters.Add(new ValidationConverter<T>(validators));

                if (!RoutesSerializeOptions.TryAdd(routeName, options))
                {
                    options = RoutesSerializeOptions[routeName];                    
                }
            }
            else
            {
                options = RoutesSerializeOptions[routeName];
            }

            return await AspnetUtils.GetPayload<T>(httpContext, options);
        }

        private static async Task Response<T>(HttpContext httpContext, AppStatus status, T data)
        {
            var result = new AppResult<T> {Status = status, Data = data};
            string serialized = JsonSerializer.Serialize(result);
            await AspnetUtils.ResponseOk(httpContext, serialized);
        }
    }
}