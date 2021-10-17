<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Lab2.LoginPage" %>



            <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
            <br />
            &nbsp;<asp:Label ID="lblLoginPage" runat="server" Text="Please Log In: " Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUsername" runat="server" Text="User Name: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Width="179px"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="187px" Height="19px"></asp:TextBox>
            <br />
             
            <asp:Button ID="Login" runat="server" Text="Login->" OnClick="Login_Click" />
                 <asp:Button ID="create" runat="server" Text="New User" OnClick ="create_Click" />
             
            <br />
    
            <asp:Label ID="lblIncorrectL" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
            </asp:Content>

