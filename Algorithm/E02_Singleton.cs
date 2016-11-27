using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm
{
    /// <summary>
    /// 要求：延时加载，多线程安全
    /// </summary>
    [TestClass]
    public class E02_Singleton
    {
        /// <summary>
        /// Double check solution
        /// Rely on codes.
        /// </summary>
        public sealed class Singleton1 {
            private Singleton1() {
            }

            private static object syncObj = new object();

            private static Singleton1 s_instance;
            public static Singleton1 Instance {
                get {
                    if (s_instance == null) {
                        lock (syncObj) {
                            if (s_instance == null) {
                                s_instance = new Singleton1();
                            }
                        }
                    }
                    return s_instance;
                }
            }
        }

        /// <summary>
        /// Nested static field
        /// Rely on CLR
        /// </summary>
        public sealed class Singleton2
        {
            private Singleton2() {
            }

            public static Singleton2 Instance {
                get { return Nested.instance; }
            }

            private class Nested {
                static Nested() {
                    
                }
                internal static readonly  Singleton2 instance = new Singleton2();
            }
        }
    }
}
