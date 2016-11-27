using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 实现double Power(double base, int exponent)，求base的exponent次方，不考虑大数
    /// 思路：注意特殊输入值
    /// 高性能算法：递归分解次方计算
    /// </summary>
    [TestClass]
    public class E11_Power {
        [TestMethod]
        public void Main() {
            Console.WriteLine(Power1(0, 8));
            Console.WriteLine(Power1(1, 8));
            Console.WriteLine(Power1(0, 0));
            Console.WriteLine(Power1(5, 0));
            Console.WriteLine(Power1(2, -3));
            Console.WriteLine(Power2(0, 8));
            Console.WriteLine(Power2(1, 8));
            Console.WriteLine(Power2(0, 0));
            Console.WriteLine(Power2(5, 0));
            Console.WriteLine(Power2(2, -3));
        }

        private double Power1(double value, int exp) {
            if (exp == 0) {
                return 1;
            }
            if (Equal(value, 0)) {
                if (exp >= 0) {
                    return 0;
                } else {
                    throw new Exception("Invalid input.");
                }
            }
            if (Equal(value, 1)) {
                return 1;
            }
            int sign = exp < 0 ? -1 : 1;
            int absExp = exp*sign;
            double result = 1;
            for (int i = 0; i < absExp; i++) {
                result *= value;
            }
            if (sign==1) {
                return result;
            } else {
                return 1/result;
            }
        }

        private double Power2(double value, int exp) {
            if (exp == 0) {
                return 1;
            }
            if (Equal(value, 0)) {
                if (exp >= 0) {
                    return 0;
                } else {
                    throw new Exception("Invalid input.");
                }
            }
            int sign = exp < 0 ? -1 : 1;
            int absExp = exp*sign;
            double result = PowerWithUnsigned(value, absExp);
            if (sign == 1) {
                return result;
            } else {
                return 1/result;
            }
        }

        private double PowerWithUnsigned(double value, int exp) {
            if (exp == 0) {
                return 1;
            }
            if (Equal(value, 1)) {
                return 1;
            }

            double result = PowerWithUnsigned(value, exp >> 1);
            result *= result;
            if ((exp & 0x1) == 1) {
                return result*value;
            }
            return result;
        }

        private bool Equal(double value1, double value2) {
            var diff = value1 - value2;
            if (diff > -0.0000001 && diff < 0.0000001) {
                return true;
            }
            return false;
        }
    }
}
