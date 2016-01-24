namespace VeloEventsManager.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Linq;

	using Microsoft.AspNet.Identity;

	using VeloEventsManager.Common;
	using VeloEventsManager.Data;
	using VeloEventsManager.Models;

	public sealed class Configuration : DbMigrationsConfiguration<VeloEventsManagerDbContext>
    {
		private Random random;

        public Configuration()
        {
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(VeloEventsManagerDbContext context)
        {
			this.SeedUsers(context);
			this.SeedBikes(context);
			this.SeedPoints(context);
			this.SeedRoutes(context);
			this.SeedEvents(context);
			this.SeedEventDays(context);
		}

		private void SeedEvents(VeloEventsManagerDbContext context)
		{
			if (context.Events.Any())
			{
				return;
			}

			var creator = context.Users.FirstOrDefault(x => x.UserName == "admin@admin.com");
			var users = context.Users.ToList();
			random = new Random();
			for (int i = 0; i < 20; i++)
			{
				var startDay = DateTime.Now.AddDays(i);
				var endDay = DateTime.Now.AddDays(i + 10);

				var trip = new Event()
				{
					Name = $"Test event name {i}",
					Description = $"Test event description {i}",
					StartDate = startDay,
					EndDate = endDay,
					PriceInLeva = i + 100,
					TotalDistance = i + 500,
					Creator = creator
				};

				trip.Participants.Add(creator);

				for (int j = 0; j < 20 + i; j++)
				{
					var participant = users[random.Next(0, users.Count)];
					trip.Participants.Add(participant);
				}

				context.Events.Add(trip);
			}

			context.SaveChanges();
		}

		private void SeedEventDays(VeloEventsManagerDbContext context)
		{
			if (context.EventDays.Any())
			{
				return;
			}

			var routes = context.Routes.ToList();
			var trips = context.Events.ToList();
			random = new Random();
			for (int i = 0; i < 100; i++)
			{
				var date = DateTime.Now.AddDays(i);
				var startTime = DateTime.Now.AddDays(i).AddHours(i);
				var endTime = DateTime.Now.AddDays(i).AddHours(i + 5);
				var mainRoute = routes[random.Next(0, routes.Count)];
				var trip = trips[random.Next(0, trips.Count)];
				var eventDay = new EventDay()
				{
					Description = $"Test description: Day {i % 10}. Long day...",
					Date = date,
					StartTime = startTime,
					EndTime = endTime,
					MainRoute = mainRoute,
					Event = trip
				};

				// some optional routes
				if (i % 2 == 0)
				{
					for (int j = 0; j < 3; j++)
					{
						var currentOptionalRoute = routes[random.Next(0, routes.Count)];
						eventDay.OptionalRoutes.Add(currentOptionalRoute);
					}
				}

				context.EventDays.Add(eventDay);
			}

			context.SaveChanges();
		}

		private void SeedRoutes(VeloEventsManagerDbContext context)
		{
			if (context.Routes.Any())
			{
				return;
			}

			var points = context.Points.ToList();
			random = new Random();
			for (int i = 0; i < 100; i++)
			{
				var startPoint = points[random.Next(0, points.Count)];
				var endPoint = points[random.Next(0, points.Count)];
				var route = new Route()
				{
					StartPoint = startPoint,
					EndPoint = endPoint,
					AscentInMeters = i + 1,
					DescentInMeters = i + 1,
					LengthInMeters = i + 1,
					Difficulty = i + 1,
				};

				context.Routes.Add(route);
			}

			context.SaveChanges();
		}

		private void SeedPoints(VeloEventsManagerDbContext context)
		{
			if (context.Points.Any())
			{
				return;
			}

			for (int i = 0; i < 10000; i++)
			{
				var point = new Point()
				{
					Elevation = i / 1000,
					Lattitude = 42 + i * 0.001,
					Longitude = 23 + i * 0.001,
				};

				context.Points.Add(point);
			}

			context.SaveChanges();
		}

		private void SeedBikes(VeloEventsManagerDbContext context)
		{
			if (context.Bikes.Any())
			{
				return;
			}

			var users = context.Users.ToList();

			for (int i = 0; i < users.Count; i++)
			{
				var currentUser = users[i];
				var bike = new Bike()
				{
					Owner = currentUser,
					SpecificInformation = $"Specific Information for bike {i}",
					Height = i + 1,
					Length = i + 1,
					Weight = i + 1,
					Width = i + 1
				};

				context.Bikes.Add(bike);
			}

			context.SaveChanges();
		}

		private void SeedUsers(VeloEventsManagerDbContext context)
		{
			if (context.Users.Any())
			{
				return;
			}

			var admin = new User()
			{
				Email = "admin@admin.com",
				UserName = "admin@admin.com",
				PasswordHash = new PasswordHasher().HashPassword("admin")
			};

			context.Users.Add(admin);

			var languages = VeloEventsManager.Common.Constants.Languages;
			var skills = VeloEventsManager.Common.Constants.Skills;
			random = new Random();
			for (int i = 0; i < 100; i++)
			{
				var user = new User()
				{
					Email = $"test{i}@test.bg",
					UserName = $"test{i}@test.bg",
					PasswordHash = new PasswordHasher().HashPassword($"test{i}@test.bg")
				};

				for (int j = 0; j < 2; j++)
				{
					var lang = languages[random.Next(0, languages.Length)];
					var skill = skills[random.Next(0, skills.Length)];
					user.Languages.Add(lang);
					user.Skills.Add(skill);
				}

				context.Users.Add(user);
			}

			context.SaveChanges();
		}
	}
}
