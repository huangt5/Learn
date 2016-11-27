using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 斐波那契数列
    /// n=0,f=0
    /// n=1,f=1
    /// f(n)=f(n-1)+f(n-2)
    /// 思路：递归存在严重性能问题，因为有许多重复计算
    /// 使用循环，从下往上计算
    /// </summary>
    [TestClass]
    public class E09_Fibonacci {
        [TestMethod]
        public void Main() {
            var startTime = DateTime.Now;
            Console.WriteLine("Fib(10) = " + CalInRecursive(10));
            Console.WriteLine("Calculate in recursive mode consume: " + (DateTime.Now-startTime).TotalSeconds + "s");
            startTime = DateTime.Now;
            Console.WriteLine("Fib(20) = " + CalInRecursive(20));
            Console.WriteLine("Calculate in recursive mode consume: " + (DateTime.Now-startTime).TotalSeconds + "s");
            startTime = DateTime.Now;
            Console.WriteLine("Fib(30) = " + CalInRecursive(30));
            Console.WriteLine("Calculate in recursive mode consume: " + (DateTime.Now-startTime).TotalSeconds + "s");
            startTime = DateTime.Now;
            Console.WriteLine("Fib(40) = " + CalInRecursive(40));
            Console.WriteLine("Calculate in recursive mode consume: " + (DateTime.Now-startTime).TotalSeconds + "s");

            startTime = DateTime.Now;
            Console.WriteLine("Fib(10) = " + CalInLoop(10));
            Console.WriteLine("Calculate in loop mode consume: " + (DateTime.Now - startTime).TotalSeconds + "s");
            startTime = DateTime.Now;
            Console.WriteLine("Fib(20) = " + CalInLoop(20));
            Console.WriteLine("Calculate in loop mode consume: " + (DateTime.Now - startTime).TotalSeconds + "s");
            startTime = DateTime.Now;
            Console.WriteLine("Fib(30) = " + CalInLoop(30));
            Console.WriteLine("Calculate in loop mode consume: " + (DateTime.Now - startTime).TotalSeconds + "s");
            startTime = DateTime.Now;
            Console.WriteLine("Fib(40) = " + CalInLoop(40));
            Console.WriteLine("Calculate in loop mode consume: " + (DateTime.Now - startTime).TotalSeconds + "s");
        }

        private int CalInRecursive(int n) {
            if (n == 0) {
                return 0;
            }
            if (n == 1) {
                return 1;
            }
            return CalInRecursive(n - 1) + CalInRecursive(n - 2);
        }

        private int CalInLoop(int n) {
            if (n == 0) {
                return 0;
            }
            if (n == 1) {
                return 1;
            }
            int cal_2 = 0;
            int cal_1 = 1;
            int result = 0;
            for (int i = 2; i <= n; i++) {
                result = cal_2 + cal_1;
                cal_2 = cal_1;
                cal_1 = result;
            }
            return result;
        }
    }
}
