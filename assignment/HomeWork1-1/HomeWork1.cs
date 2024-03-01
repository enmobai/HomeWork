namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1;
            double num2;
            string str1;
            double ans;
            Console.WriteLine("请输入运算数1");
            num1=double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算数2");
            num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符");
            str1=Console.ReadLine();
            switch(str1)
            {
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
                    Console.WriteLine("运算符错误");
                    return;
            }
            Console.WriteLine(num1 + str1 + num2 + "=" + ans);
        }
    }
}