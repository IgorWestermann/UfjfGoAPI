using Microsoft.EntityFrameworkCore;
using UfjfGoAPI.DAL;
using UfjfGoAPI.Domain.DTO.Rides;
using UfjfGoAPI.Domain.Entity;
using UfjfGoAPI.Services.Base;

namespace UfjfGoAPI.Services
{
    public class RideService
    {
        private readonly AppDbContext _db;


        public RideService(AppDbContext db)
        {
            this._db = db;
        }

        public ServiceResponse<RideResponse> CreateNewRide(RideCreateRequest model)
        {

            var newRide = new Ride()
            {
                UserId = model.UserId,
                Date = model.Date,
                From = model.From,
                Destination = model.Destination,
                OnlyWoman = model.OnlyWoman,
                Vagas = model.Vagas
            };

            _db.Add(newRide);
            _db.SaveChanges();

            return new ServiceResponse<RideResponse>(new RideResponse(newRide));
        }

        public IEnumerable<RideResponse> Find()
        {
            var result = _db.Rides.ToList();

            IEnumerable<RideResponse> rideList = result.Select(x => new RideResponse(x));

            return rideList;
        }

        public ServiceResponse<RideResponse> FindById(int id)
        {
            var result = _db.Rides.Where(ride => ride.RideId == id).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<RideResponse>("Ride not found");

            return new ServiceResponse<RideResponse>(new RideResponse(result));
        }
        public IEnumerable<RideResponse> FindByUserId(int id)
        {
            var result = _db.Rides.Where(ride => ride.UserId == id).ToList();

            IEnumerable<RideResponse> ridesByUser = result.Select(x => new RideResponse(x));

            return ridesByUser;
        }

        public ServiceResponse<RideResponse> Edit(int id, RideUpdateRequest model)
        {
            var result = _db.Rides.Where(ride => ride.RideId == id).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<RideResponse>("Ride not found");

            result.Vagas = model.Vagas;

            _db.Rides.Add(result).State = EntityState.Modified;
            _db?.SaveChanges();

            return new ServiceResponse<RideResponse>(new RideResponse(result));
        }

        public ServiceResponse<bool> Delete(int id)
        {
            var result = _db.Rides.Where(ride => ride.RideId == id).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<bool>("User not found");

            _db?.Rides.Remove(result);
            _db?.SaveChanges();

            return new ServiceResponse<bool>(true);
        }
    }
}
