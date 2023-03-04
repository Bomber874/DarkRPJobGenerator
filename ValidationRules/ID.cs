using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace DarkRPJobGenerator.ValidationRules
{
    class ID : ValidationRule
    {
        public ID()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex r = new Regex(@"^[A-Z]+$");
            try
            {
                if (r.IsMatch(value as string))
                    return ValidationResult.ValidResult;
                return new ValidationResult(false, $"Допускается использование только заглавных латинских символов");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Произошла ошибка: {e.Message}");
            }
        }
    }
}
