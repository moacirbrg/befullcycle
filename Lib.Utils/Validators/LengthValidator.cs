using Lib.Core;

namespace Lib.Utils.Validators
{
    public class LengthValidator : Validator
    {
        private readonly int _length;

        public LengthValidator(string propertyName, int length) : base(propertyName)
        {
            this._length = length;
        }

        public static bool IsValid(string value, int length)
        {
            if (value == null)
            {
                return true;
            }

            return value.Length == length;
        }

        public override void Validate(object value)
        {
            if (!IsValid((string) value, this._length))
            {
                string message = $"Property {this.PropertyName} expects {this._length} characters, not {((string) value).Length}";
                throw new AppException(AppStatus.InvalidPropertyLength, message);
            }
        }
    }
}