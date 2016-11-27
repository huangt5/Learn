using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入链表头结点，从尾到头打印每个节点的值
    /// 思路：利用Stack结构。也可以用递归调用（递归时会有Stack操作）
    /// </summary>
    [TestClass]
    public class E05_PrintListFromEnd {
        [TestMethod]
        public void Main() {
            ListNode item3 = new ListNode(){Value = 3};
            ListNode item2 = new ListNode(){Value = 2, Next = item3};
            ListNode item1 = new ListNode(){Value = 1, Next = item2};
            PrintList(item1);
        }

        private void PrintList(ListNode head) {
            if (head == null) {
                return;
            }
            PrintList(head.Next);
            Console.Write(head.Value + " ");
        }
    }
}
