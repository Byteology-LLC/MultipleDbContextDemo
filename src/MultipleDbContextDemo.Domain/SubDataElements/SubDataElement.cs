using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.SubDataElements
{
    public class SubDataElement 
    {
        public SubDataElement()
        {
        }

        public SubDataElement(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            SubDataElement subDataElement = obj as SubDataElement;
            
            if(subDataElement == null) return false;
            if (!string.Equals(subDataElement.Name, this.Name, StringComparison.InvariantCultureIgnoreCase)) return false;
            if (!string.Equals(subDataElement.Value, this.Value, StringComparison.InvariantCultureIgnoreCase)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value);
        }
    }
}
