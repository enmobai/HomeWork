namespace assignment5
{
    class Order {
        private int id;
        private double money;
        public Order(int id, double money)
        {
            this.id = id;
            this.money = money;
        }

        public int getId(){
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
            return this.id==other.getId()
                && this.money==other.money;
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
        public OrderDetails(int id,double money,string itemName, string cusName): base(id, money)
        {
            this.itemName = itemName;
            this.cusName = cusName;
        }
        public string getItemName (){
            return this.itemName;
        }
        public string getCusName()
        {
            return this.cusName;
        }
        public void setCusName(string name) { 
            this.cusName=name;
        }
        public void setItemName(string name) { 
            this.itemName=name;
        }
        public bool Equals(OrderDetails other)
        {
            return this.getId()==other.getId()
                || this.itemName==other.getItemName()
                && this.cusName==other.getCusName()
                &&this.getMoney()==other.getMoney();
        }
        public void ToString()
        {
            Console.WriteLine($"该订单的订单号为{getId().ToString()},商品名称为{itemName}," +
                $"客户名称为{cusName},金额为{getMoney()}");
        }
    }

    class OrderService
    {
        private List<OrderDetails> orderList=new List<OrderDetails>();
        public OrderService()
        {
            addOrder(001, 100.2, "Wang", "apple");
            addOrder(002, 150.1, "Li", "pen");
            addOrder(003, 1420.2, "Jack", "book");
            addOrder(004, 500.2, "Mo", "cup");
            addOrder(005, 1780.2, "Lucy", "book");
            addOrder(006, 7899.0, "Chen", "computer");
        }
        public void addOrder(int id,double money,string cusName,string itemName)
        {
            OrderDetails od=new OrderDetails(id,money,cusName,itemName);
            if (orderList!=null)
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
            catch(Exception e)
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
            var query=from o in orderList
                            where o.getId()==id
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
            orderList.Sort((o1,o2)=>o1.getId().CompareTo(o2.getId()));
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            Console.WriteLine("欢迎进入订单管理系统！");
            
            while (true)
            {
                int a;
                Console.WriteLine("请输入需要的操作：1:添加订单，2：删除订单，3：修改订单，4：查询订单，5：退出");
                a=int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("请依次换行输入添加的订单信息：(id,money,cusName,itemName)");
                        int id=int.Parse(Console.ReadLine());
                        double money=double.Parse(Console.ReadLine());
                        string cusName=Console.ReadLine();
                        string itemName=Console.ReadLine();
                        os.addOrder(id, money,cusName, itemName);
                        break;
                    case 2:
                        Console.WriteLine("请输入需要删除的订单号：");
                        int delId=int.Parse (Console.ReadLine());
                        os.removeOrder(delId);
                        break;
                    case 3:
                        Console.WriteLine("请输入需要修改的订单号：");
                        int changeId=int.Parse (Console.ReadLine());
                        if (os.searchbyId(changeId) == null)
                        {
                            Console.WriteLine("未查找到该订单");
                        }
                        else
                        {
                            Console.WriteLine("存在该订单，请依次换行输入修改后的信息(money,cusName,itemName)");
                            double changeMoney=double.Parse (Console.ReadLine());
                            string changeCusName=Console.ReadLine();
                            string changeItemName=Console.ReadLine();
                            os.changeOrder(changeId, changeMoney, changeCusName, changeItemName);
                        }
                        break; 
                    case 4:
                        Console.WriteLine("请输入查询标准：");
                        Console.WriteLine("1：按id，2：按商品名称，3：按客户，4：按金额");
                        int tmp=int.Parse(Console.ReadLine());
                        List<OrderDetails> result;
                        switch (tmp)
                        {
                            case 1:
                                Console.WriteLine("请输入查询的id");
                                int serId=int.Parse(Console.ReadLine());
                                result=os.searchbyId(serId);
                                if (result == null)
                                {
                                    Console.WriteLine("未查到相关订单");
                                    break;
                                }
                                foreach (var item in result)
                                {
                                    item.ToString();
                                }
                                break;
                            case 2:
                                Console.WriteLine("请输入查询的商品名称：");
                                string serItemName=Console.ReadLine();
                                result=os.searchbyItemName(serItemName);
                                if (result == null)
                                {
                                    Console.WriteLine("未查到相关订单");
                                    break;
                                }
                                foreach (var item in result)
                                {
                                    item.ToString();
                                }
                                break;
                            case 3:
                                Console.WriteLine("请输入查询的客户名称：");
                                string serCusName = Console.ReadLine();
                                result=os.searchbyCusName(serCusName);
                                if (result == null)
                                {
                                    Console.WriteLine("未查到相关订单");
                                    break;
                                }
                                foreach (var item in result)
                                {
                                    item.ToString();
                                }
                                break;
                            case 4:
                                Console.WriteLine("请输入查询的金额:");
                                double serMoney=double.Parse (Console.ReadLine());
                                result =os.searchbyMoney(serMoney);
                                if (result == null)
                                {
                                    Console.WriteLine("未查到相关订单");
                                    break;
                                }
                                foreach (var item in result)
                                {
                                    item.ToString();
                                }
                                break;
                        }

                        break;
                    case 5:
                        Console.WriteLine("退出系统");
                        return;
                }
            }
        }
    }
}