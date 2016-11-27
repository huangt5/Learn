using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class B_String {
        [TestMethod]
        public void Main() {
            string hello = "hello";
            char e = hello[0];
            foreach (char c in hello) {
                Console.Write(c);
            }
            Console.WriteLine();

            Console.WriteLine("hello\0world");
        }
    }
}
