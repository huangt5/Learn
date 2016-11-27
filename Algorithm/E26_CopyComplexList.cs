using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 复杂链表的复制
    /// 复杂链表中，每个节点除了Next指针外，还有Sibling指针，指向任意节点或者NULL
    /// 思路：
    /// 1. 逐个复制节点，再找出原始Sibling并复制，时间o(n2)
    /// 2. 逐个复制节点，并把原节点和新节点放入Hash表，再从hash表找到对应节点设置Sibling，时间o(n)，当消耗额外空间
    /// 3. 逐个复制节点，将新节点连在源节点后，然后设置Sibling，最后拆分链表
    /// </summary>
    [TestClass]
    public class E26_CopyComplexList {
        [TestMethod]
        public void Main() {
            Util.List1Head.Print();
            Clone(Util.List1Head).Print();
        }

        private ListNode Clone(ListNode head) {
            if (head == null) {
                return null;
            }
            // Clone nodes and insert to original list.
            ListNode node = head;
            ListNode newNode;
            while (node != null) {
                var nextNode = node.Next;
                newNode = new ListNode(node.Value);
                node.Next = newNode;
                newNode.Next = nextNode;
                node = nextNode;
            }

            // Clone sibling pointers.
            node = head;
            while (node != null) {
                newNode = node.Next;
                if (node.Sibling != null) {
                    newNode.Sibling = node.Sibling.Next;
                }
                node = newNode.Next;
            }

            // Break list.
            ListNode newHead = head.Next;
            node = head;
            newNode = newHead;
            while (newNode != null) {
                node.Next = newNode.Next;
                if (newNode.Next == null) {
                    break;
                }
                newNode.Next = newNode.Next.Next;
                newNode = newNode.Next;
                node = node.Next;
            }
            return newHead;
        }
    }
}