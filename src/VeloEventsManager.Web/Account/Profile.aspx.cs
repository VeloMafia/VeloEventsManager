using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Data.Entity;

namespace VeloEventsManager.Web.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        VeloEventsManagerDbContext data = new VeloEventsManagerDbContext();
        private Site master;

        // PAGE EVENTS

        protected void Page_Load(object sender, EventArgs e)
        {
            master = this.Master as Site;
        }

        // DATA

        public IQueryable<User> GetData()
        {
            var id = User.Identity.GetUserId();
            var users = data.Users.Where(x => x.Id == id);
            return users;
        }

        public void UpdateItem(string id)
        {
            if (!master.isAdmin && id != User.Identity.GetUserId())
            {
                master.ShowErrorMessage("Not authorized.");
                return;
            }

            //var user = data.Users.Find(id);
            User user = null;
            user = data.Users.Find(id);
            if (user == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(user);

            if (ModelState.IsValid)
            {

                var fileUploadControl = (FileUpload)FormViewUserDetails.FindControl("FileUploadControl");

                if (fileUploadControl.HasFile)
                {
                    string fileName =  user.UserName + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".jpg";
                    fileUploadControl.SaveAs(Server.MapPath("~/Uploaded_Files/") + fileName);
                    user.Avatar = fileName;
                }

                user.Events.Clear();
                var lbEvents = (ListBox)FormViewUserDetails.FindControl("ListBoxEditEvents");
                foreach (ListItem ev in lbEvents.Items)
                {
                    var evId = int.Parse(ev.Value);
                    var eventToAdd = data.Events.FirstOrDefault(x => x.Id == evId);
                    user.Events.Add(eventToAdd);
                }

                data.Entry(user).State = EntityState.Modified;
                data.SaveChanges();
                master.ShowSuccessMessage("Item updated");

                this.DataBind();
            }
        }

        protected void RemoveEvent_Click(object sender, EventArgs e)
        {
            var lb = (ListBox)FormViewUserDetails.FindControl("ListBoxEditEvents");
            var itemsToRemove = new List<ListItem>();
            foreach (ListItem item in lb.Items)
            {
                if (item.Selected)
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (var item in itemsToRemove)
            {
                lb.Items.Remove(item);
            }
        }
    }
}