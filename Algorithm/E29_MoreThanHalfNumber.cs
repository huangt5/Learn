using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 数组中出现次数超过一半的数字
    /// 数组中有一个数字出现的次数超过数组长度的一半，找出该数字
    /// 思路1：使用一次快速排序的Partition方法后，这个数字应该出现在数组的中位数
    /// 缺点：需要改变数组
    /// 思路2：保存一个数值tmp和次数。 当下一个数字和tmp相同，次数加一， 当下一个数字和tmp不同，则次数减一，
    /// 当次数变为0，需要保存下一个数字并且把次数设为1
    /// 最后tmp即为要找的数字
    /// </summary>
    [TestClass]
    public class E29_MoreThanHalfNumber {
        [TestMethod]
        public void Main() {
            Console.WriteLine(FindMoreThanHalfNumber(new []{1,2,3,2,2,2,5,4,2}));
        }

        private int FindMoreThanHalfNumber(int[] arr) {
            if (arr == null || arr.Length == 0) {
                throw new Exception("Array is empty");
            }
            int tmp = arr[0];
            int count = 1;
            for (int i = 1; i < arr.Length; i++) {
                if (count == 0) {
                    tmp = arr[i];
                    count = 1;
                } else if (tmp == arr[i]) {
                    count++;
                } else {
                    count--;
                }
            }
            return tmp;
        }
    }
}
