﻿using Microsoft.Win32;
using Purposefully.Data;
using Purposefully.Models.EntryModels;
using Purposefully.Models.GoalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Services
{
    public class GoalService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public GoalService() { }
        public GoalService(Guid userId)
        {
            _userId = userId;
        }

        // Post - Create
        public bool CreateGoal(GoalCreate model)
        {
            var entity =
                new Goal
                {
                    GoalTitle = model.GoalTitle,
                    GoalContent = model.GoalContent,
                    GoalType = (Data.GoalType)model.GoalType,
                    Difficulty = model.Difficulty,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Completed = model.Completed,
                    ProfileId = model.ProfileId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Goals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All - Read
        public IEnumerable<GoalListItem> GetGoals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Goals
                        .Select(
                            e =>
                                new GoalListItem
                                {
                                    GoalId = e.GoalId,
                                    GoalTitle = e.GoalTitle,
                                    GoalContent = e.GoalContent,
                                    GoalType = (Models.GoalModels.GoalType)e.GoalType,
                                    Difficulty = e.Difficulty,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    Completed = e.Completed,
                                    ProfileId = e.ProfileId,
                                    //AllEntriesForGoal = new List<EntryDetail>()
                                }
                        );
                return query.ToArray();
            }
        }

        // Get by ID - Read
        public GoalDetail GetGoalById(int id)
        {
            EntryService entryService = new EntryService();

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalId == id);
                var detail = new GoalDetail
                {
                    GoalId = entity.GoalId,
                    GoalTitle = entity.GoalTitle,
                    GoalContent = entity.GoalContent,
                    GoalType = (Models.GoalModels.GoalType)entity.GoalType,
                    Difficulty = entity.Difficulty,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    Completed = entity.Completed,
                    ProfileId = entity.ProfileId,
                    AllEntriesForGoal = ConvertDataEntitiesToViewModel(entity.AllEntriesForGoal.ToList())
                };
                return detail;
            }
        }

        // Access and read items from the Entry iCollection
        public List<EntryDetail> ConvertDataEntitiesToViewModel(List<Entry> entries)
        {
            // instantiate a new List<EntryDetail>
            List<EntryDetail> returnList = new List<EntryDetail>();
            // assign the values from the entity.AllEntries[i]
            foreach (var entry in entries)
            {
                var entryDetail = new EntryDetail();

                entryDetail.EntryId = entry.EntryId;
                entryDetail.EntryTitle = entry.EntryTitle;
                entryDetail.EntryContent = entry.EntryContent;
                entryDetail.ForGoal = entry.ForGoal;
                entryDetail.GoalId = entry.GoalId;
                entryDetail.CreatedUtc = entry.CreatedUtc;
                entryDetail.ModifiedUtc = entry.ModifiedUtc;

                returnList.Add(entryDetail);
            }
            return returnList;
        }

        // Put - Update
        public bool UpdateGoal(GoalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalId == model.GoalId);

                entity.GoalTitle = model.GoalTitle;
                entity.GoalContent = model.GoalContent;
                entity.GoalType = (Data.GoalType)model.GoalType;
                entity.Difficulty = model.Difficulty;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Completed = model.Completed;
                entity.ProfileId = model.ProfileId;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteGoal(int goalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalId == goalId);

                ctx.Goals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
