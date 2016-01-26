<%@ Page Title="Routes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUserRoutes.aspx.cs" Inherits="VeloEventsManager.Web.Routes.ListRoutes" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button Text="CREATE" runat="server" ID="btnCreate"
        CssClass="btn btn-success btn-lg"
        OnClick="btnCreate_Click" />

    <div class="row">
        <div class="col-md-6">

            <asp:GridView runat="server" ID="GridViewRoutes"
                CssClass="table table-hover table-bordered" GridLines="None"
                SelectedRowStyle-CssClass="active"
                AllowPaging="true" AllowSorting="true"
                AutoGenerateColumns="false"
                ItemType="VeloEventsManager.Models.Route"
                DataKeyNames="Id"
                SelectMethod="GridViewRoutes_GetData"
                DeleteMethod="GridViewRoutes_DeleteItem"
                UpdateMethod="GridViewRoutes_UpdateItem">

                <Columns>

                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-default btn-sm" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="LengthInMeters" HeaderText="LengthInMeters" />
                    <asp:BoundField DataField="AscentInMeters" HeaderText="AscentInMeters" />
                    <asp:BoundField DataField="DescentInMeters" HeaderText="DescentInMeters" />
                    <asp:BoundField DataField="ExpectedDurationInHours" HeaderText="ExpectedDurationInHours" />
                    <asp:TemplateField HeaderText="Present in events">
                        <ItemTemplate>
                            <asp:Repeater runat="server"
                                DataSource="<%# Item.EventDays %>" ItemType="VeloEventsManager.Models.EventDay">
                                <ItemTemplate>
                                    <%#: Item.Event.Name %>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

        </div>
        <div class="col-md-6">

            <asp:FormView runat="server" ID="fvCreateRoute"
                InsertMethod="fvCreateRoute_InsertItem"
                RenderOuterTable="false"
                ItemType="VeloEventsManager.Models.Route"
                DefaultMode="Insert"
                Visible="false">
                <EditItemTemplate>
                    <div class="panel panel-primary">

                        <div class="panel-heading">
                            <h3 class="panel-title">Create new route</h3>
                        </div>

                        <div class="panel-body">

                            Name:
                            <asp:TextBox runat="server" ID="tbNewRouteName"
                                Text="<%#: BindItem.Name %>" />
                            <br />

                            Lenght:
                            <asp:TextBox runat="server" ID="tbNewRouteLength"
                                Text="<%#: BindItem.LengthInMeters %>" />
                            <br />

                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </div>

                    </div>
                </EditItemTemplate>
            </asp:FormView>

        </div>
    </div>

</asp:Content>
