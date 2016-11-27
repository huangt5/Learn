using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 圆圈中最后剩下的数字
    /// 0,1,...,n-1这n个数字排成一个圆圈，从数字0开始每次从圆圈中删除第m个数字
    /// 求出这个圆圈里剩下的最后一个数字
    /// 思路1：用环形链表代表圆圈
    /// 注意下标计算
    /// 思路2：利用数学规律
    /// 要得到n个数字的最后一个，需要先得到n-1个数字的最后一个
    /// f(n,m) = 0 当n=1
    /// f(n,m) = [f(n-1,m)+m]%n 当n>1
    /// </summary>
    [TestClass]
    public class E45_LastNumberInCircle {
        [TestMethod]
        public void Main() {
            Console.WriteLine(FindLastNumber(5, 3));
            Console.WriteLine(FindLastNumber2(5, 3));
        }

        private int FindLastNumber2(int n, int m) {
            if (n < 1 || m < 1) {
                throw new Exception("Invalid input");
            }
            if (n == 1) {
                return 0;
            }
            int last = 0;
            for (int i = 2; i <= n; i++) {
                last = (last + m)%i;
            }
            return last;
        }

        private int FindLastNumber(int n, int m) {
            if (n < 1 || m < 1) {
                throw new Exception("Invalid input");
            }
            if (n == 1) {
                return 0;
            }
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++) {
                list.Add(i);
            }
            int currentIndex = 0;
            while (list.Count > 1) {
                for (int i = 0; i < m-1; i++) {
                    currentIndex++;
                    if (currentIndex == list.Count) {
                        currentIndex = 0;
                    }
                }
                list.RemoveAt(currentIndex);
                if (currentIndex == list.Count) {
                    currentIndex = 0;
                }
            }
            return list[0];
        }
    }
}
