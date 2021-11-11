using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace BasicManagement.MongoDB
{
    public static class BasicManagementMongoDbContextExtensions
    {
        public static void ConfigureBasicManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BasicManagementMongoModelBuilderConfigurationOptions(
                BasicManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}