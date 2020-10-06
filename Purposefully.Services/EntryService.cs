using Purposefully.Data;
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


    }
}
