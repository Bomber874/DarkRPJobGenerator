using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DarkRPJobGenerator.ValidationRules
{
    class Numbers : ValidationRule
    {
        public Numbers()
        {

        }

        public override ValidationResult Validate(object _value, CultureInfo cultureInfo)
        {
            try
            {
                string value = (string)_value;
                int num;
                if (int.TryParse(value, out num))
                {
                    if (num >= 0)
                        return ValidationResult.ValidResult;
                    else
                        return new ValidationResult(false, $"Значение должно быть положительным");
                }
                else
                    return new ValidationResult(false, $"Только цифры");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Произошла ошибка: {e.Message}");
            }
        }
    }
}
