using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGUI.Models
{
    public class DestinationVM
    {
        public List<DTO.StationModel> LoadDestinationsData(int sourceStationId)
        {
            DAL.StationRepository st = new();
            var dest = st.GetDestinationStations(sourceStationId);
            return dest;
        }
        public List<DTO.StationModel> LoadStationModels2(int sourceStationId)
        {
            DAL.StationRepository st = new();
            var stations = st.GetDestinationStations(sourceStationId);
            return stations;
        }

        public string GetRouteDetails(int routeId)
        {
            string routeDetails = "";
            DAL.RouteRepository rt = new();
            var rtObj = rt.getRouteDetails(routeId);
            if (rtObj != null)
            {
                routeDetails += $"Today: Train No: {rtObj.train_no} from: {rtObj.departure_city} to: {rtObj.destination_city} departs at {rtObj.departure_time}";
            }
            return routeDetails;
        }
    }
}
