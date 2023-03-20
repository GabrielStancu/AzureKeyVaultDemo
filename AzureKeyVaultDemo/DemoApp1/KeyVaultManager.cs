using Azure.Security.KeyVault.Secrets;

namespace DemoApp1;

public class KeyVaultManager : IKeyVaultManager
{
    private readonly SecretClient _secretClient;

    public KeyVaultManager(SecretClient secretClient)
    {
        _secretClient = secretClient;
    }

    public async Task<string> GetSecret(string secretName)
    {
        KeyVaultSecret keyValueSecret = await _secretClient.GetSecretAsync(secretName);
        return keyValueSecret.Value;
    }
}