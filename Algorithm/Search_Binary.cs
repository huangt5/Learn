using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class Search_Binary {
        [TestMethod]
        public void Main() {
            Console.WriteLine(BinarySearch(Util.Array1, 65));
            Console.WriteLine(BinarySearch(Util.Array1, 33));
            Console.WriteLine(BinarySearch(Util.Array1, 1));
            Console.WriteLine(BinarySearch(Util.Array1, 2222));
        }

        private int BinarySearch(int[] arr, int target) {
            if (arr == null) {
                return -1;
            }
            Array.Sort(arr);
            return BinarySearch(arr, target, 0, arr.Length);
        }

        private int BinarySearch(int[] arr, int target, int start, int end) {
            if (start > end) {
                return -1;
            }
            int middle = (start + end)/2;
            if (arr[middle] > target) {
                return BinarySearch(arr, target, start, middle - 1);
            }
            if (arr[middle] < target) {
                return BinarySearch(arr, target, middle + 1, end);
            }
            return middle;
        }
    }
}