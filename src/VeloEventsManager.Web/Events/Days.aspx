<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Days.aspx.cs" Inherits="VeloEventsManager.Web.Events.Days" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:FormView runat="server" ID="FormViewEventDay"
		ItemType="VeloEventsManager.Models.EventDay"
		DataKeyNames="Id"
		SelectMethod="ListViewEventDay_GetData"
		UpdateMethod="UpdateItem"
		DeleteMethod="DeleteItem"
		RenderOuterTable="false">
		<ItemTemplate>
			<div class="panel panel-primary">
				<div class="panel-heading">
					<h3 class="panel-title">Event: <%# Item.Event.Name %></h3>
				</div>
				<div class="panel-body">
					<div class="row">
						<div class="col-md-6">
							<h3>Info</h3>
							<div><strong>Date: </strong><%#: Item.Date.ToString("d-MMM-yyyy") %> </div>
							<br />
							<div><strong>Description: </strong><%# Item.Description %></div>
							<br />
							<div><strong>Start: </strong><%# Item.StartTime.ToString("hh:mm tt") %></div>
							<br />
							<div><strong>End: </strong><%# Item.EndTime.ToString("hh:mm tt") %></div>
							<br />
							<div><strong>Main Route Name: </strong><%# Item.MainRoute.Name %></div>
							<br />
							<div><strong>- Lattitude: </strong><%# Item.MainRoute.StartPoint.Lattitude %></div>
							<br />
							<div><strong>- Longitude: </strong><%# Item.MainRoute.StartPoint.Longitude %></div>
							<asp:Button ID="ButtonEdit" runat="server"
								CommandName="Edit"
								Text="Edit"
								CssClass="btn btn-default" />
							<asp:Button ID="ButtonDelete" runat="server"
								CommandName="Delete"
								Text="Delete"
								CssClass="btn btn-default" />
						</div>
						<div class="col-md-6">
							<h3>Optional Routes</h3>
							<asp:ListView runat="server" ID="ListViewOptionalRoutes" ItemType="VeloEventsManager.Models.Route" DataSource="<%# Item.OptionalRoutes %>">
								<LayoutTemplate>
									<ul>
										<asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
									</ul>
								</LayoutTemplate>
								<ItemTemplate>
									<li>
										<%# Item.Name %>
										<asp:Button runat="server" ID="ButtonDeleteOptionalRoute" Text="X" CssClass="btn btn-danger" />
									</li>
								</ItemTemplate>
								<EmptyDataTemplate>
									No optional routes.
								</EmptyDataTemplate>
							</asp:ListView>
						</div>
					</div>
				</div>
			</div>
		</ItemTemplate>
		<EditItemTemplate>
			<div class="panel panel-primary">
				<div class="panel-heading">
					<h3 class="panel-title">Event: <%# Item.Event.Name %></h3>
				</div>
				<div class="panel-body">
					<strong>Date:</strong>
					<asp:TextBox runat="server" ID="TextBoxEditDate" TextMode="DateTime" Text="<%#: BindItem.Date %>" />
					<br />
					<strong>Description:</strong>
					<asp:TextBox runat="server" ID="TextBoxEditDescription" TextMode="MultiLine" Text=" <%# BindItem.Description %>" />
					<br />
					<div>
						<strong>Start:</strong>
						<asp:TextBox runat="server" ID="TextBoxEditStartTime" TextMode="DateTime" Text=" <%# BindItem.StartTime %>" />
						<br />
						<div>
							<strong>End:</strong>
							<asp:TextBox runat="server" ID="TextBoxEditEndTime" TextMode="DateTime" Text=" <%# BindItem.EndTime %>" />
							<br />
							<div>
								<strong>Main Route Name:</strong>
								<asp:TextBox runat="server" ID="TextBoxEditMainRouteName" Text=" <%# BindItem.MainRoute.Name %>" />
							</div>
							<br />
							<div>
								<strong>- Lattitude:</strong>
								<asp:TextBox runat="server" ID="TextBox1" Text=" <%# BindItem.MainRoute.StartPoint.Lattitude %>" />
							</div>
							<br />
							<div>
								<strong>- Longitude:</strong>
								<asp:TextBox runat="server" ID="TextBox2" Text="<%# BindItem.MainRoute.StartPoint.Longitude %>" />
							</div>
							<asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
							<asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
						</div>
					</div>
				</div>
			</div>
		</EditItemTemplate>
	</asp:FormView>
</asp:Content>
