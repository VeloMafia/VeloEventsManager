using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using VeloEventsManager.Data;

namespace VeloEventsManager.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public bool isAuthenticated = false;
        public bool isAdmin = false;
        private VeloEventsManagerDbContext data = new VeloEventsManagerDbContext();

        public void ShowSuccessMessage(string message)
        {
            this.success.InnerText = message;
            this.success.Attributes.Remove("hidden");
        }

        public void ShowErrorMessage(string message)
        {
            this.error.InnerText = message;
            this.error.Attributes.Remove("hidden");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize();
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (ShouldRemoveItem(e.Item.Text))
            {
                e.Item.Parent.ChildItems.Remove(e.Item);
            }
        }

        private void Authorize()
        {
            isAuthenticated = Context.User.Identity.IsAuthenticated;

            var userId = Context.User.Identity.GetUserId();
            var user = data.Users.Find(userId);
            if (user != null)
            {
                isAdmin = user.AppRoles.Any(x => x.Name == "admin");
            }
        }

        private bool ShouldRemoveItem(string menuText)
        {
            if (menuText == "Users" && !isAuthenticated)
            {
                return true;
            }

            if (menuText == "My Routes" && !isAuthenticated)
            {
                return true;
            }

            if (menuText == "My events" && !isAuthenticated)
            {
                return true;
            }

            if (menuText == "Add event" && !isAdmin)
            {
                return true;
            }

            return false;
        }
    }
}