using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 不用加减乘除做加法
    /// 求两个整数之和，要求不能使用加减乘除四则运算
    /// 思路：使用位运算
    /// 1) 相加不考虑进位，相当于使用异或
    /// 2) 相加后的进位值，相当于先做与，再左移一位
    /// 3) 把第1第2步的值相加，直至没有进位出现
    /// </summary>
    [TestClass]
    public class E47_AddTwoNumbers {
        [TestMethod]
        public void Main() {
            Console.WriteLine(AddTwoNum(17,5));
        }

        public int AddTwoNum(int num1, int num2) {
            int sum;
            int carry;
            do {
                sum = num1 ^ num2;
                carry = (num1 & num2) << 1;
                num1 = sum;
                num2 = carry;
            } while (num2 != 0);
            return sum;
        }
    }
}
