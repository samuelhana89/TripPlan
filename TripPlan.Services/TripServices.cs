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

    }
}
