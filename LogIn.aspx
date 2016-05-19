<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjMaster.master" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>
<%@ MasterType VirtualPath ="~/ProjMaster.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblUserId" runat="server" Text="Username"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUserID" runat="server" ToolTip="Enter your username"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblPassword" runat="server" Text="Password:">
</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
        ToolTip="Enter your password"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCreateAcc" runat="server" 
        Text="Create Account" Height="25px" onclick="btnCreateAcc_Click" 
        PostBackUrl="~/AccDetails.aspx" 
        ToolTip="Create an account if no credentials" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnLogin" 
        runat="server" Text="Login" 
        OnClick="btnLogin_Click" PostBackUrl="~/AccDetails.aspx" 
        ToolTip="Enter your credentials, then login" />
        <br />
    <br />
        <br />
            <asp:Label ID="Label2" runat="server" 
                Text="Username: LakersGuy12 Password: password"></asp:Label>
    
    <p>
        <asp:Label ID="Label3" runat="server" 
            Text="Username 2: LakersGirl13 Password: Password"></asp:Label>
    </p>
</asp:Content>
