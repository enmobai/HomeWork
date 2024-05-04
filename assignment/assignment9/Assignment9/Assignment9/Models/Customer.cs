using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Customer(string name) : this()
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null && Id == customer.Id && Name == customer.Name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + EqualityComparer<string>.Default.GetHashCode(Id);
                hashCode = hashCode * 23 + EqualityComparer<string>.Default.GetHashCode(Name);
                return hashCode;
            }
        }
    }
}
