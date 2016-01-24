namespace VeloEventsManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class EventDay
	{
		private ICollection<Route> optionalRoutes;

		public EventDay()
		{
			this.optionalRoutes = new HashSet<Route>();
		}

		public int Id { get; set; }

		public string Description { get; set; }

		public DateTime Date { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

        public int MainRouteId { get; set; }

        public virtual Route MainRoute { get; set; }

		public int EventId { get; set; }

		public virtual Event Event { get; set; }

		public virtual ICollection<Route> OptionalRoutes
        {
			get { return this.optionalRoutes; }
			set { this.optionalRoutes = value; }
		}
	}
}