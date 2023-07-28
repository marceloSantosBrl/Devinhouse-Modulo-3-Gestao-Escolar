using System.Security.Cryptography;
using System.Text;

namespace GestaoEscolar_M3S01.Services;

public class CryptoService: ICryptoService
{
    public byte[] GetSalt(int keySize)
    {
        return RandomNumberGenerator.GetBytes(keySize);
    }

    public string GetHash(string password, int keySize, byte[] salt)
    {
        const int iterations = 350000;
        var hashAlgorithm = HashAlgorithmName.SHA512;
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize);
        return Convert.ToHexString(hash);
    }
}