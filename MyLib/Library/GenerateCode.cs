using System;
using System.Text;

namespace MyLib.Library
{
    public sealed class GenerateCode
    {
        /// <summary>
        /// Generate Number from start to end
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string GenerateNumber(int start, int end)
        {
            return new Random().Next(start, end).ToString();
        }

        /// <summary>
        /// Generate string with option ToLowerCase
        /// </summary>
        /// <param name="size"></param>
        /// <param name="ToLowerCase"></param>
        /// <returns></returns>
        public static string GenerateString(int size, bool ToLowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = ToLowerCase ? 'a' : 'A';
            const int letterOffset = 26;

            Random rd = new Random();
            for (int i = 0; i < size; i++)
            {
                var MyChar = (char)rd.Next(offset, offset + letterOffset);
                builder.Append(MyChar);
            }

            return ToLowerCase ? builder.ToString().ToLower() : builder.ToString();
        }


        //public static string RandomPassword(bool lowerCase)
        //{
        //    var passwordBuilder = new StringBuilder();

        //    // 4-Letters lower case   
        //    passwordBuilder.Append(GenerateString(4, lowerCase));

        //    // 4-Digits between 1000 and 9999  
        //    passwordBuilder.Append(GenerateNumber(1000, 9999));

        //    // 2-Letters upper case  
        //    passwordBuilder.Append(GenerateString(2));
        //    return passwordBuilder.ToString();
        //}

        public static string GenerateEmpCodeNTU(string CodeEmp, string Schema)
        {
            // NTU1
            var builder = new StringBuilder();
            builder.Insert(0, CodeEmp.Remove(0, 3));
            builder.Replace(builder.ToString(), Schema + (Convert.ToInt32(builder.ToString()) + 1).ToString("D8"));
            return builder.ToString();
        }
    }
}
