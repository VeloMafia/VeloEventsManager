<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyEvents.aspx.cs" Inherits="VeloEventsManager.Web.Events.MyEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:GridView
		runat="server"
		ID="GridViewMyEvents"
		ItemType="VeloEventsManager.Models.Event"
		SelectMethod="GridViewMyEvents_GetData"
		UpdateMethod="GridViewMyEvents_UpdateItem"
		AutoGenerateColumns="false"
		AllowPaging="true"
		PageSize="5"
		AllowSorting="true">
		<Columns>
			<asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name"/>
			<asp:BoundField HeaderText="Description" DataField="Description" />
			<asp:BoundField HeaderText="Start" DataField="StartDate" SortExpression="StartDate"/>
			<asp:BoundField HeaderText="End" DataField="EndDate" SortExpression="EndDate"/>
			<asp:BoundField HeaderText="Distance" DataField="TotalDistance" SortExpression="TotalDistance"/>
			<asp:BoundField HeaderText="Price" DataField="PriceInLeva" SortExpression="PriceInLeva"/>
		</Columns>
		<EmptyDataTemplate>
			<h3>No events.</h3>
		</EmptyDataTemplate>
	</asp:GridView>
</asp:Content>
