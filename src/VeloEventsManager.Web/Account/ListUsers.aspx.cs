using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;

namespace VeloEventsManager.Web.Account
{
    public partial class ListUsers : System.Web.UI.Page
    {
        VeloEventsManagerDbContext data = new VeloEventsManagerDbContext();

        private const int PageSize = 5;

        // Page events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["page"] = 0;
            }
        }

        // Page helpers
        private void DisplayMessage(string msg)
        {
            var master = this.Master as Site;
            master.ShowSuccessMessage(msg);
        }

        // Users list
        public IQueryable<User> ListViewUsers_GetData()
        {
            var Users = data.Users.OrderBy(x => x.Id);
            var dateOrder = (string)ViewState["orderByName"];
            if (dateOrder != null && dateOrder == "asc")
            {
                Users = Users.OrderBy(x => x.UserName);
            }
            else if (dateOrder != null && dateOrder == "des")
            {
                Users = Users.OrderByDescending(x => x.UserName);
            }

            int page = (int)ViewState["page"];
            return Users.Skip(PageSize * page).Take(PageSize);
        }

        protected void ListViewUsers_ServerClick(object sender, EventArgs e)
        {
            var element = (HtmlControl)sender;
            var id = element.Attributes["itemid"];
            ViewState.Add("selectedTodo", id);
            FormViewUserDetails.ChangeMode(FormViewMode.ReadOnly);
            this.FormViewUserDetails.DataBind();
        }

        protected void orderByName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (DropDownList)sender;
            var selectedItem = dropDown.SelectedItem;
            ViewState.Add("orderByName", selectedItem.Text);
            FirstPage_ServerClick(new { }, new EventArgs());
            this.ListViewUsers.DataBind();
        }

        protected void NextPage_ServerClick(object sender, EventArgs e)
        {
            int page = (int)ViewState["page"];
            if (page * PageSize < data.Users.Count() - PageSize)
            {
                ViewState["page"] = ++page;
                this.ListViewUsers.DataBind();
            }

        }

        protected void PrevPage_ServerClick(object sender, EventArgs e)
        {
            int page = (int)ViewState["page"];
            if (page > 0)
            {
                ViewState["page"] = --page;
                this.ListViewUsers.DataBind();
            }
        }

        protected void FirstPage_ServerClick(object sender, EventArgs e)
        {
            ViewState["page"] = 0;
            this.ListViewUsers.DataBind();

        }

        protected void LastPage_ServerClick(object sender, EventArgs e)
        {
            var totalCount = data.Users.Count();

            var lastPage = totalCount / PageSize;
            if (totalCount % PageSize == 0)
            {
                lastPage--;
            }

            ViewState["page"] = lastPage;
            this.ListViewUsers.DataBind();
        }

        // User details
        public List<User> FormViewUserDetails_GetData()
        {
            if (ViewState["selectedTodo"] == null)
            {
                return new List<User>();
            }

            var id = (string)ViewState["selectedTodo"];
            var foundTodo = data.Users.Find(id);
            return new List<User> { foundTodo };
        }

        public void FormViewUserDetails_UpdateItem(string id)
        {
            User item = null;
            item = data.Users.Find(id);
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
                DisplayMessage("Item updated");
            }
        }

        public void FormViewUserDetails_DeleteItem(int id)
        {
            var item = data.Users.Find(id);
            data.Users.Remove(item);
            data.SaveChanges();
            DisplayMessage("Item deleted");
            ViewState["selectedTodo"] = null;
            this.ListViewUsers.DataBind();
            this.FormViewUserDetails.DataBind();
        }

    }
}