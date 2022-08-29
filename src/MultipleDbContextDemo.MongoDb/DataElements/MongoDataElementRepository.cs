using MultipleDbContextDemo.DataElements;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace MultipleDbContextDemo.MongoDb.DataElements
{
    public class MongoDataElementRepository : MongoDbRepository<MultipleDbContextDemoMongoDbContext, DataElement, Guid>, IDataElementRepository
    {
        public MongoDataElementRepository(IMongoDbContextProvider<MultipleDbContextDemoMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
