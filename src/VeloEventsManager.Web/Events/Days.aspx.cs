using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;

namespace VeloEventsManager.Web.Events
{
	public partial class Days : System.Web.UI.Page
	{
		public VeloEventsManagerDbContext dbContext;
		private Site master;
		protected void Page_Load(object sender, EventArgs e)
		{
			master = this.Master as Site;
			this.dbContext = new VeloEventsManagerDbContext();
		}

		// The return type can be changed to IEnumerable, however to support
		// paging and sorting, the following parameters must be added:
		//     int maximumRows
		//     int startRowIndex
		//     out int totalRowCount
		//     string sortByExpression
		public EventDay ListViewEventDay_GetData([QueryString("id")]int? id)
		{
			if (id == null)
			{
				Response.Redirect("~/");
			}

			var eventDay = this.dbContext.EventDays.FirstOrDefault(b => b.Id == id);

			if (eventDay == null)
			{
				Response.Redirect("~/");
			}

			return eventDay;
		}

		public void UpdateItem(string id)
		{
			if (!master.isAdmin)
			{
				master.ShowErrorMessage("Not authorized.");
				return;
			}

			EventDay item = null;
			item = dbContext.EventDays.Find(int.Parse(id));
			if (item == null)
			{
				ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
				return;
			}

			TryUpdateModel(item);

			if (ModelState.IsValid)
			{
				dbContext.Entry(item).State = EntityState.Modified;
				dbContext.SaveChanges();
				master.ShowSuccessMessage("Item updated");
				this.DataBind();
			}
		}

		public void DeleteItem(string id)
		{
			if (!master.isAdmin)
			{
				master.ShowErrorMessage("Not authorized.");
				return;
			}

			var item = this.dbContext.EventDays.Find(int.Parse(id));
			var eventId = item.EventId;
			dbContext.EventDays.Remove(item);
			dbContext.SaveChanges();
			master.ShowSuccessMessage("Item deleted");
			//ViewState["selectedTodo"] = null;
			Response.Redirect($"~/Events/Details.aspx?id={eventId}");
		}

		// The id parameter name should match the DataKeyNames value set on the control
		public void ListViewOptionalRoutes_DeleteItem(int id)
		{

		}
	}
}