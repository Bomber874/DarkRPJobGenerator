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
    class RGB : ValidationRule
    {
        public RGB()
        {

        }

        public override ValidationResult Validate(object _value, CultureInfo cultureInfo)
        {
            try
            {
                string value = (string)_value;

                 if (Convert.ToByte(value) > 255 | Convert.ToByte(value) < 0)
                    return new ValidationResult(false, $"Допустимые значения 0-255");
                return ValidationResult.ValidResult;
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Произошла ошибка: {e.Message}");
            }
        }
    }
}
