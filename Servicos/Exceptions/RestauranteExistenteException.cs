using System;

namespace Servicos.Exceptions
{
    public class RestauranteExistenteException : Exception
    {
        public RestauranteExistenteException(string message = "O restaurante já existe no sistema") : base(message)
        {
        }
    }
}
