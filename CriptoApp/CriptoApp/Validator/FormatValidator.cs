using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CriptoApp.Validator
{
    public class FormatValidator : IValidator
    {
        public string Message { get; set; } = "Hatalı format";
        public string Format { get; set; }
        public bool Check(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Regex format = new Regex(Format);

                return format.IsMatch(value);
            }
            else
            {
                return false;
            }
        }
    }
}
