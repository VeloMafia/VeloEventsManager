using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;

namespace VeloEventsManager.Web.Events
{
	public partial class AddEvent : Page
	{
		private VeloEventsManagerDbContext dbContext;

		public AddEvent()
		{
			this.dbContext = new VeloEventsManagerDbContext();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void FormViewAddEvent_InsertItem()
		{
			var item = new VeloEventsManager.Models.Event();
			var userId = this.User.Identity.GetUserId();
			var user = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);
			item.CreatorId = userId;
			item.Participants.Add(user);
			TryUpdateModel(item);
			if (ModelState.IsValid)
			{
				// Save changes here
				this.dbContext.Events.Add(item);
				this.dbContext.SaveChanges();
				var id = item.Id;
				this.Response.Redirect($"~/Events/Details?id={id}");
			}
		}

		// The id parameter should match the DataKeyNames value set on the control
		// or be decorated with a value provider attribute, e.g. [QueryString]int id
		public Event FormViewAddEvent_GetItem(int? id)
		{
			return null;
		}
	}
}