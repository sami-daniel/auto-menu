namespace Servicos.Helpers
{
    public static class HasherSenha
    {
        public static string HashearSenha(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);
        public static bool VerificarSenha(string inputSenha, string senhaHasheada) => BCrypt.Net.BCrypt.Verify(inputSenha, senhaHasheada);
    }
}
