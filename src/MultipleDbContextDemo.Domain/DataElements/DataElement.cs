using MultipleDbContextDemo.SubDataElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MultipleDbContextDemo.DataElements
{
    public class DataElement : FullAuditedAggregateRoot<Guid>
    {
        public DataElement()
        {
        }

        public DataElement(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Description { get; set; }

        public ICollection<SubDataElement> SubDataElements { get; private set; } = new Collection<SubDataElement>();


        /* helper methods for handling the SubDataElements collection */
        private bool IsInSubDataElements(SubDataElement subDataElement)
        {
            return SubDataElements.Any(x=>x.Equals(subDataElement));
        }

        public void AddSubDataElement(SubDataElement subDataElement)
        {
            Check.NotNull(subDataElement, nameof(subDataElement));

            if(IsInSubDataElements(subDataElement))
            {
                return;
            }

            SubDataElements.Add(subDataElement);
        }

        public void RemoveSubDataElement(SubDataElement subDataElement)
        {
            Check.NotNull(subDataElement, nameof(subDataElement));

            if (!IsInSubDataElements(subDataElement))
            {
                return;
            }

            SubDataElements.RemoveAll(x => x.Equals(subDataElement));
        }

        public void RemoveAllSubDataElements()
        {
            SubDataElements.Clear();
        }

    }
}
