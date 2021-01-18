using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.IssueManagement.EntityFrameworkCore
{
    public class IssueManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public IssueManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}