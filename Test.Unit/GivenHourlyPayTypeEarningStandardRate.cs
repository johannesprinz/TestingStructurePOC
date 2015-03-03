using NUnit.Framework;
using PayProcessor.App;

namespace Test.Unit {
    [TestFixture]
    public abstract class GivenHourlyPayTypeEarningStandardRate : GivenAnEmployee {
        protected HourlyPayType HourlyPayType;
        protected const int StandardHourlyRate = 1000;

        [TestFixtureSetUp]
        public void GivenHourlyPayTypeEarningStandardRateSetup() {
            HourlyPayType = new HourlyPayType(StandardHourlyRate);
            Employee.PayType = HourlyPayType;
        }
    }
}