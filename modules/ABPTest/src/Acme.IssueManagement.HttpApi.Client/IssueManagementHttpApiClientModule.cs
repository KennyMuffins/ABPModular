using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement
{
    [DependsOn(
        typeof(IssueManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class IssueManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "IssueManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(IssueManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
