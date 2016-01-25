using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeloEventsManager.Models
{
	public class Route
	{
		public int Id { get; set; }

        public string Name { get; set; }

        public int StartPointId { get; set; }

		public virtual Point StartPoint { get; set; }

		public int EndPointId { get; set; }

		public virtual Point EndPoint { get; set; }

        public double LengthInMeters { get; set; }

		public double AscentInMeters { get; set; }

		public double DescentInMeters { get; set; }

		public double ExpectedDurationInHours { get; set; }

		public double Difficulty { get; set; }

        public virtual ICollection<EventDay> EventDays { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}