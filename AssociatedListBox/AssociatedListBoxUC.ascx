<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssociatedListBoxUC.ascx.cs" Inherits="AssociatedListBoxUC" %>
<div style="float: left; width: 200px; margin-right: 5px;">
    <p>
        <asp:Label ID="lblAvailable" runat="server" Text=""></asp:Label>
        <asp:ListBox ID="lstBoxAvailable" runat="server" Rows="6" SelectionMode="Multiple"
            Width="201px"></asp:ListBox>
    </p>
</div>
<div style="float: left; padding-top: 40px;">
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="&#9658;" OnClick="btnAdd_Click" UseSubmitBehavior="False" /><br />
        <asp:Button ID="btnRemove" runat="server" Text="&#9668;" OnClick="btnRemove_Click" /></p>
</div>
<div style="float: left; width: 200px; margin-left: 5px;">
    <p>
        <asp:Label ID="lblAssociated" runat="server" Text=""></asp:Label>
        <asp:ListBox ID="lstBoxAssociated" runat="server" Rows="6" SelectionMode="Multiple"
            Width="201px"></asp:ListBox>
        <br />
    </p>
</div>
<div style="float: left; padding-top: 40px; margin-left: 5px;">
    <asp:Button ID="btnUp" runat="server" Text="&#9650;" OnClick="btnUp_Click" UseSubmitBehavior="False" /><br />
    <asp:Button ID="btnDown" runat="server" Text="&#9660;" OnClick="btnDown_Click" UseSubmitBehavior="False" /></div>
<div style="clear: both;">
    <div style="height: 18px">
        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
    </div>
</div>

