using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _Parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = ReadIntData("content.txt");
            CalcFactorial(list);
        }
        static List<int> ReadIntData(string file)
        {
            List<int> list = new List<int>();

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string content;
                while ((content = sr.ReadLine()) != null)
                {
                    string[] n = content.Split(' ');
                    foreach (var i in n)
                    {
                        int number;
                        if (int.TryParse(i, out number))
                            list.Add(number);
                    }
                }
            }

            Console.Write("Numbers: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            return list;
        }
        static void CalcFactorial(List<int> list)
        {
            Parallel.ForEach(list, n =>
            {
                int factorial = 1;
                for (int i = 2; i <= n; i++)
                {
                    factorial *= i;
                }
                Console.WriteLine($"{n}! = {factorial}");
            });
            Console.WriteLine("\n");

        }
    }
}
