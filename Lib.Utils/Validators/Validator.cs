namespace Lib.Utils.Validators
{
    public abstract class Validator
    {
        public string PropertyName { get; set; }
        public abstract void Validate(object value);
        
        protected Validator(string propertyName)
        {
            this.PropertyName = propertyName;
        }
    }
}