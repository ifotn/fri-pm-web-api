using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fri_pm_api.Models
{
    public class MusicStoreModel : DbContext
    {
        public MusicStoreModel(DbContextOptions<MusicStoreModel>options) :base(options)
        {
        }

        // reference  the Album model for CRUD
        public DbSet<Album> Albums { get; set; }
        
    }
}
