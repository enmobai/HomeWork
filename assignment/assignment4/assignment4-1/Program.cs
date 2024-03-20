using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

namespace assignment4_1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t) {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public int GetLength()
        {
            int length = 0;
            Node<T> node = head;
            while (node != null) {
                length++;
                node = node.Next;
            }
            return length;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add (T t)
        {
            Node<T> n=new Node<T> (t);
            if (tail == null)
            {
                head = tail = n;
            }else{
                tail.Next = n;
                tail = n;
            }
        }

        public void Foreach(GenericList<T> list,Action<T> action)
        {
            Node < T > node= head;
            for (int i = 0; i < GetLength(); i++)
            {
                action(node.Data);
                node= node.Next;
            }
        } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int> ();
            list.Add (1);
            list.Add (2);
            list.Add (3);
            list.Add (4);
            list.Add (5);
            list.Foreach(list,m=>Console.Write(m+" "));
            Console.WriteLine();
            int sum = 0;
            list.Foreach(list, m => sum += m);
            Console.WriteLine($"sum={sum}");
            int max = int.MinValue;
            list.Foreach(list,x=>max=Math.Max(max,x));
            Console.WriteLine($"max={max}"); 
            int min = int.MaxValue;
            list.Foreach(list,x=>min=Math.Min(x,min));
            Console.WriteLine($"min={min}");
        }
        static int getMax(int m,int max)
        {
            if(m > max) { 
            max = m;
            }
            return max;
        }
        static int getMin(int m,int min)
        {
            if(min > m) { 
            min = m;
            }
            return min;
        }
    }
}