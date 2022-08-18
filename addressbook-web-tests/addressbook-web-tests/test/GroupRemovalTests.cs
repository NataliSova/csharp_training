using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }
    }
}
