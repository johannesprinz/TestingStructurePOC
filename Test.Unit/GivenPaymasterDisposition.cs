using NUnit.Framework;
using PayProcessor.App;

namespace Test.Unit {
    [TestFixture]
    public abstract class GivenPaymasterDisposition : GivenTimecardsAddUpToLessThanOvertime {
        [TestFixtureSetUp]
        public void GivenPaymasterDispositionSetup() {
            Employee.PayMaster = new PayMaster();
        }
    }
}