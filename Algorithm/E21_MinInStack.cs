using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 包含min函数的栈
    /// 实现栈的数据结构，包含一个min函数，调用min push pop时间都是O(1)
    /// 思路：利用另一个辅助栈，辅助栈只push最小值，弹出时随数据栈一起弹出
    /// </summary>
    [TestClass]
    public class E21_MinInStack {
        [TestMethod]
        public void Main() {
            MinStack stack = new MinStack();
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);
            Assert.AreEqual(1, stack.Min());
            stack.Pop();
            Assert.AreEqual(4, stack.Min());
        }

        private class MinStack {
            private Stack<int> _dataStack = new Stack<int>();
            private Stack<int> _minStack = new Stack<int>();

            public void Push(int value) {
                _dataStack.Push(value);
                if (_minStack.Count == 0 || _minStack.Peek() > value) {
                    _minStack.Push(value);
                } else {
                    _minStack.Push(_minStack.Peek());
                }
            }

            public int Pop() {
                _minStack.Pop();
                return _dataStack.Pop();
            }

            public int Min() {
                return _minStack.Peek();
            }
        }
    }
}
