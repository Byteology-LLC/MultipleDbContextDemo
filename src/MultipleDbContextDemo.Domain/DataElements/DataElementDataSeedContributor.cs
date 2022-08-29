using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace MultipleDbContextDemo.DataElements
{
    public class DataElementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IDataElementRepository _dataElementRepository;
        private readonly IGuidGenerator _guidGenerator;

        public DataElementDataSeedContributor(IDataElementRepository dataElementRepository, IGuidGenerator guidGenerator)
        {
            _dataElementRepository = dataElementRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _dataElementRepository.GetCountAsync() == 0)
            {
                var dataElements = new List<DataElement>();

                var de1 = new DataElement(_guidGenerator.Create(), "DataElement1", "The first Data Element");
                de1.AddSubDataElement(new SubDataElements.SubDataElement("DE1SE1", "Test Data 1"));
                de1.AddSubDataElement(new SubDataElements.SubDataElement("DE1SE2", "Test Data 2"));
                dataElements.Add(de1);

                var de2 = new DataElement(_guidGenerator.Create(), "DataElement2", "The second Data Element");
                de2.AddSubDataElement(new SubDataElements.SubDataElement("DE2SE1", "Test Data 1"));
                dataElements.Add(de2);

                var de3 = new DataElement(_guidGenerator.Create(), "DataElement3", "The third Data Element");
                de3.AddSubDataElement(new SubDataElements.SubDataElement("DE3SE1", "Test Data 1"));
                de3.AddSubDataElement(new SubDataElements.SubDataElement("DE3SE2", "Test Data 2"));
                de3.AddSubDataElement(new SubDataElements.SubDataElement("DE3SE3", "Test Data 3"));
                de3.AddSubDataElement(new SubDataElements.SubDataElement("DE3SE4", "Test Data 4"));
                dataElements.Add(de3);

                var de4 = new DataElement(_guidGenerator.Create(), "DataElement4", "The fourth Data Element");
                dataElements.Add(de4);

                await _dataElementRepository.InsertManyAsync(dataElements);
            }         
        }
    }
}
