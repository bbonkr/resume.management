using Microsoft.EntityFrameworkCore;
using System;

namespace Resume.Data
{
    public class AppDbContext : kr.bbon.Data.AppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
