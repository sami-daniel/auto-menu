namespace Services.Helpers
{
    /// <summary>
    /// Utility class for hashing and verifying passwords using the bcrypt algorithm.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes a password using the bcrypt algorithm.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>The hashed password.</returns>
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        /// <summary>
        /// Verifies if a provided password matches the stored hashed password.
        /// </summary>
        /// <param name="inputPassword">The password provided by the user.</param>
        /// <param name="hashedPassword">The hashed password stored.</param>
        /// <returns>True if the provided password matches the stored hashed password; otherwise, False.</returns>
        public static bool VerifyPassword(string inputPassword, string hashedPassword) => BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
    }
}
