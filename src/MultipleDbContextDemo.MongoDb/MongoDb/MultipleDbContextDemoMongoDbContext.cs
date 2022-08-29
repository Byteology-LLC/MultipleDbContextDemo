using MongoDB.Driver;
using MultipleDbContextDemo.DataElements;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MultipleDbContextDemo.MongoDb;

[ConnectionStringName("Mongo")]
public class MultipleDbContextDemoMongoDbContext : AbpMongoDbContext
{
    public IMongoCollection<DataElement> DataElements => Collection<DataElement>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        Check.NotNull(modelBuilder, nameof(modelBuilder));

        base.CreateModel(modelBuilder);

        modelBuilder.Entity<DataElement>(b => { b.CollectionName = $"{MultipleDbContextDemoConsts.DbTablePrefix}DataElements"; });
    }
}

