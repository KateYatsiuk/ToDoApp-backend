namespace ToDoTasks.DAL.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using ToDoTasks.DAL.Entities;

    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
            .Property(t => t.CreationDate)
            .HasConversion(new DateOnlyConverter());

            modelBuilder.Entity<ToDo>()
            .Property(e => e.ToDoState)
            .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
