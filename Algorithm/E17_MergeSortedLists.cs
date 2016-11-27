using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入两个递增链表，合并链表，新链表仍是递增排序
    /// 思路：双指针逐个比较，使用递归
    /// 注意输入空值
    /// 循环时:注意多指针操作
    /// 递归代码更简洁
    /// </summary>
    [TestClass]
    public class E17_MergeSortedLists {
        [TestMethod]
        public void Main() {
            ListNode node = new ListNode() { Value = 7 };
            node = new ListNode() { Value = 5, Next = node };
            node = new ListNode() { Value = 3, Next = node };
            ListNode head1 = new ListNode() { Value = 1, Next = node };

            node = new ListNode() { Value = 8 };
            node = new ListNode() { Value = 6, Next = node };
            node = new ListNode() { Value = 4, Next = node };
            ListNode head2 = new ListNode() { Value = 2, Next = node };

            head1.Print();
            head2.Print();
            //MergeSortedListNode1(head1, head2).Print();
            MergeSortedListNode2(head1, head2).Print();
        }

        private ListNode MergeSortedListNode2(ListNode head1, ListNode head2) {
            if (head1 == null) {
                return head2;
            }
            if (head2 == null) {
                return head1;
            }
            ListNode newHead;
            if (head1.Value <= head2.Value) {
                newHead = head1;
                newHead.Next = MergeSortedListNode2(head1.Next, head2);
            } else {
                newHead = head2;
                newHead.Next = MergeSortedListNode2(head1, head2.Next);
            }
            return newHead;
        }

        private ListNode MergeSortedListNode1(ListNode head1, ListNode head2) {
            if (head1 == null) {
                return head2;
            }
            if (head2 == null) {
                return head1;
            }
            ListNode p1 = head1;
            ListNode p2 = head2;
            ListNode prev = null;
            ListNode newHead = null;

            while (true) {
                if (p1 == null) {
                    prev.Next = p2;
                    break;
                }
                if (p2 == null) {
                    prev.Next = p2;
                    break;
                }

                if (p1.Value <= p2.Value) {
                    if (prev != null) {
                        prev.Next = p1;
                    }
                    prev = p1;
                    p1 = p1.Next;
                } else {
                    if (prev != null) {
                        prev.Next = p2;
                    }
                    prev = p2;
                    p2 = p2.Next;
                }
                if (newHead == null) {
                    newHead = prev;
                }
            }

            return newHead;

        }
    }
}
