using System;

namespace Algorithm
{
    public static class Util
    {
        public static int[] Array1 = { 4, 8, 2222, 2, 1, 121, 13, 434, 56, 1111, 65, 7, 8, 88 };
        public static int[] Array2 = {1, 2, 4, 7, 11, 15};
        private static ListNode _list1Head;
        private static BinaryTreeNode _tree1;
        private static int[][] _array2D;
        private static BinaryTreeNode _tree2;

        public static int[][] Array2D {
            get {
                if (_array2D == null) {
                    _array2D = new[] {
                        new[] {1, 2, 3, 4},
                        new[] {5, 6, 7, 8},
                        new[] {9, 10, 11, 12},
                        new[] {13, 14, 15, 16},
                    };
                }
                return _array2D;
            }
        }
        public static ListNode List1Head {
            get {
                if (_list1Head == null) {
                    ListNode item5 = new ListNode() { Value = 5 };
                    ListNode item4 = new ListNode() { Value = 4, Next = item5};
                    ListNode item3 = new ListNode() { Value = 3, Next = item4};
                    ListNode item2 = new ListNode() { Value = 2, Next = item3 };
                    _list1Head = new ListNode() { Value = 1, Next = item2 };
                }
                return _list1Head;
            }
        }

        /// <summary>
        ///     8
        ///   8   7
        /// 9   2
        ///   4   7
        /// </summary>
        public static BinaryTreeNode Tree1 {
            get {
                if (_tree1 == null) {
                    _tree1 = new BinaryTreeNode(8) {
                        Left = new BinaryTreeNode(8) {
                            Left = new BinaryTreeNode(9),
                            Right = new BinaryTreeNode(2) {
                                Left = new BinaryTreeNode(4),
                                Right = new BinaryTreeNode(7)
                            },
                        },
                        Right = new BinaryTreeNode(7)
                    };
                }
                return _tree1;
            }
        }

        /// <summary>
        /// Sorted binary tree
        ///      10
        ///   6      14
        /// 4   8  12  16
        /// </summary>
        public static BinaryTreeNode Tree2 {
            get {
                if (_tree2 == null) {
                    _tree2 = new BinaryTreeNode(10) {
                        Left = new BinaryTreeNode(6) {
                            Left = new BinaryTreeNode(4),
                            Right = new BinaryTreeNode(8)
                        },
                        Right = new BinaryTreeNode(14) {
                            Left = new BinaryTreeNode(12),
                            Right = new BinaryTreeNode(16)
                        }
                    };
                }
                return _tree2;
            }
        }
    }

    public class ListNode {
        public ListNode(int value) {
            Value = value;
        }

        public ListNode() {
        }

        public ListNode Next { get; set; }
        public ListNode Sibling { get; set; }
        public int Value { get; set; }
    }

    public class BinaryTreeNode {
        public BinaryTreeNode() {
        }

        public BinaryTreeNode(int value) {
            Value = value;
        }

        public int Value { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        
    }
}
