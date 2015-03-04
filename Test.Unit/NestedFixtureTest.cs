using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test.Unit {

    public class ConcreteFixture : BaseFixture {
        public class NestedFixtureTest {
            [SetUp]
            public void NestedFixtureTestSetup() {
                Messages.Enqueue("NestedFixtureTestSetup");
            }

            [Test]
            public void NestedFixtureTest01() {
                Messages.Enqueue("NestedFixtureTest");
            }

            [TearDown]
            public void NestedFixtureTestTeardown() {
                Messages.Enqueue("NestedFixtureTestTeardown");
            }
        }

        public class SubBaseFixture {
            [TestFixtureSetUp]
            public void SubBaseFixtureSetup() {
                Messages.Enqueue("SubBaseFixtureSetup");
            }

            [TestFixtureTearDown]
            public void SubBaseFixtureTeardown() {
                Messages.Enqueue("SubBaseFixtureTeardown");
            }
            public class SubNestedFixtureTest : SubBaseFixture {
                [SetUp]
                public void SubNestedFixtureTestSetup() {
                    Messages.Enqueue("SubNestedFixtureTestSetup");
                }

                [Test]
                public void SubNestedFixtureTest01() {
                    Messages.Enqueue("SubNestedFixtureTest");
                }

                [TearDown]
                public void SubNestedFixtureTestTeardown() {
                    Messages.Enqueue("SubNestedFixtureTestTeardown");
                }
            }
        }
    }

    [TestFixture]
    public abstract class BaseFixture {

        public static Queue<string> Messages = new Queue<string>();

        [TestFixtureSetUp]
        public void BaseFixtureSetup() {
            Messages.Enqueue("BaseFixtureSetup");
        }

        [TestFixtureTearDown]
        public void BaseFixtureTeardown() {
            Messages.Enqueue("BaseFixtureBaseFixtureTeardown");
            while (Messages.Count > 0) {
                Console.WriteLine(Messages.Dequeue());
            }
        }
    }
}
