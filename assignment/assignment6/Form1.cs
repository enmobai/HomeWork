using System.Data;
using System.Runtime.InteropServices;

namespace assignment6
{


    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        public void ShowConsole()
        {
            AllocConsole();
            Console.WriteLine("控制台输出");
        }

        OrderService os = new OrderService();
        public Form1()
        {
            InitializeComponent();
            InitializeDataSource();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataSource()
        {
            List<OrderDetails> ods = os.orderList;
            Console.WriteLine(ods[1].getItemName());
            Console.WriteLine(ods[1].getId());
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = ods;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrderDetails> list = new List<OrderDetails>();
                switch (comboBox1.Text)
                {
                    case "id":
                        list = os.searchbyId(int.Parse(textBox1.Text));
                        Console.WriteLine(list == null);
                        break;
                    case "金额":
                        list = os.searchbyMoney(double.Parse(textBox1.Text));
                        break;
                    case "商品名称":
                        list = os.searchbyItemName(textBox1.Text);
                        break;
                    case "客户名称":
                        list = os.searchbyCusName(textBox1.Text);
                        break;
                }

                // 更新DataGridView的绑定源
                bindingSource1.DataSource = list;
                dataGridView1.Refresh(); // 确保DataGridView立即更新显示
            }
            catch (FormatException)
            {
                // 处理输入格式错误
                MessageBox.Show("请输入正确的格式！");
            }
            catch (Exception ex)
            {
                // 处理其他可能的异常
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
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
        public List<OrderDetails> orderList = new List<OrderDetails>{
            new OrderDetails(001, 100.2, "Wang", "apple"),
            new OrderDetails(002, 150.1, "Li", "pen"),
            new OrderDetails(003, 1420.2, "Jack", "book"),
            new OrderDetails(004, 500.2, "Mo", "cup"),
            new OrderDetails(005, 1780.2, "Lucy", "book"),
            new OrderDetails(006, 7899.0, "Chen", "computer")
        };
        public OrderService()
        {

        }
        public List<OrderDetails> getOrderList() { return orderList; }
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
}