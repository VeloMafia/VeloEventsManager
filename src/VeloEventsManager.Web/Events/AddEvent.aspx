<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="VeloEventsManager.Web.Events.AddEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Add an Event</h1>
	<asp:ListView runat="server" ID="ListViewAddEvent" ItemType="VeloEventsManager.Models.Event" DataKeyNames="Id" SelectMethod="FormViewAddEvent_GetItem" InsertMethod="FormViewAddEvent_InsertItem" InsertItemPosition="FirstItem">
		<InsertItemTemplate>
			<div class="row">
				<h3>Name: 
                    <asp:TextBox runat="server" ID="TextBoxInsertName" Width="300" Text="<%#: BindItem.Name %>"></asp:TextBox>
					<asp:RequiredFieldValidator ErrorMessage="Name is required!" ValidationGroup="InsertEvent" ControlToValidate="TextBoxInsertName" ForeColor="Red" runat="server" />
				</h3>
				<p>
					Description: 
                    <asp:TextBox runat="server" ID="TextBoxInsertDescription" Width="300" TextMode="MultiLine" Text="<%#: BindItem.Description %>" Rows="6"></asp:TextBox>
					<asp:RequiredFieldValidator ErrorMessage="Description is Required!" ValidationGroup="InsertEvent" ControlToValidate="TextBoxInsertDescription" ForeColor="Red" runat="server" />
				</p>
				<p>
					Start Date: 
                    <asp:TextBox runat="server" ID="TextBoxInsertStartDate" Width="300" TextMode="DateTime" Text="<%#: BindItem.StartDate %>"></asp:TextBox>
					<asp:RequiredFieldValidator ErrorMessage="Start date is Required!" ValidationGroup="InsertEvent" ControlToValidate="TextBoxInsertStartDate" ForeColor="Red" runat="server" />
				</p>
				<p>
					End Date: 
                    <asp:TextBox runat="server" ID="TextBoxInsertEndDate" Width="300" TextMode="DateTime" Text="<%#: BindItem.EndDate %>"></asp:TextBox>
					<asp:RequiredFieldValidator ErrorMessage="End date is Required!" ValidationGroup="InsertEvent" ControlToValidate="TextBoxInsertEndDate" ForeColor="Red" runat="server" />
				</p>
				<p>
					Distance: 
                    <asp:TextBox runat="server" ID="TextBoxInsertDistance" Width="300" TextMode="Number" Text="<%#: BindItem.TotalDistance %>"></asp:TextBox>
					<asp:RequiredFieldValidator ErrorMessage="Distance is Required!" ValidationGroup="InsertEvent" ControlToValidate="TextBoxInsertDistance" ForeColor="Red" runat="server" />
				</p>

				<p>
					Price: 
                    <asp:TextBox runat="server" ID="TextBoxInsertPrice" Width="300" TextMode="Number" Text="<%#: BindItem.PriceInLeva %>"></asp:TextBox>
					<asp:RequiredFieldValidator ErrorMessage="Price is Required!" ValidationGroup="InsertEvent" ControlToValidate="TextBoxInsertPrice" ForeColor="Red" runat="server" />
				</p>
				<div>
					<asp:LinkButton runat="server" ID="ButtonInsertEvent" CssClass="btn btn-success" CommandName="Insert" Text="Create" CausesValidation="true" ValidationGroup="InsertEvent" />
					<asp:LinkButton runat="server" ID="ButtonCancelEvent" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
				</div>
			</div>
		</InsertItemTemplate>
	</asp:ListView>
</asp:Content>
