using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWar.CreatePhoneNumber
{
    class CreatePhone
    {
        public static void MainDemo()
        {
            Console.WriteLine(Create(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }).Equals("(123) 456-7890"));
            Console.WriteLine(Create(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }).Equals("(111) 111-1111"));
        }

        private static string Create(int[] phone)
        {
            if (phone.Length != 10) return "0";

            StringBuilder builder = new StringBuilder();
            builder.Append("(" + string.Concat(phone[0..3]) + ") ");
            builder.Append(string.Concat(phone[3..6]) + "-");
            builder.Append(string.Concat(phone[6..]));
            return builder.ToString();
        }
    }
}
