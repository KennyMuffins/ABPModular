using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Acme.IssueManagement.MongoDB
{
    public class IssueManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public IssueManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}