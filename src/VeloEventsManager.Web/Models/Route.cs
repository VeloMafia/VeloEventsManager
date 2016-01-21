namespace VeloEventsManager.Web.Models
{
	public class Route
	{
		public int Id { get; set; }

		public int StartPointId { get; set; }

		public virtual Point StartPoint { get; set; }

		public int EndPointId { get; set; }

		public virtual Point EndPoint { get; set; }

		public int EventDayId { get; set; }

		public virtual EventDay EventDay { get; set; }

		public double LengthInMeters { get; set; }

		public double AscentInMeters { get; set; }

		public double DescentInMeters { get; set; }

		public double ExpectedDurationInHours { get; set; }

		public double Difficulty { get; set; }
	}
}