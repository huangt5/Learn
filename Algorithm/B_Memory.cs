using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class B_Memory {
        [TestMethod]
        public void Main() {
            // size of int is platform (x84 x64) independant
            Console.WriteLine("int size is: " +  sizeof(int));
            Console.WriteLine("Int16 size is: " +  sizeof(Int16));
            Console.WriteLine("Int32 size is: " +  sizeof(Int32));
            Console.WriteLine("Int64 size is: " +  sizeof(Int64));

            // Struct size
            Console.WriteLine("Empty struct size is: " + Marshal.SizeOf(new EmptyStruct()));
            Console.WriteLine("Empty enum size is: " + sizeof(EmptyEnum));
            Console.WriteLine("Enum1 size is: " + sizeof(Enum1));
            Console.WriteLine("Enum2 size is: " + sizeof(Enum2));

            // size of others
            Console.WriteLine("bool size is: " + sizeof(bool));
            //Console.WriteLine("object size is: " + Marshal.SizeOf(new object()));
        }

        private struct EmptyStruct {
        }

        private enum EmptyEnum {
            
        }

        private enum Enum1 {
            Option1
        }

        private enum Enum2 {
            Option1,
            Option2
        }
    }
}
