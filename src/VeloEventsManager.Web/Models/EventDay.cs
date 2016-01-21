namespace VeloEventsManager.Web.Models
{
	using System;
	using System.Collections.Generic;

	public class EventDay
	{
		//private ICollection<User> participants;
		private ICollection<Route> routes;

		public EventDay()
		{
			//this.participants = new HashSet<User>();
			this.routes = new HashSet<Route>();
		}

		public int Id { get; set; }

		public string Description { get; set; }

		public DateTime Date { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public Route MainRoute { get; set; }

		public int EventId { get; set; }

		public virtual Event Event { get; set; }

		//public virtual ICollection<User> Users
		//{
		//	get { return this.participants; }
		//	set { this.participants = value; }
		//}

		public virtual ICollection<Route> OptionalRoutes
		{
			get { return this.routes; }
			set { this.routes = value; }
		}
	}
}