using System;
using System.Web;
using System.Web.UI.WebControls;

namespace VeloEventsManager.Web.Controls
{
	public class JoinEventArgs : EventArgs
	{
		public JoinEventArgs(int dataID, bool isJoin)
		{
			this.DataID = dataID;
			this.IsJoin = isJoin;
		}

		public int DataID { get; set; }
		public bool IsJoin { get; set; }
	}

	public partial class JoinControl : System.Web.UI.UserControl
	{
		public bool IsJoin { get; set; }

		public int DataID { get; set; }

		public delegate void JoinEventHandler(object sender, JoinEventArgs e);

		public event JoinEventHandler Join;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!HttpContext.Current.User.Identity.IsAuthenticated)
			{
				this.ControlWrapper.Visible = false;
			}
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (this.IsJoin)
			{
				this.ButtonJoin.Visible = false;
				this.ButtonUnjoin.Visible = true;
			}
			else
			{
				this.ButtonJoin.Visible = true;
				this.ButtonUnjoin.Visible = false;
			}
		}

		protected void ButtonJoin_Command(object sender, CommandEventArgs e)
		{
			bool isJoin = e.CommandName == "Join";
			var joinEventArgs = new JoinEventArgs(Convert.ToInt32(e.CommandArgument), isJoin);
			this.Join(this, joinEventArgs);
		}
	}
}