using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class B_ValueType {
        [TestMethod]
        public void Main() {
            MyStruct a;
            MyStruct b = new MyStruct(10);
        }

        private struct MyStruct {
            public int N;
            public MyStruct(int n) {
                N = n;
            }
        }
    }
}
