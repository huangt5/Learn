using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class B_Constructor {
        [TestMethod]
        public void Main() {
            var b = new B();
        }

        private class A {
            private int _fieldA;
            public A(int a) {
                _fieldA = a;
            }
        }

        private class B : A {
            private int _fieldB;

            public B() : this(3) {
                _fieldB = 3;
            }

            public B(int fieldB) : base(fieldB) {
                _fieldB = fieldB;
            }
        }
    }
}
