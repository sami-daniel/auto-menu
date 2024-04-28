namespace Servicos.Helpers
{
    /// <summary>
    /// Classe utilitária para hashear e verificar senhas usando o algoritmo bcrypt.
    /// </summary>
    public static class HasherSenha
    {
        /// <summary>
        /// Hashea uma senha usando o algoritmo bcrypt.
        /// </summary>
        /// <param name="senha">A senha a ser hasheada.</param>
        /// <returns>O hash da senha.</returns>
        public static string HashearSenha(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);

        /// <summary>
        /// Verifica se uma senha fornecida corresponde ao hash da senha armazenada.
        /// </summary>
        /// <param name="inputSenha">A senha fornecida pelo usuário.</param>
        /// <param name="senhaHasheada">O hash da senha armazenada.</param>
        /// <returns>True se a senha fornecida corresponde ao hash da senha armazenada; caso contrário, False.</returns>
        public static bool VerificarSenha(string inputSenha, string senhaHasheada) => BCrypt.Net.BCrypt.Verify(inputSenha, senhaHasheada);
    }
}
