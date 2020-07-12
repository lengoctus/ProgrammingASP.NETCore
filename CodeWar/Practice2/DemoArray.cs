using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWar.Practice2
{
    class DemoArray
    {
        public static void MainDemo()
        {
            string[] str1 = { "Le Ngoc Tu", "Nguyen Hoang Ngoc Tran", "SamSung", "Oppo" };
            string[] str2 = str1;
            str2[2] = "null";
            Console.WriteLine(str2[2]);

            string[] st1 = { "Hoa Lan", "Hoa Hue", "Hoa Mai", "Hoa Cuc" };
            string[] st2 = (string[])st1.Clone();
            st2[2] = "null";
            Console.WriteLine(st1[2]);
        }

        public static void ArrayCopyTo()
        {
            var source = new[] { "Ally", "Bishop", "Billy", "sds" };
            var target = new string[4];

            source.CopyTo(target, 0);

            foreach (var item in target)
            {
                Console.WriteLine(item);
            }
        }

    }
}
