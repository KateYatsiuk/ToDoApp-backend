namespace ToDoTasks.DAL.Validation
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateEnum : ValidationAttribute
    {
        private readonly Type _enumType;

        public ValidateEnum(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("The provided type is not an Enum.");
            }

            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!Enum.IsDefined(_enumType, value))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
