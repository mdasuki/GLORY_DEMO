using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class PassengerService : IPassengerService
    {
        PassengerRepository _passengerRepository = new();
        public PassengerService() { 
                    
        }
        public List<PassengerModel> GetPassengers()
        {
            return _passengerRepository.GetPassengers();
        }
    }
}
