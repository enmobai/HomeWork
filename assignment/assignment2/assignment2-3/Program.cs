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

            for (int i = 2;i < 50;)
            {
                if (!judge(i))
                {
                    i++;
                    continue;
                }
                list.RemoveAll(x => x%i==0&&x/i>1);
                i++;
            }

            Console.WriteLine("The prime numbers in 2-100 are:");
            foreach (int item in list)
            {
                Console.Write(item+" ");
            }
        }
        static bool judge(int num)
        {
            if (num == 1)
            {
                return false;
            }
            else if (num == 2)
            {
                return true;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}