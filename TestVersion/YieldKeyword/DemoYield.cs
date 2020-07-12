using System;
using System.Collections.Generic;
using System.Text;

namespace TestVersion.YieldKeyword
{
    class DemoYield
    {
        public List<int> ListInt = new List<int>();

        void FillValue()
        {
            ListInt.Add(1);
            ListInt.Add(2);
            ListInt.Add(3);
            ListInt.Add(4);
            ListInt.Add(5);
        }

        public void DemoYield_Main()
        {
            FillValue();
            foreach (var item in Filter())
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerable<int> Filter() {
            for (int i = 0; i < ListInt.Count; i++)
            {
                if (ListInt[i] > 3)
                {
                    yield return ListInt[i];
                }
            }
        }
    }
}
