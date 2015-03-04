using FluentAssertions;
using NUnit.Framework;
using PayProcessor.App;
using StoryQ;
using StoryQ.Formatting.Parameters;
using StoryQ.TextualSteps;
using System;
using System.Linq;
using System.Reflection;

namespace Test.System {
    [TestFixture]
    public class StoryQSample {
        [Test]
        public void PayrollTest() {
            new Story("Paymaster")
                .InOrderTo("Get paid for the hours I work")
                .AsA("Employee")
                .IWant("To be paid the correct amount")
                .WithScenario("Standard pay and no overtime")
                .Given(GivenAnEmployeeSetup)
                .And(GivenHourlyPayTypeEarningStandardRateSetup)
                .And(GivenTimecardsAddUpToLessThanOvertimeSetup)
                .And(GivenPaymasterDispositionSetup)
                .And(GivenTodayIsFridaySetup)
                .When(RunPayroll)
                .Then(PaymasterWillHaveaCheckForHoursWorkedTimesHourlyRate);
        }

        private Employee _employee;

        private void GivenAnEmployeeSetup() {
            _employee = new Employee("Bob");
        }

        private HourlyPayType _hourlyPayType;
        private const int StandardHourlyRate = 1000;

        private void GivenHourlyPayTypeEarningStandardRateSetup() {
            _hourlyPayType = new HourlyPayType(StandardHourlyRate);
            _employee.PayType = _hourlyPayType;
        }

        private const int DaysPerWeek = 5;
        private const int MaxRegularHoursPerDay = 8;

        private void GivenTimecardsAddUpToLessThanOvertimeSetup() {
            for (var day = 0; day < DaysPerWeek; day++) {
                _hourlyPayType.AddTimeCard(new TimeCard(MaxRegularHoursPerDay));
            }
        }

        private void GivenPaymasterDispositionSetup() {
            _employee.PayMaster = new PayMaster();
        }

        private DateTime _today;

        private void GivenTodayIsFridaySetup() {
            _today = new DateTime(2015, 3, 6);
        }

        private void RunPayroll() {
            var payroll = new Payroll();
            payroll.Add(_employee);
            payroll.Run(_today);
        }

        private void PaymasterWillHaveaCheckForHoursWorkedTimesHourlyRate() {
            var payMaster = _employee.PayMaster;
            var checks = payMaster.HeldPayChecks;
            checks.Should().HaveCount(1);
            var check = checks.First();
            check.Amount.Should().Be(StandardHourlyRate * MaxRegularHoursPerDay * DaysPerWeek);
        }

        [Test]
        public void Given_Scenario() {
            new Story("Data Safety")
              .InOrderTo("Keep my data safe")
              .AsA("User")
              .IWant("All credit card numbers to be encrypted")
                  .WithScenario("submitting shopping cart")
                    .Given(IHaveTypedMyCreditCardNumberIntoTheCheckoutPage)
                    .When(IClickThe_Button, "Buy")
                      .And(TheBrowserPostsMyCreditCardNumberOverTheInternet)
                    .Then(TheForm_BePostedOverHttps, true)
                    .ExecuteWithReport(MethodBase.GetCurrentMethod());
        }

        [Test]
        public void PendingExample() {
            new Story("Data Safety")
                .InOrderTo("Keep my data safe")
                .AsA("User")
                .IWant("All credit card numbers to be encrypted")

                .WithScenario("submitting shopping cart")
                    .Given("I have typed my credit card number into the checkout page")
                    .When(IClickThe_Button, "Buy")
                        .And("the browser posts my credit card number over the internet")
                    .Then("the form should be posted over https")
                .ExecuteWithReport(MethodBase.GetCurrentMethod());

        }

        [Test]
        public void FailingExample() {
            new Story("Data Safety")
                .InOrderTo("Keep my data safe")
                .AsA("User")
                .IWant("All credit card numbers to be encrypted")

                .WithScenario("submitting shopping cart")
                    .Given("I have typed my credit card number into the checkout page")
                    .When(IClickThe_Button, "non existent")
                        .And("the browser posts my credit card number over the internet")
                    .Then(() => { throw new Exception("Oh no again!"); })
            .ExecuteWithReport(MethodBase.GetCurrentMethod());
        }

        private void TheForm_BePostedOverHttps([BooleanParameterFormat("should", "should not")]bool isHttps) { }

        private void TheBrowserPostsMyCreditCardNumberOverTheInternet() { }

        private void IHaveTypedMyCreditCardNumberIntoTheCheckoutPage() { }

        private void IClickThe_Button(string buttonName) {
            if (buttonName != "Buy")
                throw new Exception("No button with that name found!");
        }
    }
}
