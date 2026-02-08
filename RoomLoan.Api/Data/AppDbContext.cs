using Microsoft.EntityFrameworkCore;
using RoomLoan.Api.Models;

namespace RoomLoan.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RoomLoanEntity> RoomLoans => Set<RoomLoanEntity>();
    }
}
