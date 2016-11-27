using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class B_FieldInitializer {
        [TestMethod]
        public void Main() {
            Test t = new Test();
            Console.WriteLine(Test.s_fieldB);
        }

        private class Test {
            public static int s_fieldA = 1;
            public static int s_fieldC;
            public int _fieldA = 9;

            static Test() {
                s_fieldA = 1;
                s_fieldB = 2;
            }

            public Test() {
                s_fieldB = 3;
            }

            public int _fieldB = 5;
            public static int s_fieldB = 6;
        }
    }
}
