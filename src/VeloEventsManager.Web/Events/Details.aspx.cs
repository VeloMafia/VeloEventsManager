using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;
using VeloEventsManager.Web.Controls;

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

			return tripEvent;
		}

		protected void JoinControl_Join(object sender, JoinEventArgs e)
		{
			string userID = this.User.Identity.GetUserId();
			User user = this.dbContext.Users.FirstOrDefault(x => x.Id == userID);
			Event trip = this.dbContext.Events.FirstOrDefault(x => x.Id == e.DataID);

			if (e.IsJoin)
			{
				trip.Participants.Add(user);
			}
			else
			{
				trip.Participants.Remove(user);
			}
			this.dbContext.SaveChanges();
		}

		protected bool IsJoin(Event item)
		{
			string userID = User.Identity.GetUserId();
			User user = this.dbContext.Users.FirstOrDefault(x => x.Id == userID);

			var isJoin = user.Events.Any(x => x == item);
			return isJoin;
		}
	}
}