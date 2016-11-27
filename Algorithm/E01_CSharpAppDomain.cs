using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm
{
    [TestClass]
    public class E01_CSharpAppDomain
    {
        /// <summary>
        /// 静态变量会在每个AppDomain中有一份独立的拷贝
        /// A继承自MarshalByRefObject,因此a在default domain中指向NewDomain的代理,实例在NewDomain中.
        /// b会在default domain中创建一个实例的拷贝
        /// </summary>
        [TestMethod]
        public void Main() {
            String assembly = Assembly.GetExecutingAssembly().FullName;
            assembly = "Algorithm.dll";
            AppDomain domain = AppDomain.CreateDomain("NewDomain");

            A.Number = 10;
            String nameOfA = typeof (A).FullName;
            A a = domain.CreateInstanceFromAndUnwrap(assembly, nameOfA) as A;
            a.SetNumber(20);
            Console.WriteLine("Number in class A is {0}", A.Number);

            B.Number = 10;
            String nameOfB = typeof (B).FullName;
            B b = domain.CreateInstanceFromAndUnwrap(assembly, nameOfB) as B;
            b.SetNumber(20);
            Console.WriteLine("Number in class B is {0}", B.Number);
        }

        [Serializable]
        class A : MarshalByRefObject {
            public static int Number;

            public void SetNumber(int value) {
                Number = value;
            }
        }

        [Serializable]
        class B {
            public static int Number;

            public void SetNumber(int value) {
                Number = value;
            }
        }
    }
}
