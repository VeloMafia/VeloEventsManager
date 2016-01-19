namespace VeloEventsManager.Models
{
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Collections.Generic;

	// You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class User : IdentityUser
    {
		private ICollection<Event> events;
		private ICollection<Skill> skills;
		private ICollection<Language> languages;

		public User()
		{
			this.events = new HashSet<Event>();
			this.skills = new HashSet<Skill>();
			this.languages = new HashSet<Language>();
		}

		public int BikeId { get; set; }

		public virtual Bike Bike { get; set; }

		public string Mobile { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}

		public virtual ICollection<Skill> Skills
		{
			get { return this.skills; }
			set { this.skills = value; }
		}

		public virtual ICollection<Language> Languages
		{
			get { return this.languages; }
			set { this.languages = value; }
		}

		public double EnduranceIndex { get; set; }

		public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
