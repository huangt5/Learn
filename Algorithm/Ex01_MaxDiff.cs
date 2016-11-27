using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class Ex01_MaxDiff {
        /// <summary>
        /// 数对之差的最大值
        /// 在数组中，数字减去它右边的数字得到一个数对之差。求所有数对之差的最大值。
        /// 例如在数组{2, 4, 1, 16, 7, 5, 11, 9}中，数对之差的最大值是11，是16减去5的结果。
        /// </summary>
        [TestMethod]
        public void Main() {
            int[] arr = new[] {2, 4, 1, 16, 7, 5, 11, 9};
            Console.WriteLine(MaxDiff(arr));
        }

        /// <summary>
        /// 动态规划法
        /// </summary>
        public int MaxDiff(int[] arr) {
            if (arr == null || arr.Length < 2) {
                throw new Exception("Invalid exception");
            }
            int max = arr[0];
            int maxDiff = max - arr[1];
            for (int i = 2; i < arr.Length; i++) {
                if (arr[i - 1] > max) {
                    max = arr[i - 1];
                }
                int currentDiff = max - arr[i];
                if (currentDiff > maxDiff) {
                    maxDiff = currentDiff;
                }
            }
            return maxDiff;
        }
    }
}
