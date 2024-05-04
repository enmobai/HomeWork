using System;
using System.Collections.Generic;

namespace OrderApp
{
    public class Goods
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Goods(string name, double price) : this()
        {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj is Goods goods)
            {
                return Id == goods.Id && Name == goods.Name && Price == goods.Price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + Id.GetHashCode();
                hashCode = hashCode * 23 + Name.GetHashCode();
                hashCode = hashCode * 23 + Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
