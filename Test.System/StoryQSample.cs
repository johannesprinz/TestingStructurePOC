using NUnit.Framework;
using StoryQ;
using StoryQ.Formatting.Parameters;
using StoryQ.TextualSteps;
using System;
using System.Reflection;

namespace Test.System {
    [TestFixture]
    public class StoryQSample {
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
