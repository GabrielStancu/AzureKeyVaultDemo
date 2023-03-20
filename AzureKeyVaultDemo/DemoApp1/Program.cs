using DemoApp1;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddAzureClients(builder =>
        {
            builder.AddSecretClient(context.Configuration.GetSection("KeyVault"));
        });
        services.AddSingleton<IKeyVaultManager, KeyVaultManager>();
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
