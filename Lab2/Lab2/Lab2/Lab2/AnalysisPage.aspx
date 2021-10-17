<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AnalysisPage.aspx.cs" Inherits="Lab2.AnalysisPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <asp:Label ID="lblAnalysis" runat="server" Text="Analysis"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Please select analyzed document: "></asp:Label>
    <br />
    <asp:ListBox ID="analysisBox" runat="server" Height ="150" Width="200"></asp:ListBox>
    <br />
    <asp:Button ID="Select" runat="server" Text="View Analysis Text Body" OnClick="Select_Click" />
    <asp:Button ID="Share" runat="server" Text="Share Analysis" OnClick = "Share_Click" />
    <br/>
    <br/>
    <asp:Label ID="Label1" runat="server" Text="Shared Analysis: "></asp:Label>
    <br/>
     <asp:ListBox ID="SharedAnalysis" runat="server" Height ="150" Width="200"></asp:ListBox>
    <br/>
    <br/>
      <asp:Label ID="date" runat="server" Text="Analysis Date: "></asp:Label>
    <asp:TextBox ID="aDate" runat="server" Text =""></asp:TextBox>
     <br/>
    <br/>
     <asp:Label ID="description" runat="server" Text="Analysis Description: "></asp:Label>
    <br/>
     <asp:TextBox ID="aDescription" runat="server" Text ="" TextMode ="MultiLine" height="300" Width ="300"></asp:TextBox>
     <br />
    <br />
    Analysis Results<br/>
    <asp:TextBox ID="aBody"  runat="server" Text="" TextMode ="MultiLine" Height="377px" Width="367px"></asp:TextBox>
    <br/>
    <asp:Button ID="SubmitNew" runat="server" Text="Submit New Analysis" OnClick ="SubmitNew_Click" />
    <asp:Button ID="Back" runat="server" Text="Back" OnClick ="Back_Click" />
   

</asp:Content>
