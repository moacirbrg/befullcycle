using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lib.Utils.Validators
{
    public class ValidationConverter<T> : JsonConverter<T>
    {
        private readonly Validator[] _validators;
        
        public ValidationConverter(Validator[] validators)
        {
            this._validators = validators;
        }
        
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T deserialized = JsonSerializer.Deserialize<T>(ref reader);
            Type type = deserialized?.GetType();

            if (type != null)
            {
                foreach (Validator validator in this._validators)
                {
                    object value = type.GetProperty(validator.PropertyName)?.GetValue(deserialized);
                    validator.Validate(value);
                }
            }

            return deserialized;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value);
        }
    }
}