using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OrderApp
{
    public class Order : IComparable<Order>
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreateTime { get; set; }
        [ForeignKey("OrderId")]
        public List<OrderDetail> Details { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Details = new List<OrderDetail>();
            CreateTime = DateTime.Now;
        }

        public Order(string orderId, Customer customer, List<OrderDetail> items)
        {
            OrderId = orderId;
            Customer = customer;
            Details = items;
            CreateTime = DateTime.Now;
        }

        public double TotalPrice => Details.Sum(item => item.TotalPrice);

        public void AddItem(OrderDetail orderItem)
        {
            if (Details.Contains(orderItem))
            {
                throw new ApplicationException($"添加错误：订单项{orderItem.GoodsName} 已经存在!");
            }
            Details.Add(orderItem);
        }

        public void RemoveDetail(OrderDetail orderItem)
        {
            Details.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{OrderId}, customer:{Customer}, orderTime:{CreateTime}, totalPrice：{TotalPrice}");
            Details.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + OrderId.GetHashCode();
                hashCode = hashCode * 23 + Customer?.GetNameHashCode() ?? 0;
                hashCode = hashCode * 23 + CreateTime.GetHashCode();
                return hashCode;
            }
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return OrderId.CompareTo(other.OrderId);
        }
    }
}
