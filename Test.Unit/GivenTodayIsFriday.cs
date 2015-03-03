using FluentAssertions;
using NUnit.Framework;
using PayProcessor.App;
using System;
using System.Linq;

namespace Test.Unit {
    [TestFixture]
    public class GivenTodayIsFriday : GivenPaymasterDisposition {
        private DateTime _today;

        [TestFixtureSetUp]
        public void GivenTodayIsFridaySetup() {
            _today = new DateTime(2015, 3, 6);
        }

        [Test]
        public void WhenPayrollIsRun_ThenPaymasterWillHoldCheckForHoursWorkedTimesHourlyRate() {
            var payroll = new Payroll();
            payroll.Add(Employee);
            payroll.Run(_today);
            var payMaster = Employee.PayMaster;
            var checks = payMaster.HeldPayChecks;
            checks.Should().HaveCount(1);
            var check = checks.First();
            check.Amount.Should().Be(StandardHourlyRate * MaxRegularHoursPerDay * DaysPerWeek);
        }
    }
}
