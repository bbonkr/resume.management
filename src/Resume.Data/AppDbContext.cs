using Microsoft.EntityFrameworkCore;
using System;
using Resume.Entities;

namespace Resume.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Content> Contents { get; set; }
        
        public DbSet<ContentLink> ContentLinks { get; set; }
        
        public DbSet<ContentMedia> ContentMedias { get; set; }
        
        public DbSet<ContentTag> ContentTags { get; set; }
        
        public DbSet<Skill> Skills { get; set; }
        
        public DbSet<SkillGroup> SkillGroups { get; set; }
        
        public DbSet<Tag> Tags { get; set; }
        
        public DbSet<UserLink> UserLinks { get; set; }
        
        public DbSet<UserMedia> UserMedias { get; set; }
        
        public DbSet<UserSns> UserSns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
