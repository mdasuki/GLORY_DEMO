using DAL;

namespace GloryUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPassengers_Test()
        {
            PassengerRepository pr = new PassengerRepository();
            var passengerList = pr.GetPassengers();
            Assert.That(passengerList.Count > 0);
        }
        [Test]
        public void GetPassenger_Test()
        {
            PassengerRepository pr = new PassengerRepository();
            var passenger = pr.GetPassenger("7701235555");
            Assert.IsNotNull(passenger);
        }
        [Test]
        public void GetCurrentUser_Test()
        {
            var cu = CurrentUser.Instance.GetCurrentUser();
            Assert.IsNotNull(cu);
        }
    }
}