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

        public virtual IDbSet<AppRole> AppRoles { get; set; }

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
                        .WithMany(e => e.Participants)
                        .Map(m =>
                        {
                            m.MapRightKey("EventId");
                            m.MapLeftKey("ParticipantId");
                            m.ToTable("EventsParticipants");
                        });

            modelBuilder.Entity<EventDay>()
                        .HasMany(u => u.OptionalRoutes)
                        .WithMany(e => e.EventDays)
                        .Map(m =>
                        {
                            m.MapRightKey("EventDayId");
                            m.MapLeftKey("OptionalRouteId");
                            m.ToTable("EventDaysOptionalRoutes");
                        });

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<User>().HasMany(c => c.Events).WithRequired(x => x.Creator).WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>().HasRequired(c => c.StartPoint).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<EventDay>().HasRequired(c => c.MainRoute).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}