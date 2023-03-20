using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DemoApp1
{
    public class SettingsReader
    {
        private readonly IKeyVaultManager _keyVaultManager;
        private readonly ILogger _logger;

        public SettingsReader(ILoggerFactory loggerFactory, IKeyVaultManager keyVaultManager)
        {
            _keyVaultManager = keyVaultManager;
            _logger = loggerFactory.CreateLogger<SettingsReader>();
        }

        [Function("SettingsReader")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var secretName = "AppSecret";
            try
            {
                var secretValue = await _keyVaultManager.GetSecret(secretName);

                if (string.IsNullOrEmpty(secretValue)) 
                    return req.CreateResponse(HttpStatusCode.NotFound);
                
                _logger.LogInformation($"Secret: [{secretValue}] = <{secretValue}>");
                return req.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
    }
}
