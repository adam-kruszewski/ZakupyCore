using Kruchy.Core.Cryptography;
using Microsoft.Extensions.DependencyInjection;

namespace Kruchy.Core
{
    public class KruchyCoreModule
    {
        public void Init(IServiceCollection services)
        {
            services.AddTransient<IAesEncrypter, AesEncrypter>();
        }
    }
}
