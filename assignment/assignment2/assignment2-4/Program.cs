namespace assignment2
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
            int[,] arr = new int[m, n];
            string s;
            for (int i = 0; i < m; i++)
            {
                s = Console.ReadLine();
                string[] arrs = s.Split(" ");
                for (int j = 0; j < arrs.Length; j++)
                {
                    arr[i, j] = int.Parse(arrs[j]);
                }
            }

            for (int i = 0;i < m; i++)
            {
                if (!judge(m, n, i, 0, arr))
                {
                    Console.WriteLine("该矩阵不符合要求");
                    return;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (!judge(m, n, 0, i, arr))
                {
                    Console.WriteLine("该矩阵不符合要求");
                    return;
                }
            }
            Console.WriteLine("该矩阵符合要求");
        }
        static bool judge(int m,int n,int x,int y, int[,] arr)
        {
            int tar = arr[x,y];
            for (int i = x + 1, j = y + 1; i < m && j < n; i++, j++)
            {
                if (arr[i,j]!= tar)
                {
                    return false;
                }
            }
            return true;
        }
    }
}