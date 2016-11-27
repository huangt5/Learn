using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 求1+2+...+n
    /// 不能用乘除法 for while if else swith case求和
    /// </summary>
    [TestClass]
    public class E46_Accumulate {
        [TestMethod]
        public void Main() {
            _sums = new BaseSum[2];
            _sums[0] = new BaseSum();
            _sums[1] = new SubSum();

            Console.WriteLine(_sums[1].Sum(10));
        }

        private static BaseSum[] _sums;

        private class BaseSum {
            public virtual int Sum(int n) {
                return 0;
            }
        }

        private class SubSum : BaseSum {
            public override int Sum(int n) {
                // todo find a way to convert n to 0 or 1
                int index = n == 0 ? 0 : 1;
                return _sums[index].Sum(n - 1) + n;
            }
        }
    }
}
