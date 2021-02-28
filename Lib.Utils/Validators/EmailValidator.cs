using System.Text.RegularExpressions;
using Lib.Core;

namespace Lib.Utils.Validators
{
    public class EmailValidator : Validator
    {
        public EmailValidator(string propertyName) : base(propertyName) { }

        public static bool IsValid(string value)
        {
            if (value == null)
            {
                return true;
            }

            var regex = new Regex(@"^[a-z0-9][a-z0-9.+_-]*@[a-z0-9][a-z0-9_-]*(?:\.[a-z0-9]+[a-z0-9_-]*)+$");
            return regex.IsMatch(value);
        }

        public override void Validate(object value)
        {
            if (!IsValid((string) value))
            {
                throw new AppException(AppStatus.InvalidEmail, (string) value);
            }
        }
    }
}