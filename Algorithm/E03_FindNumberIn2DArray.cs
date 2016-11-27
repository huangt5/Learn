using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 二维数组，每行从左到右递增排序，每列从上到下递增排序，输入一个数，判断数组中是否存在
    /// 思路：从数组右上角开始找，如果比目标大，去掉一列，如果比目标小，去掉一行
    /// </summary>
    [TestClass]
    public class E03_FindNumberIn2DArray {
        [TestMethod]
        public void Main() {
            int[][] arr = {
                new []{ 1, 2, 8, 9},
                new []{ 2, 4, 9, 12},
                new []{ 4, 7, 10, 13},
                new []{ 6, 8, 11, 15}
            };

            Console.WriteLine(FindNumber(arr, 6));
        }

        private bool FindNumber(int[][] arr, int target) {
            if (arr == null || arr.Length == 0) {
                return false;
            }

            int row = 0;
            int col = arr[0].Length - 1;

            while (col >= 0 && row < arr.Length) {
                if (arr[row][col] == target) {
                    return true;
                }
                if (arr[row][col] > target) {
                    col--;
                } else {
                    row++;
                }
            }
            return false;
        }
    }
}
