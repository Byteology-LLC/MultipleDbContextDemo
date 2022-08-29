using MultipleDbContextDemo.SubDataElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MultipleDbContextDemo.DataElements
{
    public class DataElementManager : DomainService
    {
        private readonly IDataElementRepository _dataElementRepository;

        public DataElementManager(IDataElementRepository dataElementRepository)
        {
            _dataElementRepository = dataElementRepository;
        }

        public async Task<DataElement> CreateAsync(string name, string description, ICollection<SubDataElement> subDataElements = null)
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(description, nameof(description));

            var dataElement = new DataElement(GuidGenerator.Create(), name, description);

            if(subDataElements != null)
            {
                foreach(var subDataElement in subDataElements)
                {
                    dataElement.AddSubDataElement(subDataElement);
                }    
            }

            return await _dataElementRepository.InsertAsync(dataElement);
        }

        public async Task<DataElement> UpdateAsync(Guid id, string name, string description, ICollection<SubDataElement> subDataElements = null)
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(description, nameof(description));

            var dataElement = (await _dataElementRepository.WithDetailsAsync()).Where(x => x.Id == id).FirstOrDefault();

            if (dataElement == null || dataElement == default)
                throw new UserFriendlyException($"Data Element not found with Id: {id}");

            dataElement.Name = name;
            dataElement.Description = description;

            if (subDataElements != null)
            {
                subDataElements = new Collection<SubDataElement>();
                foreach (var subDataElement in subDataElements)
                {
                    dataElement.AddSubDataElement(subDataElement);
                }
            }

            return await _dataElementRepository.UpdateAsync(dataElement);
        }
    }
}
