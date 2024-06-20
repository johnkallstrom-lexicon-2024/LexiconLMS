using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Core.Entities;

namespace LexiconLMS.Data
{
    public class LexiconLMSContext : DbContext
    {
        public LexiconLMSContext (DbContextOptions<LexiconLMSContext> options)
            : base(options)
        {
        }

        public DbSet<LexiconLMS.Core.Entities.Course> Course { get; set; } = default!;
    }
}
