using Purposefully.Data;
using Purposefully.Models.GoalModels;
using Purposefully.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ProfileService() { }
        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        // Post - Create
        public bool CreateProfile(ProfileCreate model)
        {
            var entity =
                new Profile
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Motivation = model.Motivation
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All - Read - For future use to display multiple profiles for user interaction
        public IEnumerable<ProfileListItem> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profiles
                        .Select(
                            e =>
                                new ProfileListItem
                                {
                                    ProfileId = e.ProfileId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Motivation = e.Motivation
                                }
                         );
                return query.ToArray();
            }
        }

        // Get by Id - Read
        public ProfileDetail GetProfileById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == id);
                var detail = new ProfileDetail
                {
                    ProfileId = entity.ProfileId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Motivation = entity.Motivation,
                    GoalsOfUser = new List<GoalDetail>()
                };
                    foreach (Goal goal in entity.GoalsOfUser)
                    {
                        GoalDetail goalDetail = GoalService.GetGoalById(goal.GoalId);
                        detail.GoalsOfUser.Add(goalDetail);
                    }
                return detail;
            }
        }

        // Update - Put 
        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .SingleOrDefault(e => e.ProfileId == model.ProfileId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Motivation = model.Motivation;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete 
        public bool DeleteProfile(int profileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .SingleOrDefault(e => e.ProfileId == profileId);

                ctx.Profiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
