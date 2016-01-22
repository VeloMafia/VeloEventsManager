namespace VeloEventsManager.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using VeloEventsManager.Models;

    public class VeloEventsManagerDbContext : IdentityDbContext<User>, IVeloEventsManagerDbContext
    {
        public VeloEventsManagerDbContext()
            : base("VeloEventsManager", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Route> Routes { get; set; }

        public virtual IDbSet<Point> Points { get; set; }

        public virtual IDbSet<Bike> Bikes { get; set; }

        public virtual IDbSet<EventDay> EventDays { get; set; }

        public static VeloEventsManagerDbContext Create()
        {
            return new VeloEventsManagerDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Events)
                        .WithMany()
                        .Map(m =>
                        {
                            m.MapRightKey("EventId");
                            m.MapLeftKey("UserId");
                            m.ToTable("EventsUsers");
                        });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}