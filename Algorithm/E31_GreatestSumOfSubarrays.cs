using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 连续子数组最大和
    /// 输入一个整数数组，数组里有正数也有负数。求所有连续子数组的和的最大值。要求时间为O(n)
    /// 思路1：保存累加值sum和最大和max，当sum小于0，放弃累加，重新计算，当sum大于max，把max更新为sum
    /// </summary>
    [TestClass]
    public class E31_GreatestSumOfSubarrays {
        [TestMethod]
        public void Main() {
            int[] arr = new[] {1, -2, 3, 10, -4, 7, 2, -5};
            Console.WriteLine(FindMaxSum(arr));
        }

        private int FindMaxSum(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return 0;
            }
            int sum = 0;
            int max = int.MinValue;
            foreach (int value in arr) {
                sum += value;
                if (sum < 0) {
                    sum = 0;
                }

                if (sum > max) {
                    max = sum;
                }
            }
            return max;
        }
    }
}