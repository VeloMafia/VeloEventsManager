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
	public partial class MyEvents : System.Web.UI.Page
	{
		private VeloEventsManagerDbContext dbContext;

		public MyEvents()
		{
			this.dbContext = new VeloEventsManagerDbContext();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		// The return type can be changed to IEnumerable, however to support
		// paging and sorting, the following parameters must be added:
		//     int maximumRows
		//     int startRowIndex
		//     out int totalRowCount
		//     string sortByExpression
		public IQueryable<Event> GridViewMyEvents_GetData()
		{
			var userId = this.User.Identity.GetUserId();
			var user = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);

			if (user == null)
			{
				return null;
			}

			return user.Events.AsQueryable();
		}

		// The id parameter name should match the DataKeyNames value set on the control
		public void GridViewMyEvents_UpdateItem(int id)
		{
			VeloEventsManager.Models.Event item = null;
			// Load the item here, e.g. item = MyDataLayer.Find(id);
			if (item == null)
			{
				// The item wasn't found
				ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
				return;
			}
			TryUpdateModel(item);
			if (ModelState.IsValid)
			{
				// Save changes here, e.g. MyDataLayer.SaveChanges();
				this.dbContext.SaveChanges();
			}
		}
	}
}