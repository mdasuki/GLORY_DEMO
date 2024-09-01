using DTO;

namespace DAL
{
    public interface IStationRepository
    {
        List<StationModel> GetDestinationStations(int sourceStationId);
    }
}