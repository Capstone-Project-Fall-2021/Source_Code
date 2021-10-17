<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RESTForm.aspx.cs" Inherits="InClassWebApp.RESTForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSelectAnalysis" runat="server" Text="SelectAnalysis"></asp:Label>
            <asp:DropDownList ID="ddlSAList" runat="server"></asp:DropDownList>
            <asp:Label ID="lblRequests" runat="server" Text="Choose Request:"></asp:Label>
            <asp:DropDownList ID="ddlRequest" runat="server">
                <asp:ListItem Text="gettitle"></asp:ListItem>
                <asp:ListItem Text="getsource"></asp:ListItem>
                <asp:ListItem Text="getpeople"></asp:ListItem>
                <asp:ListItem Text="getplaces"></asp:ListItem>
                <asp:ListItem Text="getvisinteractionschord"></asp:ListItem>
                <asp:ListItem Text="getvisnarrativeweb"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-subjects"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-places"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-people"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-groups"></asp:ListItem>
                <asp:ListItem Text="getsentencedetails"></asp:ListItem>
                <asp:ListItem Text="showdashboard"></asp:ListItem>
                <asp:ListItem Text="showbootstrapdashboard"></asp:ListItem>

            </asp:DropDownList>
            <br />
            <asp:Button ID="btnMakeRequest" runat="server" Text="Select" OnClick="btnMakeRequest_Click" />
          
            <br />
            <asp:TextBox ID="txtDisplay" runat="server" Rows="15" Height="200" Width="400" TextMode="MultiLine" ></asp:TextBox>
             <br />
             <asp:Button ID="Home" runat="server" Text="Homepage" OnClick="Home_Click" />
        </div>
        <div runat="server" id="displayViz"></div>
    </form>
</body>
</html>
