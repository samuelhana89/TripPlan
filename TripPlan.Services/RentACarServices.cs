using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlan.Data;
using TripPlan.Model.RentACar;

namespace TripPlan.Services
{
    public class RentACarServices
    {
        private readonly Guid _userId;
        public RentACarServices(Guid userId)
        {
            _userId = userId;
        }

        //Create 
        public bool CreateRentACar(RentACarCreate model)
        {
            var entity =
                new RentACar()
                {
                    UserID = _userId,
                    CarName = model.CarName,
                    Year = model.Year,
                    TripId = model.TripId


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RentACars.Add(entity);

                return ctx.SaveChanges() == 1;
            }


        }

        //see all Things To Do
        public IEnumerable<RentACarListItem> GetRentACar()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RentACars
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                              new RentACarListItem
                              {
                                  RentACarId = e.RentACarId,
                                  CarName = e.CarName,
                                  Year = e.Year,
                                  TripName = e.Trip.TripName
                              }
                        );
                return query.ToArray();

            }
        }

        //Get /id
        public RentACarDetails GetRentACarById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RentACars
                    .Single(e => e.RentACarId == id && e.UserID == _userId);
                return
                    new RentACarDetails
                    {
                        RentACarId = entity.RentACarId,
                        CarName = entity.CarName,
                        Year = entity.Year,
                        TripName = entity.Trip.TripName

                    };
            }
        }

        // update 
        public bool UpdateRentACar(RentACarEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RentACars
                    .Single(e => e.RentACarId == model.RentACarId && e.UserID == _userId);

                entity.CarName = model.CarName;
                entity.Year = model.Year;


                return ctx.SaveChanges() == 1;
            }
        }

        //Delete / id
        public bool DeleteRentACar(int RentACarid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RentACars
                    .Single(e => e.RentACarId == RentACarid && e.UserID == _userId);

                ctx.RentACars.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
