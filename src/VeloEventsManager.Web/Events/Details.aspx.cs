using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;

namespace VeloEventsManager.Web.Events
{
	public partial class Details : System.Web.UI.Page
	{
		public VeloEventsManagerDbContext dbContext;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.dbContext = new VeloEventsManagerDbContext();
		}

		// The id parameter should match the DataKeyNames value set on the control
		// or be decorated with a value provider attribute, e.g. [QueryString]int id
		public Event FormViewEventDetails_GetItem([QueryString("id")]int? id)
		{
			if (id == null)
			{
				Response.Redirect("~/");
			}

			var tripEvent = this.dbContext.Events.FirstOrDefault(b => b.Id == id);

			if (tripEvent == null)
			{
				Response.Redirect("~/");
			}

			var d1 = DateTime.Now.AddDays(1);
			tripEvent.EventDays.Add(new EventDay()
			{
				Description = "purvi den alalala silajs hald sfhl sdlsj djsld hskld sjkdjs dlkshd kslhd sklfh skflh sklh sfklsh flks fsh fsfkl ",
				Date = d1,
				StartTime = d1.AddHours(3),
				EndTime = d1.AddHours(10),
				MainRoute = new Route()
				{
					LengthInMeters = 80,
				}
			});

			var d2 = DateTime.Now.AddDays(2);
			tripEvent.EventDays.Add(new EventDay()
			{
				Description = "vtori den",
				Date = d2,
				StartTime = d2.AddHours(3),
				EndTime = d2.AddHours(10),
				MainRoute = new Route()
				{
					LengthInMeters = 100,
				}
			});

			return tripEvent;
		}
	}
}