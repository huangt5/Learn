using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 和为s的连续正整数序列
    /// 输入一个正数s，打印出所有和为s的连续正数序列（至少含有两个数）。
    /// 思路：设置small=1和big=2，分别表示序列最小值和最大值
    /// small+big大于s，small加一，去掉较小的值
    /// small+big小于s, big加一，增加较大的值
    /// 直到small加到(s+1)/2为止
    /// </summary>
    [TestClass]
    public class E41_2_ContinueSequenceWithSum {
        [TestMethod]
        public void Main() {
            PrintSequenceWithSum(15);
        }

        private void PrintSequenceWithSum(int s) {
            if (s < 3) {
                return;
            }
            int small = 1;
            int big = 2;
            int sum = small + big;
            while (small < (s+1)/2) {
                if (sum == s) {
                    // Print sequence
                    for (int i = small; i <= big; i++) {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();
                    sum -= small;
                    small++;
                } else if (sum < s) {
                    big++;
                    sum += big;
                } else {
                    sum -= small;
                    small++;
                }
            }
        }
    }
}
