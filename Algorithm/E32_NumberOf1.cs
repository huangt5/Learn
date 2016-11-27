using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 从1到n整数中1出现的次数
    /// 输入一个整数n，求从1到n这个整数的十进制表示中1的出现次数
    /// 思路：递归调用，每次先计算最高位的出现次数
    /// </summary>
    [TestClass]
    public class E32_NumberOf1 {
        [TestMethod]
        public void Main() {
            // todo finsih codes
            Console.WriteLine(NumberOf1(21345));
        }

        private int NumberOf1(int n) {
            return 0;
        }
    }
}
