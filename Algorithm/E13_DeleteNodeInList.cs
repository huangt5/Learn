using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 给定单向链表的头指针和某节点指针，定义一个函数在O(1)的时间删除该节点
    /// 思路：顺序查找后，再删除会造成O(n)时间
    /// 直接复制指针后续节点内容，删除后续节点即可
    /// 注意：验证输入值，节点指针可能不在链表中，如需验证，需要顺序查找
    /// 注意节点可能已经是头或尾
    /// </summary>
    [TestClass]
    public class E13_DeleteNodeInList {
        [TestMethod]
        public void Main() {
            Util.List1Head.Print();
            DeleteNodeInList(Util.List1Head, Util.List1Head.Next.Next).Print();
            DeleteNodeInList(Util.List1Head, Util.List1Head.Next.Next.Next).Print();
            DeleteNodeInList(Util.List1Head, Util.List1Head).Print();
        }

        private ListNode DeleteNodeInList(ListNode head, ListNode node) {
            if (head == null) {
                return null;
            }
            if (node == null) {
                return head;
            }
            if (head == node) {
                return head.Next;
            }
            if (node.Next == null) {
                var currentNode = head;
                while (currentNode != null) {
                    if (currentNode.Next == node) {
                        currentNode.Next = null;
                    }
                    currentNode = currentNode.Next;
                }
            } else {
                node.Value = node.Next.Value;
                node.Next = node.Next.Next;
            }
            return head;
        }
    }
}
