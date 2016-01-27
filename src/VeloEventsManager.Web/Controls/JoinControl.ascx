<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JoinControl.ascx.cs" Inherits="VeloEventsManager.Web.Controls.JoinControl" %>

<asp:ScriptManager ID="ScriptManager" runat="server" />
<asp:UpdatePanel runat="server" ID="ControlWrapper">
	<ContentTemplate>
		<asp:LinkButton runat="server" ID="ButtonJoin" CssClass="btn btn-default" Text="Join" CommandArgument="<%# this.DataID %>" CommandName="Join" OnCommand="ButtonJoin_Command" />
		<asp:LinkButton runat="server" ID="ButtonUnjoin" CssClass="btn btn-default" Text="Unjoin" CommandArgument="<%# this.DataID %>" CommandName="Unjoin" OnCommand="ButtonJoin_Command" />
	</ContentTemplate>
</asp:UpdatePanel>
