<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewUserPass.aspx.cs" Inherits="Lab2.NewUserPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br />
    <asp:Label ID="Organization" runat="server" Text="Organization" Font-Bold="true" ></asp:Label>
    <br />
    <asp:TextBox ID="organizationText" runat="server" Text="" Height="125px" Width="425px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="UserName" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="userNameText" runat="server" Text=""></asp:TextBox>
    <br />
    <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passwordText" runat="server" Text =""></asp:TextBox>
    <br />
    <asp:Button ID="Save" runat="server" Text="Sign Up" OnClick ="Save_Click" />

</asp:Content>
