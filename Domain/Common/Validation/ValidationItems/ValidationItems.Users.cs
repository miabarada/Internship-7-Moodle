using System.Xml;

namespace Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem ItemNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Podatak ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EmailRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = $"Email ne smije biti prazan!",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem PasswordRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = $"Lozinka ne smije biti prazna!",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
}
