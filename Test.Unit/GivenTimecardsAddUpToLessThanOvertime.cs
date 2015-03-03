using NUnit.Framework;
using PayProcessor.App;

namespace Test.Unit {
    [TestFixture]
    public abstract class GivenTimecardsAddUpToLessThanOvertime : GivenHourlyPayTypeEarningStandardRate {
        protected const int DaysPerWeek = 5;
        protected const int MaxRegularHoursPerDay = 8;

        [TestFixtureSetUp]
        public void GivenTimecardsAddUpToLessThanOvertimeSetup() {
            for (var day = 0; day < DaysPerWeek; day++) {
                HourlyPayType.AddTimeCard(new TimeCard(MaxRegularHoursPerDay));
            }
        }
    }
}