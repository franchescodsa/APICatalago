using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttibute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, 
            ValidationContext validationContext)
        {
            if (value ==null||string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
                
            }
            //Verififcação se a primiera letra é maiuscula
            var primeraLetra = value.ToString()[0].ToString();
            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("A primeira letra do nome do produto deve ser Maiuscula"); 
            }
            return ValidationResult.Success;
        }
    }
}
