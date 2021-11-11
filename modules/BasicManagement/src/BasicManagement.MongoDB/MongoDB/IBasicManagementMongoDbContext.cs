using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace BasicManagement.MongoDB
{
    [ConnectionStringName(BasicManagementDbProperties.ConnectionStringName)]
    public interface IBasicManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
