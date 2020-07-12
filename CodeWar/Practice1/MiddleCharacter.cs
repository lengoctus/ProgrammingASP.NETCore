using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWar.Practice1
{
    class MiddleCharacter
    {
        public static string GetMiddle(string s)
        {
            int length = s.Length;
            switch (length % 2)
            {
                case 0:
                    while (s.Length > 2)
                    {
                        s = s.Remove(0, 1);
                        length = s.Length;
                        s = s.Remove(length - 1, 1);
                    }
                    break;
                default:
                    while (s.Length > 1)
                    {
                        s = s.Remove(0, 1);
                        length = s.Length;
                        s = s.Remove(length-1, 1);
                    }
                    break;
            }
            return s;
        }

        public static void MainFunc()
        {
            Console.WriteLine("es".Equals(GetMiddle("test")));
            Console.WriteLine("t".Equals(GetMiddle("testing")));
            Console.WriteLine("dd".Equals(GetMiddle("middle")));
            Console.WriteLine("A".Equals(GetMiddle("A")));
        }
    }
}
