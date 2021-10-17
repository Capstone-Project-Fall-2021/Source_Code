<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Lab2.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
<br />
          <asp:Label ID="Label1" runat="server" Text="HomePage"></asp:Label>
    <br />
    <br />
 Please Select:<br />
     <asp:ListBox ID="ListBox1" runat="server" Width="261px" Height="110px">
         <asp:ListItem Text ="View Profile"></asp:ListItem>
        <asp:ListItem Text ="View Documents"></asp:ListItem>
         <asp:ListItem Text ="Create Document"></asp:ListItem>
        <asp:ListItem Text ="Analysis(Local)"></asp:ListItem>
         <asp:ListItem Text ="Analysis(Story Analyzer)"></asp:ListItem>
         <asp:ListItem Text ="Submit Analysis Request"></asp:ListItem>
         <asp:ListItem Text ="Analysis Commons"></asp:ListItem>
    </asp:ListBox>
    <br />
     
    <asp:Button ID="Button1" runat="server" Text="Ok" OnClick ="Button1_Click" />
    <asp:Button ID="logout" runat="server" Text="Log out" OnClick ="logout_Click" />
    <asp:Label ID="txtDisplay" runat="server" Text="" ForeColor ="Red"></asp:Label>

    <br/>

    </asp:Content>
