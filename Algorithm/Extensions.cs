using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm {
    public static class Extensions {
        public static void Swap(this int[] arr, int i, int j) {
            int number = arr[i];
            arr[i] = arr[j];
            arr[j] = number;
        }

        public static void Swap(this char[] str, int i, int j) {
            char temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

        public static void Print(this int[] arr) {
            foreach (var s in arr) {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }

        public static void Print(this ListNode head) {
            var node = head;
            while (node != null) {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
            Console.WriteLine();
        }

        public static void Print(this char[] str) {
            foreach (char c in str) {
                if (c != '\0') {
                    Console.Write(c);
                } else {
                    break;
                }
            }
            Console.WriteLine();
        }

        public static void PrintPreorder(this BinaryTreeNode tree) {
            if (tree == null) {
                return;
            }
            Console.Write(tree.Value + " ");
            tree.Left.PrintPreorder();
            tree.Right.PrintPreorder();
        }

        public static void PrintInorder(this BinaryTreeNode tree) {
            if (tree == null) {
                return;
            }
            tree.Left.PrintInorder();
            Console.Write(tree.Value + " ");
            tree.Right.PrintInorder();
        }

        public static void PrintByRight(this BinaryTreeNode tree) {
            while (tree != null) {
                Console.Write(tree.Value + " ");
                tree = tree.Right;
            }
            Console.WriteLine();
        }

        public static void PrintByLeft(this BinaryTreeNode tree) {
            while (tree != null) {
                Console.Write(tree.Value + " ");
                tree = tree.Left;
            }
            Console.WriteLine();
        }
    }
}