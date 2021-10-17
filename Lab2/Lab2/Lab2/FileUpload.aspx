<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Lab2.FileUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <br/>
    <br/>
    <asp:Label ID="Label1" runat="server" Text="Please Select a file to upload "></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br/>
    <br/>
    <asp:Button ID="Upload" runat="server" Text="Upload" OnClick ="Upload_Click" />
    <br/>
    <br/>
    <asp:Label ID="label5" runat="server" Text="Title"></asp:Label>
    <asp:TextBox ID="titleDisplay" runat="server" Text=""></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
     <asp:TextBox ID="date" runat="server" Text=""></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="Label3" runat="server" Text="Source"></asp:Label>
     <asp:TextBox ID="source" runat="server" Text=""></asp:TextBox>
    <br/>
    <br/>
     <asp:Label ID="Label4" runat="server" Text="Body"></asp:Label>
    <br />
    <asp:TextBox ID="TextDisplay" runat="server" TextMode = "MultiLine" Rows="20" Width ="400" Height ="200" ></asp:TextBox>
     <br />
    <asp:Button ID="save" runat="server" Text="Save" OnClick ="save_Click" ValidationGroup="createStory" />
    <asp:Button ID="back" runat="server" Text="Back" OnClick ="back_Click" />
    <asp:Button ID="Home" runat="server" Text="Home" OnClick ="Home_Click" />
    <br />
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="date" ForeColor="Red" Text="Text Date is required" ValidationGroup="createStory"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="date" ForeColor="Red" 
        ValidationExpression="^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$" ErrorMessage="RegularExpressionValidator" Text="Please enter text date in a format of yyyy-mm-dd or yyyy-m-d"
        ValidationGroup="createStory"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="titleDisplay" ForeColor="Red" Text="Text Title is required" ValidationGroup="createStory"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="source" ForeColor="Red" Text="Text Source is required" ValidationGroup="createStory"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="TextDisplay" ForeColor="Red" Text="Text Body is required" ValidationGroup="createStory"></asp:RequiredFieldValidator>
    <br />
</asp:Content>
