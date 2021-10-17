<%@ Page Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="Lab2.CreateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <asp:Label ID="lblCreateProfile" runat="server" Text="Create Profile" Font-Bold="true" Font-Size="Larger" ForeColor="Blue"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblOrgID" runat="server" Text="Select OrgID 1-5:" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="OrgId1" runat="server" Text="" Font-Bold="true"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="FirstName" runat="server" Text="First Name" Font-Bold="true"></asp:Label>
    :
    <asp:TextBox ID="FName" runat="server" Text="" Height="21px" Width="134px"></asp:TextBox>
    <asp:Label ID="LastName" runat="server" Text="Last Name" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="LName" runat="server" Text="" Width="168px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email Address" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="Email" runat="server" Text="" Width="234px"></asp:TextBox>
    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="Phone" runat="server" Text="" Height="23px" Width="185px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="SAddress" runat="server" Text="Street Address" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="Street" runat="server" Text="" Height="26px"></asp:TextBox>
    <asp:Label ID="lblCity" runat="server" Text="City" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="City" runat="server" Text="" Height="25px" Width="167px"></asp:TextBox>
    <asp:Label ID="lblState" runat="server" Text="State" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="State" runat="server" Text="" Height="27px"></asp:TextBox>
    <asp:Label ID="lblZip" runat="server" Text="ZipCode" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="Zip" runat="server" Text="" Height="30px"></asp:TextBox>

    <br />
    <br />
    <br />
   <asp:Label ID="lblDescription" runat="server" Text="Description" Font-Bold="true"></asp:Label>
    <br />
    &nbsp;<asp:TextBox ID="Description" runat="server" Text="" Height="125px" Width="425px"></asp:TextBox>
    &nbsp;<br />
    &nbsp;<br />
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />
    <asp:Button ID="Populate" runat="server" Text="Populate" OnClick="Populate_Click" />
    <asp:Button ID="Save" runat="server" Text="Save" OnClick ="Save_Click" ValidationGroup="update,commit,create" />
    <asp:Button ID="Commit" runat="server" Text="Commit" OnClick="Commit_Click" />
    <asp:ListBox ID="Users" runat="server" DataSourceID ="srcUSERS" DataTextField ="FirstName"></asp:ListBox>
    <asp:TextBox ID="Test" runat="server" Text =""></asp:TextBox>
    <asp:ListBox ID="TestUsers" runat="server"></asp:ListBox>
    <asp:SqlDataSource
        id="srcUSERS"
        ConnectionString="Server=Localhost;
        Database=Lab1; Trusted_Connection=Yes;"
        SelectCommand=""
        Runat="server" />
    <br />    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="OrgId1" ForeColor="Red" Text="Organization ID is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br /> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="OrgId1" ForeColor="Red" 
        ValidationExpression="^[0-9]$" ErrorMessage="RegularExpressionValidator" Text="Organization ID must contain numbers!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />


    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="FName" ForeColor="Red" Text="First name is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FName" ForeColor="Red" 
        ValidationExpression="^[A-Z][a-zA-Z]*$" ErrorMessage="RegularExpressionValidator" Text="First name must contain letters starting with a capital letter!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />


    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="LName" ForeColor="Red" Text="Last name is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="LName" ForeColor="Red" 
        ValidationExpression="^[A-Z][a-zA-Z]*$" ErrorMessage="RegularExpressionValidator" Text="Last name must contain letters starting with a capital letter!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />



    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="Email" ForeColor="Red" Text="Email Address is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Email" ForeColor="Red" 
        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="RegularExpressionValidator" Text="Please enter a valid Email Address!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Phone" ForeColor="Red" 
        ValidationExpression="^\(\d{3}\) \d{3}-\d{4}$" ErrorMessage="RegularExpressionValidator" Text="Please enter a valid Phone number in the format of (xxx) xxx-xxxx"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />


    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="Street" ForeColor="Red" Text="Street Address is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />


    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="City" ForeColor="Red" Text="City is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="City" ForeColor="Red" 
        ValidationExpression="^[A-Z][a-zA-Z]*$" ErrorMessage="RegularExpressionValidator" Text="City must contain letters starting with a capital letter!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="State" ForeColor="Red" Text="State is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="State" ForeColor="Red" 
        ValidationExpression="^[A-Z][a-zA-Z]*$" ErrorMessage="RegularExpressionValidator" Text="State must contain letters starting with a capital letter!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator"
        ControlToValidate="Zip" ForeColor="Red" Text="ZipCode is required" ValidationGroup="update,commit,create"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Zip" ForeColor="Red" 
        ValidationExpression="^[0-9]{5,5}$" ErrorMessage="RegularExpressionValidator" Text="ZipCode can contain only 5 digit numbers!"
        ValidationGroup="update,commit,create"></asp:RegularExpressionValidator>
    <br />
    <br />

    <br />
    <br />






   
</asp:Content>
