<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="VeloEventsManager.Web.Events.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link type="text/css" href="../Content/ButtonsSort.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1>All events</h1>
	<asp:ListView
		runat="server"
		ID="ListViewEvents"
		ItemType="VeloEventsManager.Models.Event"
		SelectMethod="ListViewEvents_GetData"
		OnSorting="ListViewEvents_Sorting">
		<LayoutTemplate>
			<div class="row">
				<asp:LinkButton runat="server" ID="ButtonSortByName" CssClass="col-md-2 btn btn-default" Text="Sort by Name" CommandArgument="Name" CommandName="Sort" />
				<asp:LinkButton runat="server" ID="ButtonSortByStartDate" CssClass="col-md-2 btn btn-default" Text="Sort by Start Date" CommandArgument="StartDate" CommandName="Sort" />
				<asp:LinkButton runat="server" ID="ButtonSortByParticipants" CssClass="col-md-2 btn btn-default" Text="Sort by Participants" CommandArgument="Participants.Count" CommandName="Sort" />
				<asp:LinkButton runat="server" ID="ButtonSortByPrice" CssClass="col-md-2 btn btn-default" Text="Sort by Price" CommandArgument="PriceInLeva" CommandName="Sort" />
				<asp:LinkButton runat="server" ID="ButtonSortByDistance" CssClass="col-md-2 btn btn-default" Text="Sort by Distance" CommandArgument="TotalDistance" CommandName="Sort" />
			</div>
			<asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
			<div class="row">
				<asp:DataPager runat="server" ID="DataPagerEvents" PagedControlID="ListViewEvents" PageSize="5">
					<Fields>
						<asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false" ButtonCssClass="btn btn-primary" />
						<asp:NumericPagerField />
						<asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false" ShowNextPageButton="true" ShowLastPageButton="true" ButtonCssClass="btn btn-primary" />

					</Fields>
				</asp:DataPager>
			</div>
		</LayoutTemplate>
		<ItemTemplate>
			<h1>Event: <asp:HyperLink runat="server" NavigateUrl='<%# "~/Events/Details?id=" + Item.Id %>'><%#: Item.Name %></asp:HyperLink></h1>
			<div>Participants: <%#: Item.Participants.Count %></div>
			<div>Price: <%#: Item.PriceInLeva%></div>
			<div>TotalDistance: <%#: Item.TotalDistance%></div>
			<div>StartDate: <%#: Item.StartDate%></div>
			<div>EndDate: <%#: Item.EndDate%> </div>
		</ItemTemplate>
	</asp:ListView>
</asp:Content>
