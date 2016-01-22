namespace VeloEventsManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Event
	{
		private ICollection<User> participants;
		private ICollection<EventDay> eventDays;

		public Event()
		{
			this.participants = new HashSet<User>();
			this.eventDays = new HashSet<EventDay>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

        [ForeignKey("Creator")]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<User> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }

        public virtual ICollection<EventDay> EventDays
		{
			get { return this.eventDays; }
			set { this.eventDays = value; }
		}

		public double TotalDistance { get; set; }

		public double PriceInLeva { get; set; }
	}
}