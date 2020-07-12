using System;
using System.Collections.Generic;
using System.Text;

namespace TestVersion.LocalFunction
{
    class DemoLocalFunction
    {
        public static void DemoMain()
        {
            Console.WriteLine("le ngoc tu");
            string firstname = "Nguyen hoang";
            string lastname = "nguyen hoang ngoc tran";


            void Func1()
            {
                Console.WriteLine("Function 1");
            }

            string Func2(string param1, string param2)
            {
                Func1();
                return param1 + " " + param2;
            }

            Func1();
            Console.WriteLine(Func2(firstname, lastname));
        }

        public static void StaticLocalFunction()
        {
            Console.WriteLine("Static Local Function");
            int number1 = 12;
            int number2 = 33;

            static void StaticFunc1()
            {
                Console.WriteLine("Static Function 01");
            }

            static void StaticFunc2(int param1, int param2)
            {
                StaticFunc1();
                int result = param1 + param2;
                //Console.WriteLine($"Sum: {result}");
                Console.WriteLine(6 % 4);
            }

            StaticFunc1();
            StaticFunc2(number1, number2);
        }

    }
}
