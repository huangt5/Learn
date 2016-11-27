using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp5 {
    [TestClass]
    public class CSharp2Practice
    {
        /// <summary>
        /// In C#, covariance and contravariance enable implicit reference conversion for 
        /// array types, delegate types, and generic type arguments.Covariance preserves 
        /// assignment compatibility and contravariance reverses it.
        /// </summary>
        public void CovorianceAndContravariance() {
            // Assignment compatibility. 
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type. 
            object obj = str;

            // Covariance. 
            IEnumerable<string> strings = new List<string>();
            // An object that is instantiated with a more derived type argument 
            // is assigned to an object instantiated with a less derived type argument. 
            // Assignment compatibility is preserved. 
            IEnumerable<object> objects = strings;

            // Contravariance.           
            Action<object> actObject = SetObject;
            // An object that is instantiated with a less derived type argument 
            // is assigned to an object instantiated with a more derived type argument. 
            // Assignment compatibility is reversed. 
            Action<string> actString = actObject;
        }

        /// <summary>
        /// An iterator method or get accessor performs a custom iteration over a collection. 
        /// An iterator method uses the yield return statement to return each element one at a time. 
        /// When a yield return statement is reached, the current location in code is remembered. 
        /// Execution is restarted from that location the next time the iterator function is called.
        /// </summary>
        [TestMethod]
        public void Iterator() {
            foreach (int number in SomeNumbers()) {
                Console.Write(number.ToString() + " ");
            }
        }

        private void SetObject(object o) {
        }

        private System.Collections.IEnumerable SomeNumbers() {
            yield return 3;
            yield return 5;
            yield return 8;
        }
    }
}