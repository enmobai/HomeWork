namespace assignment3
{
    interface graph
    {
        public bool judge();
        public double calculate();
    }

    //长方形
    class rectangle : graph
    {
        double len;
        double wid;
        public rectangle(double len,double wid){
            this.len = len;
            this.wid = wid;  
        }
        public bool judge()
        {
            return true;
        }
        public double calculate()
        {
            return len * wid;
        }
    }

    class square : graph
    {
        double len;
        public square(double len)
        {
            this.len = len;
        }

        public bool judge()
        {
            return true;
        }
        public double calculate()
        {
            return len*len;
        }
    }

    class trangle : graph
    {
        double len1;
        double len2;
        double len3;
        public trangle(double len1, double len2, double len3)
        {
            this.len1 = len1;
            this.len2 = len2;
            this.len3 = len3;
        }

        public bool judge()
        {
            if (len1+len2<=len3||len2+len3<=len1||len3+len1<=len2)
            {
                return false;
            }
            return true;
        }

        public double calculate()
        {
            double p = (len1 + len2 + len3) / 2;
            return Math.Sqrt(p*(p-len1)*(p-len2)*(p-len3));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            rectangle rec = new rectangle(4,5);
            trangle tra = new trangle(1,2,3);
            square squ=new square(4);
            Console.WriteLine($"长方形是否合法{rec.judge()}，面积为{rec.calculate()}");
            Console.WriteLine($"正方形是否合法{squ.judge()}，面积为{squ.calculate()}");
            Console.WriteLine($"三角形是否合法{tra.judge()}，面积为{tra.calculate()}");
        }
    }
}