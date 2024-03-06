namespace Replyment.Application.Abstraction.Services.Cryptography;

public interface IEncryptionService
{
    Task<string> Encrypt(string text);
    Task<string> Decrypt(string encryptedText);
}
