<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="Lab2.Documents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">]
    <br />
    <asp:Label ID="Document" runat="server" Text="Documents"></asp:Label>
    <br />
    <br />
    <br />
    <asp:ListBox ID="Story" runat="server" ></asp:ListBox>
    <asp:Button ID="OK" runat="server" Text="View Text Body" OnClick ="OK_Click"  />  
    <br/>
    <br/>
    <asp:TextBox ID="body" runat="server" TextMode="MultiLine" Height="377px" Width="367px"></asp:TextBox>
    <br/>

    <asp:Button ID="Back" runat="server" Text="Homepage" OnClick="Back_Click" />
    
    <asp:Button ID="CreateStory" runat="server" Text="Create New Story" OnClick ="CreateStory_Click" />
</asp:Content>