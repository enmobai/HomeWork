using System;

namespace OrderApp
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public int Index { get; set; } // 序号
        public string GoodsId { get; set; }
        public Goods GoodsItem { get; set; }
        public string OrderId { get; set; }
        public int Quantity { get; set; }

        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OrderDetail(int index, Goods goods, int quantity)
        {
            Index = index;
            GoodsItem = goods;
            Quantity = quantity;
        }

        public string GoodsName => GoodsItem?.Name ?? "";
        public double UnitPrice => GoodsItem?.Price ?? 0.0;
        public double TotalPrice => GoodsItem == null ? 0.0 : GoodsItem.Price * Quantity;

        public override string ToString()
        {
            return $"[No.: {Index}, goods: {GoodsName}, quantity: {Quantity}, totalPrice: {TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderDetail detail)
            {
                return Index == detail.Index && GoodsName == detail.GoodsName && Quantity == detail.Quantity;
            }
            return false;
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
