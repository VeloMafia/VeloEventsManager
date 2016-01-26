namespace VeloEventsManager.Models
{
	using System.Collections.Generic;
	using System.Security.Claims;
	using System.Threading.Tasks;

	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	// You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class User : IdentityUser
    {
		private ICollection<Event> events;

		public User()
		{
			this.events = new HashSet<Event>();
			this.Languages = new List<string>();
			this.Skills = new List<string>();
            this.Bikes = new HashSet<Bike>();
            this.AppRoles = new HashSet<AppRole>();
            this.Routes = new HashSet<Route>();
        }

		public virtual ICollection<Bike> Bikes { get; set; }

        public virtual ICollection<AppRole> AppRoles { get; set; }

        public string Mobile { get; set; }

		public double EnduranceIndex { get; set; }

        public bool HasAvatar { get; set; }

        public IList<string> Languages { get; set; }

		public IList<string> Skills { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}

        public virtual ICollection<Route> Routes { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
