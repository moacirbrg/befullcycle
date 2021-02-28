using System.Text;
using Lib.Core;

namespace Lib.Utils.Validators
{
    public class RangeLengthValidator : Validator
    {
        private readonly int _max;
        private readonly int _min;

        public RangeLengthValidator(string propertyName, int min, int max) : base(propertyName)
        {
            this._max = max;
            this._min = min;
        }

        public static bool IsValid(string value, int min, int max)
        {
            if (value == null)
            {
                return true;
            }
            
            return value.Length >= min && value.Length <= max;
        }

        public override void Validate(object value)
        {
            if (!IsValid((string) value, this._min, this._max))
            {
                var builder = new StringBuilder();
                builder.Append($"Property {this.PropertyName} expects to have at least {this._min} ");
                builder.Append($"and max {this._max} characters, ");
                builder.Append($"but arrived {((string) value).Length}");

                throw new AppException(AppStatus.InvalidPropertyLength, builder.ToString());
            }
        }
    }
}