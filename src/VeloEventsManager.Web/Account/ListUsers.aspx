<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="VeloEventsManager.Web.Account.ListUsers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Users</h3>
    Sort Name:
    <asp:dropdownlist runat="server" id="orderByName"
        onselectedindexchanged="orderByDate_SelectedIndexChanged"
        autopostback="true">
        <asp:ListItem Selected="True" Text="none" Value="0" />
        <asp:ListItem Text="asc" Value="1" />
        <asp:ListItem Text="des" Value="2" />
    </asp:dropdownlist>
    <div class="row">
        <div class="col-md-6">

            <asp:listview runat="server" id="ListViewUsers"
                datakeynames="Id"
                selectmethod="ListViewUsers_GetData"
                itemtype="VeloEventsManager.Models.User"
                deletemethod="FormViewUserDetails_DeleteItem">

                <LayoutTemplate>
                    <ul class="list-group">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li class="list-group-item" runat="server" id="li1">
                        <a href="#" runat="server"
                            itemid="<%# Item.Id %>"
                            onserverclick="ListViewUsers_ServerClick">
                            <%#: Item.UserName %></a>
                        <br />
                        <asp:Button ID="ButtonDelete" runat="server"
                            CommandName="Delete"
                            Text="Delete"
                            CssClass="btn btn-default" />
                        <button id="ButtonDetails" runat="server"
                            onserverclick="ListViewUsers_ServerClick"
                            itemid="<%# Item.Id %>"
                            class="btn btn-default">
                            Details</button>
                    </li>
                </ItemTemplate>

            </asp:listview>

            <ul class="pagination">
                <li>
                    <button id="FirstPage" runat="server"
                        onserverclick="FirstPage_ServerClick"
                        class="btn btn-default">
                        First</button>
                </li>
                <li>
                    <button id="PrevPage" runat="server"
                        onserverclick="PrevPage_ServerClick"
                        class="btn btn-default">
                        Prev</button>
                </li>
                <li runat="server" id="pageNumber"><%: ViewState["page"] %></li>
                <li>
                    <button id="NextPage" runat="server"
                        onserverclick="NextPage_ServerClick"
                        class="btn btn-default">
                        Next</button>
                </li>
                <li>
                    <button id="LastPage" runat="server"
                        onserverclick="LastPage_ServerClick"
                        class="btn btn-default">
                        Last</button>
                </li>
            </ul>

        </div>

        <div class="col-md-6">

            <asp:formview runat="server" id="FormViewUserDetails"
                itemtype="VeloEventsManager.Models.User"
                datakeynames="Id"
                selectmethod="FormViewUsers_GetData"
                updatemethod="FormViewUserDetails_UpdateItem"
                insertmethod="FormViewUserDetails_InsertItem"
                deletemethod="FormViewUserDetails_DeleteItem"
                renderoutertable="false">
                <EmptyDataTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            Nothing selected
                        </div>
                    </div>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> detias</h3>
                        </div>
                        <div class="panel-body">
                            <p>User email: <%#: Item.Email %></p>
                            <asp:Button ID="ButtonEdit" runat="server"
                                CommandName="Edit"
                                Text="Edit"
                                CssClass="btn btn-default" />
                            <asp:Button ID="Button1" runat="server"
                                CommandName="Delete"
                                Text="Delete"
                                CssClass="btn btn-default" />
                        </div>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> edit details</h3>
                        </div>
                        <div class="panel-body">
                            Edit mail:
                            <asp:TextBox runat="server" ID="editTitle"
                                Text="<%#: BindItem.Email %>" />
                            <br />
                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </div>
                    </div>
                </EditItemTemplate>
            </asp:formview>

        </div>
    </div>

</asp:Content>
