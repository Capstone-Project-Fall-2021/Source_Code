<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchFriend.aspx.cs" Inherits="Lab2.SearchFriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <asp:Label ID = "label3" runat="server" Text="Enter User's email"></asp:Label>
    <asp:TextBox ID = "SearchBox" Text ="" runat="server"></asp:TextBox>
    <asp:Button ID ="Search" runat="server" Text="Search" OnClick ="Search_Click " />
    <br />
    <asp:ListBox ID="friend" runat="server" width ="200" height ="50"></asp:ListBox>
    <br />
    <asp:Button ID="Add" runat="server" Text="add" OnClick ="Add_Click" />
    <br />
    <asp:Label ID ="Label1" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
   
     <asp:Label ID ="Label2" runat="server" Text="Friends List"></asp:Label>
    <br />
    <asp:ListBox ID="FriendList" runat="server" width ="200" height ="200"></asp:ListBox>
    <br />
    <asp:Button ID="Remove" runat="server" Text="Remove Friend" OnClick ="Remove_Click" />
    <asp:Button ID="View" runat="server" Text="View Shared Analysis" OnClick = "View_Click" />
    <asp:Button ID = "Home" runat="server" Text="Homepage" OnClick ="Home_Click" />



</asp:Content>
