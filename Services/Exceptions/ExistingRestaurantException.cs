namespace Servicos.Exceptions
{
    public class ExistingRestaurantException : Exception
    {
        public ExistingRestaurantException(string? message = "Um restaurante com o mesmo CNPJ já existe!") : base(message)
        {
        }
    }
}
