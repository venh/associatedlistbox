<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="AssociatedListBox" Namespace="ASP" Assembly="AssociatedListBoxControl,Version=1.0.0.0, Culture=neutral, PublicKeyToken=9497d5948d1b1754" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="scriptMgr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updPnl" runat="server">
    <ContentTemplate>
    <AssociatedListBox:associatedlistboxuc_ascx ID="clb" runat="server" AvailableListBoxLabelHeader="<b>Available List</b>" AssociatedListBoxLabelHeader="<b>Associated List</b>" />
    </ContentTemplate>
    </asp:UpdatePanel>     
    </div>
    </form>
</body>
</html>
