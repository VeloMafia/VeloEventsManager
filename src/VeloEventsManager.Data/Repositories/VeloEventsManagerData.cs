namespace VeloEventsManager.Data.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;

	using VeloEventsManager.Models;

	public class VeloEventsManagerData : IVeloEventsManagerData
	{
		private readonly DbContext context;
		private readonly IDictionary<Type, object> repositories;

		public VeloEventsManagerData()
		{
			this.context = new VeloEventsManagerDbContext();
			this.repositories = new Dictionary<Type, object>();
		}

		public IRepository<Bike> Bikes
		{
			get
			{
				return this.GetRepository<Bike>();
			}
		}

		public IRepository<EventDay> EventDays
		{
			get
			{
				return this.GetRepository<EventDay>();
			}
		}

		public IRepository<Event> Events
		{
			get
			{
				return this.GetRepository<Event>();
			}
		}

		public IRepository<Point> Points
		{
			get
			{
				return this.GetRepository<Point>();
			}
		}

		public IRepository<Route> Routes
		{
			get
			{
				return this.GetRepository<Route>();
			}
		}

		public IRepository<User> Users
		{
			get
			{
				return this.GetRepository<User>();
			}
		}

		public int Savechanges()
		{
			return this.context.SaveChanges();
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			var typeOfRepository = typeof(T);

			if (!this.repositories.ContainsKey(typeOfRepository))
			{
				var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
				this.repositories.Add(typeOfRepository, newRepository);
			}

			return (IRepository<T>)this.repositories[typeOfRepository];
		}
	}
}