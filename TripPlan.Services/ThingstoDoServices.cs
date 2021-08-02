using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlan.Data;
using TripPlan.Model.ThingstoDo;

namespace TripPlan.Services
{
    public class ThingstoDoServices
    {

        private readonly Guid _userId;
        public ThingstoDoServices(Guid userId)
        {
            _userId = userId;
        }

        //Create Things To Do
        public bool CreateThingsToDo(ThingsToDoCreate model)
        {
            var entity =
                new ThingsToDo()
                {
                    UserID = _userId,
                    Activity = model.Activity,
                    Description = model.Description,
                    TripId = model.TripId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.thingsToDos.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //see all Things To Do
        public IEnumerable<ThingstoDoListItem> GetThingstoDo()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .thingsToDos
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                              new ThingstoDoListItem
                              {
                                  ThingsToDoId = e.ThingsToDoId,
                                  Activity = e.Activity,
                                  Description = e.Description,
                                  TripName = e.Trip.TripName,
                              }
                        );
                return query.ToArray();

            }
        }

        //Get /id
        public ThingsToDoDetails GetThingsTodoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .thingsToDos
                    .Single(e => e.ThingsToDoId == id && e.UserID == _userId);
                return
                    new ThingsToDoDetails
                    {
                        ThingsToDoId = entity.ThingsToDoId,
                        Activity = entity.Activity,
                        Description = entity.Description,
                        TripName = entity.Trip.TripName

                    };
            }
        }

        //to update 
        public bool UpdateThingsToDot(ThingsToDoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .thingsToDos
                    .Single(e => e.ThingsToDoId == model.ThingsToDoId && e.UserID == _userId);

                entity.Activity = model.Activity;
                entity.Description = model.Description;


                return ctx.SaveChanges() == 1;
            }
        }


        //Delete / id
        public bool DeleteThingsTodo(int thingsTodoid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .thingsToDos
                    .Single(e => e.ThingsToDoId == thingsTodoid && e.UserID == _userId);

                ctx.thingsToDos.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
