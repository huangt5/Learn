using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 扑克牌的顺子
    /// 从扑克牌中随机抽5张，判断是不是顺子。
    /// 2~10本身为数字，A为1，J为11，Q为12，K为13，大小王代表任意数字
    /// 思路：创建长度为5的整数数组，对其排序，把大小王表示为0以便区分
    /// 找出0的个数，从非零开始扫描
    /// 统计出各个相邻数字的gap
    /// 比较0的个数和gap
    /// </summary>
    [TestClass]
    public class E44_ContinuousCards {
        [TestMethod]
        public void Main() {
            Console.WriteLine(IsContinuous(new []{4,1,0,5,3}));
        }

        private bool IsContinuous(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return false;
            }
            Array.Sort(arr, 0, arr.Length);

            int zeroCount = arr.Count(num => num == 0);

            int small = zeroCount;
            int big = small + 1;
            int gap = 0;
            while (big < arr.Length) {
                if (arr[small] == arr[big]) {
                    return false;
                }
                gap += arr[big] - arr[small] - 1;
                small++;
                big++;
            }
            return gap <= zeroCount;
        }
    }
}
