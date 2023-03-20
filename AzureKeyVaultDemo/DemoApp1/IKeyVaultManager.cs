namespace DemoApp1;

public interface IKeyVaultManager
{
    public Task<string> GetSecret(string secretName);
}