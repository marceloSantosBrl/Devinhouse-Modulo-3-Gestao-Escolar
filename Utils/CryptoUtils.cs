using System.Security.Cryptography;
using System.Text;


namespace GestaoEscolar_M3S01.Utils;

public static class CryptoUtils
{
    public static Func<string, string> HashPasword = password =>
    {
        const int keySize = 64;
        const int iterations = 350000;
        var hashAlgorithm = HashAlgorithmName.SHA512;
        var salt = RandomNumberGenerator.GetBytes(keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize);
        return Convert.ToHexString(hash);
    };
}