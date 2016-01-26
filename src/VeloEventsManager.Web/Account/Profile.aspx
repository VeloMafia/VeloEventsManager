<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="VeloEventsManager.Web.Account.Profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <asp:FormView runat="server" ID="FormViewUserDetails"
                ItemType="VeloEventsManager.Models.User"
                DataKeyNames="Id"
                SelectMethod="GetData"
                UpdateMethod="UpdateItem"
                RenderOuterTable="false">

                <ItemTemplate>
                    <div class="panel panel-primary">

                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> detias</h3>
                        </div>

                        <div class="panel-body">

                            <div class="col-md-6 col-md-offset-3" id="avatar-container">
                                <img src="/Uploaded_Files/<%# Item.Avatar %>"
                                    class="img-thumbnail img-responsive" />
                            </div>

                            <div class="col-md-12 well-sm">
                                <p><span class="text-primary">Email:</span> <%#: Item.Email %></p>
                            </div>

                            <div class="col-md-12 well-sm">
                                <span class="text-primary">User roles: </span>
                                <asp:Repeater runat="server" ID="RepeaterRoles"
                                    DataSource="<%# Item.AppRoles.ToList() %>"
                                    ItemType="VeloEventsManager.Models.AppRole">
                                    <ItemTemplate>
                                        <span class="label label-default"><%#:Item.Name %></span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <div id="events" class="col-md-12 well-sm">
                                <span class="text-primary">Events: </span>
                                <asp:Repeater runat="server" ID="RepeaterEvents"
                                    DataSource="<%# Item.Events.ToList() %>"
                                    ItemType="VeloEventsManager.Models.Event">
                                    <ItemTemplate>
                                        <span class="label label-default"><%#:Item.Name %></span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <div class="col-md-12 well-sm">
                                <asp:Button ID="ButtonEdit" runat="server"
                                    CommandName="Edit"
                                    Text="Edit"
                                    CssClass="btn btn-default" />
                                <asp:Button ID="ButtonDelete" runat="server"
                                    CommandName="Delete"
                                    Text="Delete"
                                    CssClass="btn btn-danger" />
                            </div>

                        </div>
                    </div>
                </ItemTemplate>

                <EditItemTemplate>
                    <div class="panel panel-primary">

                        <div class="panel-heading">
                            <h3 class="panel-title"><%#: Item.UserName %> edit details</h3>
                        </div>

                        <div class="panel-body">

                            <div class="form-group col-md-12">
                                <span class="text-primary">Avatar</span>
                                <asp:FileUpload ID="FileUploadControl" runat="server" />
                            </div>

                            <div id="email" class="form-group col-md-12">
                                <span class="text-primary">Email</span>
                                <asp:TextBox runat="server" ID="Email"
                                    Text="<%#: BindItem.Email %>" />
                            </div>

                            <div id="events" class="form-group col-md-12">
                                <span class="text-primary">Events: </span>
                                <asp:ListBox runat="server" ID="ListBoxEditEvents"
                                    DataSource="<%# Item.Events %>"
                                    ItemType="VeloEventsManager.Models.Event"
                                    DataTextField="Name"
                                    DataValueField="Id"
                                    SelectionMode="Multiple"></asp:ListBox>
                                <asp:Button ID="RemoveEvent" runat="server"
                                    OnClick="RemoveEvent_Click"
                                    Text="remove" />
                            </div>

                            <div class="col-md-12">
                                <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                            </div>
                        </div>

                    </div>
                </EditItemTemplate>

            </asp:FormView>
        </div>
    </div>
</asp:Content>
