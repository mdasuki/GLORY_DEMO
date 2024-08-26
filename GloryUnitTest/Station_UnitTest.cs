using DAL;
namespace GloryUnitTest
{
    public class Station_UnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GetStations_Test()
        {
            StationRepository pr = new();
            var stationList = pr.GetDestinationStations(1);
            Assert.That(stationList.Count > 0);
        }
        [Test] 
        public void GetStations_Test2() 
        {
            RouteRepository rt = new();
            var routeDetails = rt.getRouteDetails(1);
            Assert.IsNotNull(routeDetails);
        }
    }
}
