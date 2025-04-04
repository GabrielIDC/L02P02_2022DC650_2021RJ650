using Microsoft.EntityFrameworkCore;
namespace L02P02_2022DC650_2021RJ650.Models
{
    public class librosDbContext : DbContext
    {
        public librosDbContext(DbContextOptions<librosDbContext> options) : base(options)
        {
        }
    }
}
