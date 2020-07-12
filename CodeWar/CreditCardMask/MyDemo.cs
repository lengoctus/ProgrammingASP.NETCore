using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWar.CreditCardMask
{
    //    Usually when you buy something, you're asked whether your credit card number, 
    //phone number or answer to your most secret question is still correct. However, since someone could look over your shoulder, you don't want that shown on your screen.Instead, we mask it.
    //Your task is to write a function maskify, which changes all but the last four characters into '#'.
    public class MyDemo
    {
        public static void MainDemo()
        {
            Maskify("4556364607935616");
        }

        private static string Maskify(string str)
        {
            int length = str.Length;
            StringBuilder buider = new StringBuilder(str);

            for (int i = 0; i < length; i++)
            {
                if (i == length - 4) break;
                buider[i] = '#';
            }
            Console.WriteLine(buider.ToString());
            return buider.ToString();
        }
    }
}
