namespace assignment6
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        class Order
        {
            private int id;
            private double money;
            public Order(int id, double money)
            {
                this.id = id;
                this.money = money;
            }

            public int getId()
            {
                return id;
            }
            public double getMoney()
            {
                return money;
            }
            public void setId(int id)
            {
                this.id = id;
            }
            public void setMoney(double money)
            {
                this.money = money;
            }
            public bool Equals(Order other)
            {
                return this.id == other.getId()
                    && this.money == other.money;
            }
            public void ToString()
            {
                Console.WriteLine($"该订单的订单号为{id.ToString()},金额为{money}");
            }
        }

        class OrderDetails : Order
        {
            private string itemName;
            private string cusName;
            public OrderDetails(int id, double money, string itemName, string cusName) : base(id, money)
            {
                this.itemName = itemName;
                this.cusName = cusName;
            }
            public string getItemName()
            {
                return this.itemName;
            }
            public string getCusName()
            {
                return this.cusName;
            }
            public void setCusName(string name)
            {
                this.cusName = name;
            }
            public void setItemName(string name)
            {
                this.itemName = name;
            }
            public bool Equals(OrderDetails other)
            {
                return this.getId() == other.getId()
                    || this.itemName == other.getItemName()
                    && this.cusName == other.getCusName()
                    && this.getMoney() == other.getMoney();
            }
            public void ToString()
            {
                Console.WriteLine($"该订单的订单号为{getId().ToString()},商品名称为{itemName}," +
                    $"客户名称为{cusName},金额为{getMoney()}");
            }
        }

        class OrderService
        {
            private List<OrderDetails> orderList = new List<OrderDetails>();
            public OrderService()
            {
                addOrder(001, 100.2, "Wang", "apple");
                addOrder(002, 150.1, "Li", "pen");
                addOrder(003, 1420.2, "Jack", "book");
                addOrder(004, 500.2, "Mo", "cup");
                addOrder(005, 1780.2, "Lucy", "book");
                addOrder(006, 7899.0, "Chen", "computer");
            }
            public void addOrder(int id, double money, string cusName, string itemName)
            {
                OrderDetails od = new OrderDetails(id, money, cusName, itemName);
                if (orderList != null)
                {
                    foreach (var item in orderList)
                    {
                        if (od.Equals(item))
                        {
                            Console.WriteLine("已存在相同订单，无法添加!");
                            return;
                        }
                    }
                }
                orderList.Add(od);
                sortOrder();
                Console.WriteLine("订单添加完成");
            }
            public void removeOrder(int id)
            {
                try
                {
                    orderList.RemoveAll(x => x.getId() == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine("出现异常: {0}", e);
                }
                Console.WriteLine($"删除id为{id}的订单成功！");
            }
            public void changeOrder(int id, double money, string cusName, string itemName)
            {

                OrderDetails od = orderList.Find(x => x.getId() == id);
                removeOrder(id);
                Console.WriteLine("数据修改中.......");
                od.setMoney(money);
                od.setCusName(cusName);
                od.setItemName(itemName);
                orderList.Add(od);
                sortOrder();
                Console.WriteLine("订单数据已修改!");
            }
            public List<OrderDetails> searchbyId(int id)
            {
                var query = from o in orderList
                            where o.getId() == id
                            orderby o.getId()
                            select o;
                return query.ToList();
            }
            public List<OrderDetails> searchbyMoney(double money)
            {
                var query = from o in orderList
                            where o.getMoney() == money
                            orderby o.getId()
                            select o;
                return query.ToList();
            }
            public List<OrderDetails> searchbyCusName(string name)
            {
                var query = from o in orderList
                            where o.getCusName().Equals(name)
                            orderby o.getId()
                            select o;
                return query.ToList();
            }
            public List<OrderDetails> searchbyItemName(string name)
            {
                var query = from o in orderList
                            where o.getItemName().Equals(name)
                            orderby o.getId()
                            select o;
                return query.ToList();
            }
            public void sortOrder()
            {
                orderList.Sort((o1, o2) => o1.getId().CompareTo(o2.getId()));
            }
        }
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}