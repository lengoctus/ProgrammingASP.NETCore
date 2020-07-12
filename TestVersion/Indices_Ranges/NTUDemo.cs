using System;
using System.Collections.Generic;
using System.Text;

namespace TestVersion.Indices_Ranges
{
    class NTUDemo
    {
        public static void MainDemo()
        {
            var arr = MyArray();
            //DemoIndices(arr);
            DemoRange(arr);
        }

        private static void DemoIndices(string[] arr)
        {
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            Console.WriteLine(arr[2]);
            Console.WriteLine(arr[3]);

            Console.WriteLine("+========================+");

            Console.WriteLine(arr[^1]);     // equal arr.Length - 1
            Console.WriteLine(arr[^2]);     // equal arr.Length - 2
            Console.WriteLine(arr[^3]);     // equal arr.Length - 3
            Console.WriteLine(arr[^4]);     // equal arr.Length - 4
        }


        private static void DemoRange(string[] arr)
        {
            var a = arr[1..3];
            ForLoop(a);

            var b = arr[1..];
            ForLoop(b);

            var c = arr[0..^0];
            ForLoop(c);

            var d = arr[^2..^0];
            ForLoop(d);
        }

        private static void ForLoop(string[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("+===============================+");
        }


        private static string[] MyArray()
        {
            string[] arr = { "Le Ngoc Tu", "Nguyen Hoang Ngoc Tran", "Ngo Bao Chau", "Bang Kieu" };
            return arr;
        }
    }
}
