using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Assignment9.Models
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string? GoodsId { get; set; }
        [ForeignKey("GoodsId")]
        public Goods? GoodsItem { get; set; }
        public string? GoodsName => GoodsItem?.Name;
        public double? UnitPrice => GoodsItem?.Price ?? 0.0;
        public string? OrderId { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice => GoodsItem == null ? 0.0 : GoodsItem.Price * Quantity;

        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OrderDetail(int index, Goods goods, int quantity) : this()
        {
            Index = index;
            GoodsItem = goods;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"[No.:{Index}, goods:{GoodsName}, quantity:{Quantity}, totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderDetail;
            return item != null && GoodsName == item.GoodsName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + Index.GetHashCode();
                hashCode = hashCode * 23 + (GoodsName?.GetHashCode() ?? 0);
                hashCode = hashCode * 23 + Quantity.GetHashCode();
                return hashCode;
            }
        }
    }
}
