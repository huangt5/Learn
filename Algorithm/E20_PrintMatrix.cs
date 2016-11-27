using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入一个矩阵，从外向里顺时针依次打印。
    /// 思路：递归一圈一圈打印
    /// 打印一圈时，分4个步骤打印，从左到右 从上到下 从右到左 从下到上
    /// 每个打印步骤要考虑边界值
    /// 注意：矩阵可能是厂方的
    /// </summary>
    [TestClass]
    public class E20_PrintMatrix {
        [TestMethod]
        public void Main() {
            PrintClockwise(Util.Array2D);
        }

        private void PrintClockwise(int[][] arr) {
            if (arr == null || arr.Length == 0 || arr[0] == null || arr[0].Length == 0) {
                return;
            }
            int rowLen = arr.Length;
            int colLen = arr[0].Length;
            int length = Math.Min(colLen, rowLen);
            for (int i = 0; i < Math.Ceiling(1.0*length/2); i++) {
                PrintCircle(arr, i, rowLen-i*2, colLen-i*2);
            }
        }

        private void PrintCircle(int[][] arr, int start, int rowLen, int colLen) {
            // Step 1: from left to right on top
            for (int i = 0; i < colLen; i++) {
                Console.Write(arr[start][start+i] + " ");
            }
            // Step 2: from top to down on right
            for (int i = 1; i < rowLen; i++) {
                Console.Write(arr[start+i][start+colLen-1] + " ");
            }
            // Step 3: from right to left on bottm
            for (int i = 1; i < colLen; i++) {
                Console.Write(arr[start + rowLen - 1][start + colLen - i - 1] + " ");
            }
            // Step 4: from bottom to top on left
            for (int i = 1; i < rowLen - 1; i++) {
                Console.Write(arr[start + rowLen - i - 1][start] + " ");
            }
        }
    }
}
