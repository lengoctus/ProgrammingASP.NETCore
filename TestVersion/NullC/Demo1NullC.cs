using System;
using System.Collections.Generic;
using System.Text;

namespace TestVersion.NullC
{
    class Demo1NullC
    {
        public static void NullCMain()
        {
            var migue1 = new Person("le", "Ngoc tu");
            var length = GetMiddleNameLength(migue1);

            Console.WriteLine(length);

        }

        static int GetMiddleNameLength(Person? person)
        {
            person!.MiddleName = "ahih";
            return person!.MiddleName!.Length;
        }
    }
}
