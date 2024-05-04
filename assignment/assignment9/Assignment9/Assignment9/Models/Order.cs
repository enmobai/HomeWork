using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Assignment9.Models
{
    public class Order : IComparable<Order>
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public string? CustomerName => Customer?.Name;
        public DateTime CreateTime { get; set; }
        public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }

        public Order(string orderId, Customer customer, List<OrderDetail> items) : this()
        {
            OrderId = orderId;
            Customer = customer;
            Details.AddRange(items);
        }

        public double TotalPrice => Details.Sum(d => d.TotalPrice);

        public void AddDetail(OrderDetail orderItem)
        {
            if (!Details.Contains(orderItem))
                Details.Add(orderItem);
            else
                throw new ApplicationException($"添加错误：订单项{orderItem.GoodsName} 已经存在!");
        }

        public void RemoveDetail(OrderDetail orderItem)
        {
            Details.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {OrderId}, Customer: {CustomerName}, Time: {CreateTime:dd/MM/yyyy HH:mm:ss}, Total: {TotalPrice}");
            foreach (var detail in Details)
            {
                sb.Append($"\n\t{detail}");
            }
            return sb.ToString();
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
                hashCode = hashCode * 23 + CustomerName?.GetHashCode() ?? 0;
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
