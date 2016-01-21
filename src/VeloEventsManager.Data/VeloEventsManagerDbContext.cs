namespace VeloEventsManager.Data
{
	using System;
	using System.Web;
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;

	using Microsoft.AspNet.Identity.EntityFramework;

	using VeloEventsManager.Models;

	public class VeloEventsManagerDbContext : IdentityDbContext<User>, IVeloEventsManagerDbContext
	{
		public VeloEventsManagerDbContext()
			: base("VeloEventsManager", throwIfV1Schema: false)
		{
		}

		public virtual IDbSet<Event> Events { get; set; }

		public virtual IDbSet<Route> Routes { get; set; }

		public virtual IDbSet<Point> Points { get; set; }

		public virtual IDbSet<Bike> Bikes { get; set; }

		public virtual IDbSet<EventDay> EventDays { get; set; }

		public static VeloEventsManagerDbContext Create()
		{
			return new VeloEventsManagerDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
						.HasMany(u => u.Events)
						.WithMany()
						.Map(m =>
						{
							m.MapRightKey("EventId");
							m.MapLeftKey("UserId");
							m.ToTable("EventsUsers");
						});

			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			base.OnModelCreating(modelBuilder);
		}
	}


	#region Helpers

	public static class IdentityHelper
	{
		// Used for XSRF when linking external logins
		public const string XsrfKey = "XsrfId";

		public const string ProviderNameKey = "providerName";
		public static string GetProviderNameFromRequest(HttpRequest request)
		{
			return request.QueryString[ProviderNameKey];
		}

		public const string CodeKey = "code";
		public static string GetCodeFromRequest(HttpRequest request)
		{
			return request.QueryString[CodeKey];
		}

		public const string UserIdKey = "userId";
		public static string GetUserIdFromRequest(HttpRequest request)
		{
			return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
		}

		public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
		{
			var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
			return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
		}

		public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
		{
			var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
			return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
		}

		private static bool IsLocalUrl(string url)
		{
			return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
		}

		public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
		{
			if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
			{
				response.Redirect(returnUrl);
			}
			else
			{
				response.Redirect("~/");
			}
		}
	}

	#endregion
}

