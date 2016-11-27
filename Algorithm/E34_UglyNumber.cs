using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 丑数
    /// 把只包含因子2,3,5的数称作丑数Urly Number。球从小到大顺序的第1500个丑数。习惯上1当做第一个丑数。
    /// 思路：用空间换时间，先创建一个数组，保存已计算的丑数，然后分别对其中的数乘以2 3 5，取最小的那个作为可能是下一个丑数，放入数组
    /// 注意：可以保存一个指针，从某个值开始做乘法
    /// </summary>
    [TestClass]
    public class E34_UglyNumber {
        [TestMethod]
        public void Main() {
            GetUglyNumbers(30).Print();
        }

        private int[] GetUglyNumbers(int n) {
            if (n <= 0) {
                return null;
            }
            if (n == 1) {
                return new[] {1};
            }
            int[] results = new int[n];
            results[0] = 1;

            int p2 = 0;
            int p3 = 0;
            int p5 = 0;
            for (int i = 1; i < n; i++) {
                while (results[p2]*2 < results[i - 1]) p2++;
                while (results[p3]*3 < results[i - 1]) p3++;
                while (results[p5]*5 < results[i - 1]) p5++;
                results[i] = Math.Min(Math.Min(results[p2]*2, results[p3]*3), results[p5]*5);
                if (results[i]%2 == 0) p2++;
                if (results[i]%3 == 0) p3++;
                if (results[i]%5 == 0) p5++;
            }
            return results;
        }
    }
}
