namespace VeloEventsManager.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Bike
	{
		[Key, ForeignKey("Owner")]
		public string OwnerId { get; set; }

		public virtual User Owner { get; set; }

		public string SpecificInformation { get; set; }

		public double Weight { get; set; }

		public double Height { get; set; }

		public double Width { get; set; }

		public double Length { get; set; }
	}
}