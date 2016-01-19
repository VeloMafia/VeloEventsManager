namespace VeloEventsManager.Data.Repositories
{
	using VeloEventsManager.Models;

	public interface IVeloEventsManagerData
	{
		IRepository<Event> Events { get; }

		IRepository<User> Users { get; }

		IRepository<Bike> Bikes { get; }

		IRepository<EventDay> EventDays { get; }

		IRepository<Point> Points { get; }

		IRepository<Route> Routes { get; }

		int Savechanges();
	}
}