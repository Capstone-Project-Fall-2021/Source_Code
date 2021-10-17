<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubmitPage.aspx.cs" Inherits="Lab2.SubmitPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblAnalysis" runat="server" Text="Analysis Request Submission"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Please select a document to be analyzed: "></asp:Label>
    <br />
    <asp:ListBox ID="analysisBox" runat="server" Height ="400" ></asp:ListBox>

   <br />
     <asp:Button ID="Select" runat="server" Text="Ok" OnClick ="Select_Click" />
    <asp:Button ID="Back" runat="server" Text="Back" OnClick = "Back_Click" />
  <asp:Button ID="Home" runat="server" Text="Home" OnClick = "Home_Click" />
      <br />
    <asp:Label ID="submitDisplay" runat="server" Text="" ForeColor ="green"></asp:Label>
   
</asp:Content>
