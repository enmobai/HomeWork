namespace assignment2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            Console.WriteLine("Please send the number");
            try
            {
                s = Console.ReadLine();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            int num=int.Parse(s);
            Console.WriteLine("The prime factors of this number are:");
            for (int i = 2;i<num ; )
            {
                if (!judge(i)) { 
                    i++;
                    continue; 
                }
                if (num%i==0) {
                    num = num / i;
                    Console.Write(i+" ");
                }
                else
                {
                    i++;
                }
            }
            if (judge(num)) {
                Console.Write(num);
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