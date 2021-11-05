using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Basic.MongoDB
{
    public class BasicMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public BasicMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}