using System.Text;

namespace assignment2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list=new List<int>();
            for (int i = 2; i <= 100; i++)
            {
                list.Add(i);
            }

            for (int i = 2;i < 10;)
            {
                list.RemoveAll(x => x%i==0&&x/i>1);
                i++;
            }

            Console.WriteLine("The prime numbers in 2-100 are:");
            foreach (int item in list)
            {
                Console.Write(item+" ");
            }
        }
        
    }
}