using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 反转链表，输入链表头结点，反转链表，并输出头结点
    /// 基本链表操作
    /// 要注意输入值的有效性
    /// 注意指针操作，尤其最后一个节点的Next
    /// </summary>
    [TestClass]
    public class E16_ReverseList {
        [TestMethod]
        public void Main() {
            Util.List1Head.Print();
            ReverseList(Util.List1Head).Print();
        }

        private ListNode ReverseList(ListNode head) {
            if (head == null || head.Next == null) {
                return head;
            }
            ListNode currentNode = head;
            ListNode prevNode = null;
            while (currentNode != null) {
                ListNode nextNode = currentNode.Next;
                currentNode.Next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            return prevNode;
        }
    }
}