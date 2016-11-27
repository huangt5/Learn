using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class Ex02_ReverseStack {
        /// <summary>
        /// 颠倒栈
        /// 用递归颠倒一个栈。例如输入栈{1, 2, 3, 4, 5}，1在栈顶。颠倒之后的栈为{5, 4, 3, 2, 1}，5处在栈顶。
        /// </summary>
        [TestMethod]
        public void Main() {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            PrintStack(stack);
            ReverseStack(stack);
            PrintStack(stack);
        }

        private void PrintStack(Stack<int> stack) {
            foreach (var i in stack) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void ReverseStack(Stack<int> stack)
        {
            if (stack == null || stack.Count == 0)
            {
                return;
            }

            int value = stack.Pop();
            ReverseStack(stack);
            AddToStackBottom(stack, value);
        }

        private void AddToStackBottom(Stack<int> stack, int value) {
            if (stack.Count == 0) {
                stack.Push(value);
                return;
            }

            int top = stack.Pop();
            AddToStackBottom(stack, value);
            stack.Push(top);
        }
    }
}
