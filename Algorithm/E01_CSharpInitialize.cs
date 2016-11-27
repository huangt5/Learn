using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm
{
    /// <summary>
    /// 构造函数先初始化成员变量,再执行函数内语句.
    /// </summary>
    [TestClass]
    public class E01_CSharpInitialize
    {
        [TestMethod]
        public void Main() {
            B b = new B();
        }

        class A {
            public A(string text) {
                Console.WriteLine(text);
            }
        }

        class B {
            static A a1 = new A("a1"); 
            A a2 = new A("a2");

            static B() {
                a1 = new A("a3");
            }

            public B() {
                a2 = new A("a4");
            }
        }
    }
}
