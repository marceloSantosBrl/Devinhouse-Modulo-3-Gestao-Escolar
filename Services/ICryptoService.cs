namespace GestaoEscolar_M3S01.Services;

public interface ICryptoService
{
    public byte[] GetSalt(int keySize);
    public string GetHash(string password, int keySize, byte[] hash);
}