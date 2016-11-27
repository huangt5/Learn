using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 不能被继承的类
    /// 思路1：设置private构造函数
    /// </summary>
    [TestClass]
    public class E48_SealedClass {
        [TestMethod]
        public void Main() {
        }

        private class SealedClass {
            private SealedClass() {
            }
        }

        // Compilation error.
        //private class MyClass : SealedClass
        //{
        //}
    }
}