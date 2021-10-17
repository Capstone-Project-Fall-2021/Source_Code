<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateStory.aspx.cs" Inherits="Lab2.CreateStory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblHead" runat="server" Text="Create Story" Font-Bold="true" ForeColor="Blue" Font-Size="Larger"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblTextDate" runat="server" Text="Text Date" Font-Bold="true"></asp:Label>
    <br />
    <asp:TextBox ID="textDate" runat="server" Text="" Width="184px" Height="23px"></asp:TextBox>
    <br />
    <asp:Label ID="lblTextTitle" runat="server" Text="Text Title" Font-Bold="true"></asp:Label>
    <br />
    <asp:TextBox ID="textTitle" runat="server" Text="" Height="51px" Width="731px"></asp:TextBox>
    <br />
    <asp:Label ID="lblTextSource" runat="server" Text="Text Source" Font-Bold="true"></asp:Label>
    <br />
    <asp:TextBox ID="textSource" runat="server" Text="" Width="338px" Height="24px"></asp:TextBox>
    <br />
    <asp:Label ID="lblTextBody" runat="server" Text="Text Body" Font-Bold="true"></asp:Label>
    <br />
    <asp:TextBox ID="txtBody" runat="server" Text="" Height="349px" Width="692px"></asp:TextBox>
    <br />

    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />
    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" ValidationGroup="update"/>
    <asp:Button ID="Populate" runat="server" Text="Populate" OnClick="Populate_Click"/>
    <asp:Button ID="Commit" runat="server" Text="Commit" OnClick="Commit_Click" />
   <asp:ListBox ID="Users" runat="server" DataSourceID ="srcSTORY" DataTextField ="TextTitle"></asp:ListBox>

    <asp:TextBox ID="Test" runat="server" Text=""></asp:TextBox>
    <asp:ListBox ID="TestUsers" runat="server"></asp:ListBox>
    <asp:SqlDataSource
        id="srcSTORY"
        ConnectionString="Server=Localhost;
        Database=Lab1; Trusted_Connection=Yes;"
        SelectCommand="Select * FROM STORY"
        Runat="server" />
    <br />
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="textDate" ForeColor="Red" Text="Text Date is required" ValidationGroup="update"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="textDate" ForeColor="Red" 
        ValidationExpression="^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$" ErrorMessage="RegularExpressionValidator" Text="Please enter text date in a format of yyyy-mm-dd or yyyy-m-d"
        ValidationGroup="update"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="textTitle" ForeColor="Red" Text="Text Title is required" ValidationGroup="update"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="textSource" ForeColor="Red" Text="Text Source is required" ValidationGroup="update"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="txtBody" ForeColor="Red" Text="Text Body is required" ValidationGroup="update"></asp:RequiredFieldValidator>
    <br />

</asp:Content>
