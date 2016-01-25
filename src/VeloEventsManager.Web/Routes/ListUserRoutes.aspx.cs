using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;
using Microsoft.AspNet.Identity;

namespace VeloEventsManager.Web.Routes
{
    public partial class ListRoutes : System.Web.UI.Page
    {
        VeloEventsManagerDbContext data = new VeloEventsManagerDbContext();
        private Site master;

        protected void Page_Load(object sender, EventArgs e)
        {
            master = this.Master as Site;
        }

        public IQueryable<Route> GridViewRoutes_GetData()
        {
            var id = this.User.Identity.GetUserId();
            return data.Routes.Where(x => x.UserId == id).OrderBy(x => x.Id);
        }

        public void GridViewRoutes_DeleteItem(int id)
        {
            var item = data.Routes.Find(id);
            var eventsIds = data.EventDays.Where(x => x.MainRouteId == item.Id).Select(x => x.EventId).ToList();
            var eventNames = data.Events.Where(x => eventsIds.Contains(x.Id)).Select(x => x.Name).ToArray();
            if (eventNames.Length > 0)
            {
                string eventNamesString = string.Join(", ", eventNames);
                master.ShowErrorMessage($"Route cannot be deleted because it is main route in event {eventNamesString}");
                return;
            }

            data.Routes.Remove(item);
            data.SaveChanges();
            master.ShowSuccessMessage("Item deleted");
            this.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewRoutes_UpdateItem(int id)
        {
            Route item = null;
            item = data.Routes.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                data.Entry(item).State = EntityState.Modified;
                data.SaveChanges();
                master.ShowSuccessMessage("Item updated");
                this.DataBind();
            }
        }
    }
}