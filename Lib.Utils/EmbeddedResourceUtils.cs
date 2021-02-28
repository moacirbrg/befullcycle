using System;
using System.IO;
using System.Reflection;
using Lib.Core;

namespace Lib.Utils
{
    public static class EmbeddedResourceUtils
    {
        public static string GetEmbeddedResourceAsString(Type type, string path)
        {
            try
            {
                using Stream stream = GetEmbeddedResourceAsStream(type, path);
                using var reader = new StreamReader(stream);
                string resource = reader.ReadToEnd();
                return resource;
            }
            catch (Exception ex)
            {
                string msg = $"Embedded resource {path} not found.";
                throw new AppException(AppStatus.EmbeddedResourceNotFound, msg, ex);
            }
        }

        public static Stream GetEmbeddedResourceAsStream(Type type, string path)
        {
            var assembly = Assembly.GetAssembly(type);

            if (assembly == null)
            {
                throw new AppException(AppStatus.EmbeddedResourceNotFound, $"Assembly {type} not found.");
            }

            var stream = assembly.GetManifestResourceStream(path);

            if (stream == null)
            {
                throw new AppException(AppStatus.EmbeddedResourceNotFound, $"File {path} is not embedded");
            }
            
            return stream;
        }
    }
}