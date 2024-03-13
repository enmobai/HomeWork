namespace assignment3_2
{
    abstract class graph{
        public abstract double calculate();
    }
     
    class rectangle : graph
    {
        double len;
        double wid;
        public rectangle(double len, double wid)
        {
            this.len = len;
            this.wid = wid;
            Console.WriteLine($"创建长方形，边长分别为{len},{wid}");
        }
        public override double calculate()
        {
            return len*wid;
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
            Console.WriteLine($"创建三角形，边长分别为：{len1},{len2},{len3}");
        }
        public bool judge()
        {
            if (len1 + len2 <= len3 || len2 + len3 <= len1 || len3 + len1 <= len2)
            {
                return false;
            }
            return true;
        }
        public override double calculate()
        {
            if(!judge()) return 0;
            double p = (len1 + len2 + len3) / 2;
            return Math.Sqrt(p * (p - len1) * (p - len2) * (p - len3));
        }
    }

    class square : graph
    {
        double len;
        public square(double len) {
            this.len = len;
            Console.WriteLine($"创建正方形:{len}");
        }
        public override double calculate()
        {
            return len*len;
        }
    }
    class Factory
    {
        public static graph Create(string name)
        {
            Random r = new Random();
            switch (name)
            {
                case "rectangle":
                    return new rectangle(10*r.NextDouble(),10*r.NextDouble());
                case "trangle":
                    return new trangle(r.Next(1,10),r.Next(1,10),r.Next(1,10));
                case "square":
                    return new square(10*r.NextDouble());
                default:
                    return null;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r=new Random();
            double sum = 0;
            for (int i = 0; i < 10; i++) {
                int tmp=r.Next(1,3);
                graph g;
                if (tmp==1)
                {
                    g = Factory.Create("rectangle");
                }else if(tmp==2)
                {
                    g = Factory.Create("trangle");
                }
                else
                {
                    g = Factory.Create("square");
                }
                sum += g.calculate();
            }
            Console.WriteLine("总面积为" + sum);
        }
    }
}