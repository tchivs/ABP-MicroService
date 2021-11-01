using SystemManagement.Samples;
using Xunit;

namespace SystemManagement.MongoDB.Samples
{
    [Collection(MongoTestCollection.Name)]
    public class SampleRepository_Tests : SampleRepository_Tests<SystemManagementMongoDbTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to MongoDB.
         */
    }
}
