using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Utils
{
    public static class AspnetUtils
    {
        public static async Task<T> GetPayload<T>(HttpContext context, JsonSerializerOptions options = null)
        {
            try
            {
                using (StreamReader reader = new StreamReader(context.Request.Body))
                {
                    string content = await reader.ReadToEndAsync();
                    if (content == "")
                    {
                        throw new AppException(AppStatus.BadRequest, "Empty payload is not valid.");
                    }
                    return JsonSerializer.Deserialize<T>(content, options);
                }
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(AppStatus.BadRequest, ex.Message, ex);
            }
        }
        
        public static object GetRouteParam<T>(HttpContext context, string paramName)
        {
            string value = context.GetRouteValue(paramName) as string;
            
            if (value == null)
            {
                return default;   
            }

            var type = typeof(T);

            try
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Boolean: return Convert.ToBoolean(value);
                    case TypeCode.Char: return Convert.ToChar(value);
                    case TypeCode.Decimal: return Convert.ToDecimal(value);
                    case TypeCode.Double: return Convert.ToDouble(value);
                    case TypeCode.Int16: return Convert.ToInt16(value);
                    case TypeCode.Int32: return Convert.ToInt32(value);
                    case TypeCode.Int64: return Convert.ToInt64(value);
                    case TypeCode.DateTime: return Convert.ToDateTime(value);
                    default: return value;
                }
            }
            catch (Exception ex)
            {
                string message = $"Failed to cast from string to {type} using value {value}";
                throw new AppException(AppStatus.BadRequest, message, ex);
            }
        }

        public static string GetUserSession(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                return context.Request.Headers["Authorization"];   
            }

            return "";
        }

        public static async Task ResponseOk(HttpContext context, string response = "")
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            await context.Response.WriteAsync(response);
        }
        
        private static string GetRouteParam(HttpContext context, string paramName)
        {
            try
            {
                return context.GetRouteValue(paramName) as string;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}