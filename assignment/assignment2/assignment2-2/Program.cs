namespace assignment2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            Console.WriteLine("Please enter an array (separated by a space)");
            try
            {
                s = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            string[] stringArr = s.Split(" ");
            int[] arr=new int[stringArr.Length];
            int sum = 0;
            int average;
            for (int i = 0; i < stringArr.Length; i++)
            {
                arr[i] = int.Parse(stringArr[i]);
                sum = sum + arr[i];
            }
            average = sum/ arr.Length;
            int max = arr[0];
            for (int i = 0;i < arr.Length; i++) {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++) {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("The maximum value of the array is "+max);
            Console.WriteLine("The minimum value of the array is "+min);
            Console.WriteLine("The average value of the array is " + average);
            Console.WriteLine("The sum of the array elements is " + sum);
        }
    }
}