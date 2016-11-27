using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 把字符串转换成整数
    /// 注意特殊值输入，已经超出边界值的可能
    /// 支持先trim
    /// </summary>
    [TestClass]
    public class E49_StrToInt {
        [TestMethod]
        public void Main() {
            // Test boundry
            int num = 1;
            Console.WriteLine(int.MaxValue+num);
            Console.WriteLine(int.MinValue);
            // Test if int.Parse trim input
            int value = int.Parse(" -2 ");
            Console.WriteLine(value);

            Console.WriteLine("================");
            // Test algorithm
            Console.WriteLine(StrToInt("541"));
            Console.WriteLine(StrToInt("0"));
            Console.WriteLine(StrToInt("-12"));
            Console.WriteLine(StrToInt("+11"));
            Console.WriteLine(StrToInt("-2147483648"));
            Console.WriteLine(StrToInt("2147483647"));
            //Console.WriteLine(StrToInt("-2147483649"));
            //Console.WriteLine(StrToInt("2147483648"));
        }

        private int StrToInt(string str) {
            if (str == null) {
                throw new ArgumentException("Invalid input");
            }
            str = str.Trim();
            if (str.Length == 0) {
                throw new ArgumentException("Invalid input");
            }
            var charArr = str.ToCharArray();
            bool isNegative = charArr[0] == '-';
            long index = 0;
            if (charArr[0] == '-' || charArr[0] == '+') {
                index++;
            }
            int sum = 0;
            while (index < charArr.LongLength) {
                if (charArr[index] < '0' || charArr[index] > '9') {
                    throw new ArgumentException("Invalid input");
                }
                int n = charArr[index] - '0';
                int power = 1;
                for (int i = 0; i < charArr.Length-index-1; i++) {
                    power *= 10;
                }
                sum += power*n;
                index++;
            }
            sum = isNegative ? -sum : sum;
            if (isNegative && sum > 0 || !isNegative && sum < 0) {
                throw new OverflowException();
            }
            return sum;
        }

    }
}
