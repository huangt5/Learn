using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 用2个Stack实现一个队列，并实现appendTail和deleteHead方法
    /// 思路：
    /// appendTail
    /// 	S1 not full, s1.push
    /// 	S1 full, S2 empty, S1->S2, S1.push
    ///     		 S2 not empty, error(full)
    /// deleteHead
    /// 	S2 not empty, s2.pop
    /// 	S2 empty, S1 empty, error(empty)
    ///       		  S1 not empty, S1->S2, S2.pop
    /// </summary>
    [TestClass]
    public class E07_Use2StacksForQueue {
        [TestMethod]
        public void Main() {
            var q = new QueueByStacks<TestClass>(5);
            q.AppendTail(new TestClass(1));
            q.AppendTail(new TestClass(2));
            q.AppendTail(new TestClass(3));
            Console.WriteLine(q.DeleteHead().Value);
            Console.WriteLine(q.DeleteHead().Value);
            Console.WriteLine(q.DeleteHead().Value);
        }

        private class TestClass {
            private int _value;

            public TestClass(int value) {
                _value = value;
            }

            public int Value {
                get { return _value; }
            }

            public override string ToString() {
                return _value.ToString();
            }
        }

        private class QueueByStacks<T> where T:class {
            private int _stackSize;

            public QueueByStacks(int stackSize) {
                _stackSize = stackSize;
                _stack1 = new Stack<T>(stackSize);
                _stack2 = new Stack<T>(stackSize);
            }

            private Stack<T> _stack1;
            private Stack<T> _stack2;

            public bool AppendTail(T obj) {
                if (_stack1.Count == _stackSize) {
                    if (_stack2.Count == 0) {
                        MoveObjects();
                    } else {
                        return false;
                    }
                } 
                _stack1.Push(obj);
                return true;
            }

            public T DeleteHead() {
                if (_stack2.Count == 0) {
                    if (_stack1.Count == 0) {
                        return null;
                    } else {
                        MoveObjects();
                    }
                }
                return _stack2.Pop();
            }

            private void MoveObjects() {
                while (_stack1.Count > 0) {
                    _stack2.Push(_stack1.Pop());
                }
            }
        }
    }
}
