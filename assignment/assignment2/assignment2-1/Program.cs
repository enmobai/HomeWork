namespace assignment2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            Console.WriteLine("请输入数组（中间用空格隔开）");
            try
            {
                s = Console.ReadLine();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            string[] nums = s.Split(" ");
            Console.WriteLine("这些数中的素数有：");
            for (int i = 0; i < nums.Length; i++)
            {
                int tmp = int.Parse(nums[i]);
                if (judge(tmp))
                {
                    Console.Write(tmp+" ");
                }
            }
            
        }
        static bool judge(int num)
        {
            if (num == 1)
            {
                return false;
            }else if(num == 2)
            {
                return true;
            }
            else
            {
                for (int i = 2;i <= Math.Sqrt(num);i++)
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