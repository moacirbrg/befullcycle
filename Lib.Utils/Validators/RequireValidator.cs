using Lib.Core;

namespace Lib.Utils.Validators
{
    public class RequiredValidator : Validator
    {
        public RequiredValidator(string propertyName) : base(propertyName) { }

        public static bool IsValid(object value)
        {
            return value != null;
        }

        public override void Validate(object value)
        {
            if (!IsValid(value))
            {
                throw new AppException(AppStatus.MissingRequiredProperty, PropertyName);
            }
        }
    }
}