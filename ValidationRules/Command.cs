using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DarkRPJobGenerator.ValidationRules
{
    class Command : ValidationRule
    {
        public Command()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex r = new Regex(@"^[\S]+$");
            try
            {
                if (r.IsMatch(value as string))
                    return ValidationResult.ValidResult;
                return new ValidationResult(false, $"Любые непробельные символы");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Произошла ошибка: {e.Message}");
            }
        }
    }
}
