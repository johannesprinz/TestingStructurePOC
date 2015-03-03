using NUnit.Framework;
using PayProcessor.App;

namespace Test.Unit {
    [TestFixture(Description = "GivenAnEmployee_")]
    public abstract class GivenAnEmployee {
        protected Employee Employee;

        [TestFixtureSetUp]
        public void GivenAnEmployeeSetup() {
            Employee = new Employee("Bob");
        }
    }
}