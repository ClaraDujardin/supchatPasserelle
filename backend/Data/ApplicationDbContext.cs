using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<WorkspaceMembership> WorkspaceMemberships { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelMembership> ChannelMemberships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
