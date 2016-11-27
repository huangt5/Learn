using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 两个链表的第一个公共节点
    /// 输入两个链表，找出他们的第一个公共结点
    /// 思路1：把链表各自push到栈中，逐个弹出，直至top不相等
    /// 思路2：先各自扫描一遍得出两个链表的各自长度，设置2个指针，使长的链表先走几步，然后指针一起移动，直至指向相同节点
    /// </summary>
    [TestClass]
    public class E37_FirstCommonNodesInLists {
        [TestMethod]
        public void Main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node6;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;

            Console.WriteLine(GetFirstCommonNode(node1, node4).Value);
            Console.WriteLine(GetFirstCommonNode2(node1, node4).Value);
        }

        private ListNode GetFirstCommonNode2(ListNode list1, ListNode list2) {
            if (list1 == null || list2 == null) {
                return null;
            }
            ListNode p1 = list1;
            ListNode p2 = list2;
            int len1 = 0;
            int len2 = 0;
            while (p1 != null) {
                len1++;
                p1 = p1.Next;
            }
            while (p2 != null) {
                len2++;
                p2 = p2.Next;
            }
            p1 = list1;
            p2 = list2;
            if (len1 < len2) {
                for (int i = 0; i < len2 - len1; i++) {
                    p2 = p2.Next;
                }
            } else {
                for (int i = 0; i < len1 - len2; i++) {
                    p1 = p1.Next;
                }
            }
            while (p1 != null && p2 != null) {
                if (p1 == p2) {
                    return p1;
                }
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return null;
        }
        /// <summary>
        /// Use stack
        /// </summary>
        private ListNode GetFirstCommonNode(ListNode list1, ListNode list2) {
            if (list1 == null || list2 == null) {
                return null;
            }
            Stack<ListNode> stack1 = new Stack<ListNode>();
            Stack<ListNode> stack2 = new Stack<ListNode>();
            ListNode node = list1;
            while (node != null) {
                stack1.Push(node);
                node = node.Next;
            }
            node = list2;
            while (node != null) {
                stack2.Push(node);
                node = node.Next;
            }
            ListNode commonNode = null;
            while (stack1.Count > 0 && stack2.Count > 0) {
                if (stack1.Peek() == stack2.Peek()) {
                    commonNode = stack1.Pop();
                    stack2.Pop();
                } else {
                    return commonNode;
                }
            }
            return null;
        }
    }
}
