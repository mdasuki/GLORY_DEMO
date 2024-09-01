using DTO;

namespace DAL
{
    public interface IRouteRepository
    {
        RouteModel getRouteDetails(int routeId);
    }
}