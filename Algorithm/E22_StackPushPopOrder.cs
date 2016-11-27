using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 栈的压入 弹出序列
    /// 两个整数序列，第一个是栈的压入顺序，判断第二个是否为该栈的某一个弹出顺序。
    /// 假设压入栈的所有数字均不相等
    /// 思路：逐个检查pop序列，当前值要么在stack顶端，要么逐个压入push序列值，如果stack顶端找不到，并且push序列为空了，那么说明不是一个有效的pop序列
    /// </summary>
    [TestClass]
    public class E22_StackPushPopOrder {
        [TestMethod]
        public void Main() {
            int[] pushOrder = new[] {1, 2, 3, 4, 5};
            Console.WriteLine(CheckPopOrder(pushOrder, new[] {4, 5, 3, 2, 1}));
            Console.WriteLine(CheckPopOrder(pushOrder, new[] {4, 3, 5, 1, 2}));
        }

        private bool CheckPopOrder(int[] pushOrder, int[] popOrder) {
            if (popOrder == null || popOrder.Length == 0) {
                return true;
            }
            if (pushOrder == null || pushOrder.Length == 0) {
                return false;
            }
            Stack<int> stack = new Stack<int>();
            int pushIndex = 0;
            foreach (var pop in popOrder) {
                while (stack.Count == 0 || stack.Peek() != pop) {
                    if (pushIndex == pushOrder.Length) {
                        return false;
                    }
                    stack.Push(pushOrder[pushIndex++]);
                }
                stack.Pop();
            }
            return true;
        }
    }
}