using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace BasicManagement.MongoDB
{
    [ConnectionStringName(BasicManagementDbProperties.ConnectionStringName)]
    public class BasicManagementMongoDbContext : AbpMongoDbContext, IBasicManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureBasicManagement();
        }
    }
}