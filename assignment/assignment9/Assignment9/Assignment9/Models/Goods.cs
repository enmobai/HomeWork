﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9.Models
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
            var goods = obj as Goods;
            return goods != null && Id == goods.Id && Name == goods.Name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + EqualityComparer<string>.Default.GetHashCode(Id);
                hashCode = hashCode * 23 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * 23 + Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
