<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="VeloEventsManager.Web.Events.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:FormView runat="server" ID="FormViewEventDetails" ItemType="VeloEventsManager.Models.Event" SelectMethod="FormViewEventDetails_GetItem">
		<ItemTemplate>
			<div class="jumbotron">
				<h1><%#: Item.Name %></h1>
				<div>From: <%#: Item.StartDate.Date.ToString("d-MMM-yyyy") %> To: <%#: Item.EndDate.Date.ToString("d-MMM-yyyy") %></div>
				<p>Description: <%#: Item.Description %></p>
				<br />
				<div>
					<p>
						Total days: <%#: Item.EventDays.Count %>
					</p>
					<p>
						Total participants: <%#: Item.Participants.Count %>
					</p>
				</div>
				<div>
					<asp:Repeater runat="server" ItemType="VeloEventsManager.Models.EventDay" DataSource="<%# Item.EventDays%>">
						<HeaderTemplate>
							<p>Program:</p>
						</HeaderTemplate>
						<ItemTemplate>
							<div class="list-group">
								<a href="<%# string.Format("/Events/Days.aspx?id={0}", Item.Id) %>" class="list-group-item">
									<h4 class="list-group-item-heading"><%# Item.Date.ToString("d-MMM-yyyy") %></h4>
									<p class="list-group-item-text"><%# Item.Description %></p>
									<p class="list-group-item-text">Time: <%# Item.StartTime.ToString("hh:mm") %> - <%# Item.EndTime.ToString("hh:mm") %></p>
									<p class="list-group-item-heading">Total distance: <%# Item.MainRoute.LengthInMeters %> km.</p>
								</a>
							</div>
						</ItemTemplate>
						<SeparatorTemplate>
						</SeparatorTemplate>
					</asp:Repeater>
				</div>
			</div>
		</ItemTemplate>
	</asp:FormView>
</asp:Content>
