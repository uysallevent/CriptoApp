
namespace CriptoApp.Validator
{
    public class RequiredValidator : IValidator
    {
        public string Message { get; set; } = "Boş Geçilemez";

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
