using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace BasicManagement.MongoDB
{
    public class BasicManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public BasicManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}