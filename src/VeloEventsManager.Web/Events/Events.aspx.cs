namespace VeloEventsManager.Web.Events
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Dynamic;
	using System.Web.ModelBinding;
	using System.Web.UI.WebControls;

	using VeloEventsManager.Data;
	using VeloEventsManager.Models;

	public partial class Events : System.Web.UI.Page
	{
		private IVeloEventsManagerDbContext dbContext;
		private bool changeDirection = false;

		public Events()
		{
			this.dbContext = new VeloEventsManagerDbContext();
		}

		public SortDirection SortDirection
		{
			get
			{
				SortDirection direction = SortDirection.Ascending;
				if (ViewState["sortdirection"] != null)
				{
					if ((SortDirection)ViewState["sortdirection"] == SortDirection.Descending &&
						!this.changeDirection ||
						(SortDirection)ViewState["sortdirection"] == SortDirection.Ascending &&
						this.changeDirection)
					{
						direction = SortDirection.Descending;
					}
				}

				ViewState["sortdirection"] = direction;
				return direction;
			}
			set
			{
				ViewState["sortdirection"] = value;
			}
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
		public IQueryable<Event> ListViewEvents_GetData([ViewState("OrderBy")]String OrderBy = null)
		{
			var events = this.dbContext.Events.OrderBy(x => x.Id).AsQueryable();
			if (OrderBy != null)
			{
				switch (this.SortDirection)
				{
					case SortDirection.Ascending:
						events = events.OrderBy(OrderBy);
						break;
					case SortDirection.Descending:
						events = events.OrderBy(OrderBy + " Descending");
						break;
					default:
						events = events.OrderBy(OrderBy + " Descending");
						break;
				}

				return events;
			}
			else
			{
				events.OrderBy("StartDate Descending");
			}

			return events.AsQueryable();
		}

		protected void ListViewEvents_Sorting(object sender, ListViewSortEventArgs e)
		{
			e.Cancel = true;
			if (ViewState["OrderBy"] != null &&
				(string)ViewState["OrderBy"] == e.SortExpression)
			{
				this.changeDirection = true;
			}
			else
			{
				this.SortDirection = SortDirection.Ascending;
			}

			ViewState["OrderBy"] = e.SortExpression;
			this.ListViewEvents.DataBind();

			this.ChangeButtonSortColor(e.SortExpression);
		}

		private void ChangeButtonSortColor(string sortExpression)
		{
			try
			{
				var btns = new List<LinkButton>()
				{
					(LinkButton)this.ListViewEvents.Controls[0].Controls[1],
					(LinkButton)this.ListViewEvents.Controls[0].Controls[3],
					(LinkButton)this.ListViewEvents.Controls[0].Controls[5],
					(LinkButton)this.ListViewEvents.Controls[0].Controls[7],
					(LinkButton)this.ListViewEvents.Controls[0].Controls[9],
				};

				foreach (var btn in btns)
				{
					if (btn.CommandArgument == sortExpression)
					{
						var hasBtnSortAscClass = btn.CssClass.Contains("btn-sort-ascending");
						var hasBtnSortDescClass = btn.CssClass.Contains("btn-sort-descending");

						if (!hasBtnSortAscClass && !hasBtnSortDescClass)
						{
							btn.CssClass = btn.CssClass + " btn-sort-ascending";
						}
						else if (hasBtnSortAscClass)
						{
							// remove asc
							// add desc
							int index = btn.CssClass.IndexOf("btn-sort-ascending");
							btn.CssClass = (index < 0)
								? btn.CssClass
								: btn.CssClass.Remove(index, "btn-sort-ascending".Length);

							btn.CssClass = btn.CssClass + " btn-sort-descending";
						}
						else if (hasBtnSortDescClass)
						{
							// remove desc
							// add acs
							int index = btn.CssClass.IndexOf("btn-sort-descending");
							btn.CssClass = (index < 0)
								? btn.CssClass
								: btn.CssClass.Remove(index, "btn-sort-descending".Length);

							btn.CssClass = btn.CssClass + " btn-sort-ascending";
						}
					}
					else
					{
						// remove acs
						// remove desc
						int indexAsc = btn.CssClass.IndexOf("btn-sort-ascending");
						btn.CssClass = (indexAsc < 0)
							? btn.CssClass
							: btn.CssClass.Remove(indexAsc, "btn-sort-ascending".Length);

						int indexDesc = btn.CssClass.IndexOf("btn-sort-descending");
						btn.CssClass = (indexDesc < 0)
							? btn.CssClass
							: btn.CssClass.Remove(indexDesc, "btn-sort-descending".Length);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}
}