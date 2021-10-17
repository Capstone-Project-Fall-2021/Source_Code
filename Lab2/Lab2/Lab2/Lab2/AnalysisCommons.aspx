<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AnalysisCommons.aspx.cs" Inherits="Lab2.AnalysisCommons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lblAnalysis" runat="server" Text="" ></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Please select an analyzed document: "></asp:Label>
    <br />
    <asp:ListBox ID="analysisBox" runat="server" Height ="200"></asp:ListBox>
    <br />
    <asp:Button ID="select" runat="server" Text="View Selected Document" OnClick ="select_Click" />
    <br />
    <br/>
    <asp:Label ID="date" runat="server" Text="Date "></asp:Label>
      <asp:TextBox ID="aDate"  runat="server" Text=""></asp:TextBox>
     <br/>
    <br/>
    <asp:Label ID="desc" runat="server" Text="Analysis Description "></asp:Label>
     <br/>
    <asp:TextBox ID="aDesc"  runat="server" Text="" TextMode ="MultiLine" Height="300" Width="300"></asp:TextBox>
    <br/>
    <br/>
     Analysis Results<br/>
    <asp:TextBox ID="aBody"  runat="server" Text="" TextMode ="MultiLine" Height="377px" Width="367px"></asp:TextBox>
    <br/>
    
    <asp:Button ID="Friend" runat="server" Text="Friends" OnClick ="Friend_Click" />
    <asp:Button ID="Homepage" runat="server" Text="HomePage" OnClick ="Homepage_Click" />
</asp:Content>
