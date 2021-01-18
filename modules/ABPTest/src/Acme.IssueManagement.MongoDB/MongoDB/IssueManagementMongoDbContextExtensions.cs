using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Acme.IssueManagement.MongoDB
{
    public static class IssueManagementMongoDbContextExtensions
    {
        public static void ConfigureIssueManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new IssueManagementMongoModelBuilderConfigurationOptions(
                IssueManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}