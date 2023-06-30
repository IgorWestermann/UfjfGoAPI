using UfjfGoAPI.DAL;
using UfjfGoAPI.Domain.DTO.Rides;

namespace UfjfGoAPI.Services.Base
{
    public class RideService
    {
        private readonly AppDbContext _db;

        public RideService(AppDbContext db)
        {
            this._db = db;
        }

        public ServiceResponse<RideResponse> CreateNewRide(RideCreateRequest request)
        {

        }

        public IEnumerable<RideResponse> Find()
        {

        }

        public ServiceResponse<RideResponse> FindById(int id)
        {

        }

        public ServiceResponse<RideResponse> Edit(int id, RideUpdateRequest model)
        {

        }

        public ServiceResponse<RideResponse> Delete(int id)
        {

        }



    }
}
