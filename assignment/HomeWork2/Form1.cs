namespace HomeWork2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double ans=0;
            double num1;
            double num2;
            num1 = double.Parse(textBox1.Text);
            num2 = double.Parse(textBox2.Text);
            switch (comboBox1.Text) {
                case "+":
                    ans=num1 + num2;
                    break;
                case "-":
                    ans=num1 - num2;
                    break;
                case "*":
                    ans=num1 * num2;
                    break;
                case "/":
                    ans=num1 / num2;
                    break;
                default:
                    break;
            }
            label2.Text = ans.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}