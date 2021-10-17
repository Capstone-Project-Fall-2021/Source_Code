<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewUserPass.aspx.cs" Inherits="Lab2.NewUserPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="container-fluid">
        <div class="row">
         <div class="col-lg-12">
            <div class="card" style="width: 40rem; padding:40px; text-align:center; background-color:lightgrey;">
    <asp:Label ID="Label1" runat="server" style="font-size:45px; font-family: interstate-condensed, sans-serif; font-weight: 700;font-style: normal;" Text="Create Profile" Font-Bold="true" Font-Size="Larger" ForeColor="#9900CC"></asp:Label>
       <br />
    <asp:Label ID="Organization" runat="server" Text="Organization" Font-Bold="true" ></asp:Label>
    <asp:TextBox ID="organizationText" runat="server" Text=""  ></asp:TextBox>
     <br />
    <asp:Label ID="UserName" runat="server" Text="Username"  Font-Bold="true"></asp:Label>
    <asp:TextBox ID="userNameText" runat="server" Text=""></asp:TextBox>
    <br />
    <asp:Label ID="Password" runat="server" Text="Password"  Font-Bold="true"></asp:Label>
    <asp:TextBox ID="passwordText" runat="server" Text =""></asp:TextBox>
    <br />
    <asp:Button ID="back" runat="server" Text="Back" OnClick ="back_Click" />
    <asp:Button ID="Save" runat="server" Text="Sign Up" OnClick ="Save_Click" />
      </div>
      </div>
      </div>
   </div>

</asp:Content>
