<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="VeloEventsManager.Web.Account.ListUsers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Users</h3>

    Sort Name:
    <asp:DropDownList runat="server" ID="orderByName"
        OnSelectedIndexChanged="orderByName_SelectedIndexChanged"
        AutoPostBack="true">
        <asp:ListItem Selected="True" Text="none" Value="0" />
        <asp:ListItem Text="asc" Value="1" />
        <asp:ListItem Text="des" Value="2" />
    </asp:DropDownList>

    <div class="row">
        <div class="col-md-6">

            <asp:ListView runat="server" ID="ListViewUsers"
                DataKeyNames="Id"
                SelectMethod="GetData"
                ItemType="VeloEventsManager.Models.User"
                DeleteMethod="DeleteItem"
                OnSelectedIndexChanged="ListViewUsers_SelectedIndexChanged">

                <LayoutTemplate>
                    <ul class="list-group">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li class="list-group-item" runat="server" id="li1">
                        <div class="row">
                            <div class="col-md-6">
                                <img src="/Uploaded_Files/<%# Item.Avatar %>"
                                    class="img-thumbnail img-responsive" />
                                <br />
                                <asp:Button ID="ButtonDelete" runat="server"
                                    CommandName="Delete"
                                    Text="Delete"
                                    CssClass="btn btn-danger" />
                                <asp:Button Text="Select" runat="server"
                                    CommandName="Select"
                                    CssClass="btn btn-default" />
                            </div>
                            <div class="col-md-6">
                                Username: <%#: Item.UserName %>
                                <br />
                                Events count: <%#: Item.Events.Count() %>
                                <br />
                            </div>
                        </div>
                    </li>
                </ItemTemplate>

                <SelectedItemTemplate>
                    <li class="list-group-item active" runat="server" id="li1">
                        <div class="row">
                            <div class="col-md-6">
                                <img src="/Uploaded_Files/<%# Item.Avatar %>"
                                    class="img-thumbnail img-responsive" />
                                <br />
                                <asp:Button ID="ButtonDelete" runat="server"
                                    CommandName="Delete"
                                    Text="Delete"
                                    CssClass="btn btn-danger" />
                                <asp:Button Text="Select" runat="server"
                                    CommandName="Select"
                                    CssClass="btn btn-default" />
                            </div>
                            <div class="col-md-6">
                                Username: <%#: Item.UserName %>
                                <br />
                                Events count: <%#: Item.Events.Count() %>
                                <br />
                            </div>
                        </div>
                    </li>
                </SelectedItemTemplate>

            </asp:ListView>

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

            <asp:FormView runat="server" ID="FormViewUserDetails"
                ItemType="VeloEventsManager.Models.User"
                DataKeyNames="Id"
                SelectMethod="GetData"
                UpdateMethod="UpdateItem"
                DeleteMethod="DeleteItem"
                RenderOuterTable="false">

                <ItemTemplate>
                    <div class="panel panel-primary">

                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> detias</h3>
                        </div>

                        <div class="panel-body">
                            <p>User email: <%#: Item.Email %></p>
                            <p>
                                User roles:
                                <asp:Repeater runat="server" ID="RepeaterRoles"
                                    DataSource="<%# Item.AppRoles.ToList() %>"
                                    ItemType="VeloEventsManager.Models.AppRole">
                                    <ItemTemplate>
                                        <%#:Item.Name %>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>

                            <p>
                                Events:
                                <asp:Repeater runat="server" ID="RepeaterEvents"
                                    DataSource="<%# Item.Events.ToList() %>"
                                    ItemType="VeloEventsManager.Models.Event">
                                    <ItemTemplate>
                                        <%#:Item.Name %>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>

                            <asp:Button ID="ButtonEdit" runat="server"
                                CommandName="Edit"
                                Text="Edit"
                                CssClass="btn btn-default" />
                            <asp:Button ID="ButtonDelete" runat="server"
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
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Email" 
                                    CssClass="col-md-2 control-label">Email:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="Email" runat="server" Text="<%#: BindItem.Email %>"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="FileUploadControl"
                                     CssClass="col-md-2 control-label">Upload avatar:</asp:Label>
                                <div class="col-md-10">
                                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                                </div>
                            </div>
                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </div>

                    </div>
                </EditItemTemplate>

            </asp:FormView>

        </div>
    </div>

</asp:Content>
