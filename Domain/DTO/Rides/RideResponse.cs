using UfjfGoAPI.Domain.Entity;

namespace UfjfGoAPI.Domain.DTO.Rides
{
    public class RideResponse
    {
        public int RideId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Vagas { get; set; }
        public string? From { get; set; }
        public string? Destination { get; set; }
        public bool OnlyWoman { get; set; }

        public RideResponse(Ride rides)
        {
            RideId = rides.RideId;
            UserId = rides.UserId;
            Date = rides.Date;
            Vagas = rides.Vagas;
            From = rides.From;
            Destination = rides.Destination;
            OnlyWoman = rides.OnlyWoman;
        }
    }
}
