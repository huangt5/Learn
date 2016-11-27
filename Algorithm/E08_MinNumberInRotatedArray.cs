using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 把数组最开始几个元素搬到数组末尾，为数组的旋转
    /// 输入一个递增数组的旋转，找出最小值
    /// 例如3,4,5,1,2为1,2,3,4,5的一个旋转
    /// 思路：借用二分法查找，两个指针分别指向头尾，取中间位置值
    /// 如果该值大于等于指针1的值，那么最小值出现在后面
    /// 	把指针1移动到中间值位置
    /// 如果该值小于等于指针1的值，那么最小值出现在前面
    /// 	把指针2移动到中间值位置
    /// 缩小范围递归，递归调用
    /// 
    /// 最终两个指针相邻，指针2即为数组最小值
    /// 特例：
    /// 0个数字旋转
    /// 	当指针1的值小于指针2的值，那么第一个就是最小值
    /// 	处理：第一次循环，将中间指针先指向指针1
    /// 
    /// 出现重复数字
    /// 	如果指针1指针2和中间指针的值相同，使用顺序查找法
    /// </summary>
    [TestClass]
    public class E08_MinNumberInRotatedArray {
        [TestMethod]
        public void Main() {
            Console.WriteLine(FindMinNumberInRotatedArray(new int[]{3,4,5,1,2}));
            Console.WriteLine(FindMinNumberInRotatedArray(new int[]{3,4,5,6,1,2}));
            Console.WriteLine(FindMinNumberInRotatedArray(new int[]{3,4,5,6,1,2,3}));
            Console.WriteLine(FindMinNumberInRotatedArray(new int[]{2,2,2,2,1,2,2}));
            Console.WriteLine(FindMinNumberInRotatedArray(new int[]{1,1,1,1,1,1,1}));
        }

        private int FindMinNumberInRotatedArray(int[] arr) {
            if (arr == null || arr.Length == 0) {
                throw new Exception("Input error: empty array.");
            }

            int left = 0;
            int right = arr.Length-1;
            if (arr[left] < arr[right]) {
                return arr[left];
            }
            while (true) {
                int middle = (left + right) / 2;
                if (arr[left] == arr[right] && arr[right] == arr[middle]) {
                    return FindMinInOrder(arr, left, right);
                }
                if (arr[middle] <= arr[right]) {
                    right = middle;
                }
                if (arr[middle] >= arr[left]) {
                    left = middle;
                }
                if (right - left == 1) {
                    return arr[right];
                }
            }
        }

        private int FindMinInOrder(int[] arr, int left, int right) {
            for (int i = left; i < right; i++) {
                if (arr[i] > arr[i + 1]) {
                    return arr[i+1];
                }
            }
            return arr[left];
        }
    }
}
