using System.Collections.Generic;
using System.Text;

namespace Lib.Utils
{
    public static class StringUtils
    {
        public static string ReplaceVariables(string content, Dictionary<string, string> variables)
        {
            var resolvedMessage = new StringBuilder();
            int count = 0;
            string name = "";

            for (int i = 0; i < content.Length; i++)
            {
                char c = content[i];

                if (count == 0 && c == '$')
                {
                    count = 1;
                }
                else if (count == 1 && c == '{')
                {
                    count = 2;
                }
                else if (count >= 2 && c == '}')
                {
                    if (variables.ContainsKey(name))
                    {
                        resolvedMessage.Append(variables[name]);
                    }
                    else
                    {
                        resolvedMessage.Append("${");
                        resolvedMessage.Append(name);
                        resolvedMessage.Append('}');
                    }
                    
                    count = 0;
                    name = "";
                }
                else if (count >= 2)
                {
                    count++;
                    name += c;
                }
                else
                {
                    resolvedMessage.Append(c);
                }
            }

            return resolvedMessage.ToString();
        }

        public static string Truncate(string value, int maxLength, string end = "")
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            int totalMaxLength = maxLength - end.Length;

            if (totalMaxLength < value.Length)
            {
                var sb = new StringBuilder();
                sb.Append(value.Substring(0, totalMaxLength));
                sb.Append(end);

                return sb.ToString();   
            }
            else
            {
                return value;
            }
        }
    }
}