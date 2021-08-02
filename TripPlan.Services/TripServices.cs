using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlan.Data;
using TripPlan.Model.Trip;

namespace TripPlan.Services
{
    public class TripServices
    {
        private readonly Guid _userId;
        public TripServices(Guid userId)
        {
            _userId = userId;
        }


        //Create trip 
        public bool CreateTrip(TripCreate model)
        {
            var entity =
                new Trip()
                {
                    UserID = _userId,
                    TripName = model.TripName,
                    DestinationCity = model.DestinationCity,
                    Description = model.Description,
                    StartDate = model.StartDate

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trips.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Get trip
        public IEnumerable<TripListItem> GetTrips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Trips
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                              new TripListItem
                              {
                                  TripId = e.TripId,
                                  TripName = e.TripName,
                                  DestinationCity = e.DestinationCity,
                                  Description = e.Description,
                                  StartDate = e.StartDate
                              }
                        );
                return query.ToArray();

            }
        }

        //Get /id

        public TripDetails GetTripById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripId == id && e.UserID == _userId);
                return
                    new TripDetails
                    {
                        TripId = entity.TripId,
                        TripName = entity.TripName,
                        DestinationCity = entity.DestinationCity,
                        Description = entity.Description,
                        StartDate = entity.StartDate
                    };
            }
        }


        // update 
        public bool UpdateTrip(TripEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripId == model.TripId && e.UserID == _userId);

                entity.TripName = model.TripName;
                entity.DestinationCity = model.DestinationCity;
                entity.Description = model.Description;
                entity.StartDate = model.StartDate;


                return ctx.SaveChanges() == 1;
            }
        }

        //Delete / id
        public bool DeleteTrip(int tripId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripId == tripId && e.UserID == _userId);

                ctx.Trips.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }

    }
}
