using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输出链表中倒数第K个结点。从1开始计数
    /// 思路：两个指针，一个指针先走K-1步，然后两个指针同时走，直至第一个指针走到最后
    /// 注意输入值，链表长度等
    /// </summary>
    [TestClass]
    public class E15_KthNodeFromEnd {
        [TestMethod]
        public void Main() {
            Util.List1Head.Print();
            Console.WriteLine(GetValueOfKthNode(Util.List1Head, 1));
            Console.WriteLine(GetValueOfKthNode(Util.List1Head, 5));
            Console.WriteLine(GetValueOfKthNode(Util.List1Head, 3));
        }

        private int GetValueOfKthNode(ListNode head, int k) {
            if (head == null) {
                throw new Exception("List is empty.");
            }
            if (k <= 0) {
                throw new Exception("K is not valid.");
            }
            int advanceSteps = k - 1;
            ListNode p1 = head;
            ListNode p2 = head;

            for (int i = 0; i < advanceSteps; i++) {
                if (p1.Next == null) {
                    throw new Exception("List is too short to get last " + k + "th node.");
                }
                p1 = p1.Next;
            }
            while (true) {
                if (p1.Next == null) {
                    return p2.Value;
                }
                p1 = p1.Next;
                p2 = p2.Next;
            }
        }
    }
}
