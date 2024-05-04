using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp
{
    class MainClass
    {
        public static void Main()
        {
            try
            {
               
                OrderService service = new OrderService();

             
                Order order1 = new Order(1, "Customer1", new List<OrderDetail> { /* 订单详情 */ });
                Order order2 = new Order(2, "Customer2", new List<OrderDetail> { /* 订单详情 */ });

                service.AddOrder(order1);
                service.AddOrder(order2);

                
                service.Export("./orders.xml");

        
                List<Order> orders = service.Orders;

           
                service.Sort(o => o.TotalPrice);
                orders = service.Orders;

    
                service.RemoveOrder(2);

   
                orders = service.QueryOrdersByGoodsName("apple");

 
                foreach (Order order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
