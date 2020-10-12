using Purposefully.Data;
using Purposefully.Models.GoalModels;
using Purposefully.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            GoalService goalService = new GoalService();

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
                    GoalsOfUser = ConvertDataEntitiesToViewModel(entity.GoalsOfUser.ToList())
                };
                return detail;
            }
        }

        // Access and read items from the Goal iCollection
        public List<GoalDetail> ConvertDataEntitiesToViewModel(List<Goal> goals)
        {
            List<GoalDetail> returnList = new List<GoalDetail>();

            foreach (var goal in goals)
            {
                var goalDetail = new GoalDetail();

                goalDetail.GoalId = goal.GoalId;
                goalDetail.GoalTitle = goal.GoalTitle;
                goalDetail.GoalContent = goal.GoalContent;
                goalDetail.GoalType = (Models.GoalModels.GoalType)goal.GoalType;
                goalDetail.Difficulty = goal.Difficulty;
                goalDetail.StartDate = goal.StartDate;
                goalDetail.EndDate = goal.EndDate;
                goalDetail.Completed = goal.Completed;

                returnList.Add(goalDetail);
            }
            return returnList;
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
                        .Single(e => e.ProfileId == profileId);

                ctx.Profiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
