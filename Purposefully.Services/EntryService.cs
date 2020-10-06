using Purposefully.Data;
using Purposefully.Models.EntryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Services
{
    public class EntryService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public EntryService() { }
        public EntryService(Guid userId)
        {
            _userId = userId;
        }

        // Post - Create
        public bool CreateEntry(EntryCreate model)
        {
            var entity =
                new Entry()
                {
                    Author = _userId,
                    EntryTitle = model.EntryTitle,
                    EntryContent = model.EntryContent,
                    ForGoal = model.ForGoal,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All - Read
        public IEnumerable<EntryListItem> GetEntries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Entries
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new EntryListItem
                                {
                                    EntryId = e.EntryId,
                                    Author = e.Author,
                                    EntryTitle = e.EntryTitle,
                                    EntryContent = e.EntryContent,
                                    ForGoal = e.ForGoal,
                                    GoalId = e.GoalId,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        // Get by ID - Read
        public EntryDetail GetEntryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.EntryId == id);
                return
                    new EntryDetail
                    {
                        EntryId = entity.EntryId,
                        Author = entity.Author,
                        EntryTitle = entity.EntryTitle,
                        EntryContent = entity.EntryContent,
                        ForGoal = entity.ForGoal,
                        GoalId = entity.GoalId,
                        CreatedUtc = entity.CreatedUtc,
                        //ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        // Put - Update
        public bool UpdateEntry(EntryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.EntryId == model.EntryId);

                entity.EntryTitle = model.EntryTitle;
                entity.EntryContent = model.EntryContent;
                entity.ForGoal = model.ForGoal;
                entity.GoalId = model.GoalId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteEntry(int entryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.EntryId == entryId);

                ctx.Entries.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
