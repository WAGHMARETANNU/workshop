using Microsoft.EntityFrameworkCore;
namespace workshop.DBFOLDER
    {
    public class STUDENTDB:DbContext
        {
        public STUDENTDB(DbContextOptions<STUDENTDB> options):base(options)
            {
            }

        public DbSet<Models.StudentModel> students { get; set; }


        }
    }
