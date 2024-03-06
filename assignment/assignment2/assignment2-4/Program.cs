using System.Threading.Channels;

namespace assignment2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter M&N");
            int m;
            int n;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            int[,] arr = new int[m,n];
            string s;
            for (int i = 0; i < m; i++)
            {
                s= Console.ReadLine();
                string[] arrs = s.Split(" ");
                for (int j = 0; j < arrs.Length; j++)
                {
                    arr[i, j] = int.Parse(arrs[i]);
                }
            }



        }
    }
}