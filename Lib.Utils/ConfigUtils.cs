using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Lib.Utils
{
    public class ConfigUtils
    {
        private static T LoadConfigBase<T>(Stream configShared, Stream configEnv)
        {
            var config = new ConfigurationBuilder()
                .AddJsonStream(configShared)
                .AddJsonStream(configEnv)
                .Build().Get<T>();

            return config;
        }

        public static T LoadConfig<T>(Type type)
        {
            string env = Debugger.IsAttached ? "Debug" : "Release";
            string ns = type.Namespace;

            Stream configShared = EmbeddedResourceUtils.GetEmbeddedResourceAsStream(type, ns + ".Config.Config.Shared.json");
            Stream configEnv = EmbeddedResourceUtils.GetEmbeddedResourceAsStream(type, ns + $".Config.Config.{env}.json");

            return LoadConfigBase<T>(configShared, configEnv);
        }
    }
}