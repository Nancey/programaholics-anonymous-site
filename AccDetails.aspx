
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjMaster.master" CodeFile="AccDetails.aspx.cs" Inherits="AccDetails" %>

<%@ MasterType VirtualPath ="~/ProjMaster.master" %>


    <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1> User Account Details</h1>
        <p> 
            <asp:Label ID="Label2" runat="server" 
                Text="Username: LakersGuy12 Password: password"></asp:Label>
        </p>
        <p> 
            <asp:Label ID="Label3" runat="server" 
                Text="Username 2: LakersGirl13 Password: Password"></asp:Label>
        </p>
   <asp:Label ID="lblUsername" runat="server" Text="User Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
        <br />        
        <br />
        <asp:Label ID="lblFavLang" runat="server" Text="Favorite Programming Language:"></asp:Label>
&nbsp;<br />
        <br />
        <asp:TextBox ID="txtFavLang" runat="server" 
            ontextchanged="txtFavLang_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblWorstLang" runat="server" Text="Worst Programming Langage:"></asp:Label>
&nbsp;<br />
        <br />
        <asp:TextBox ID="txtWorstLang" runat="server"></asp:TextBox>
        <br />
        <br />
        </asp:Content>

<asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <br />
        <br />
        <asp:Label ID="lblLastProgram" runat="server" Text="Last program completed:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtLastProgram" runat="server" Width="207px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblAppCompleted" runat="server" Text="Applications Completed:"></asp:Label>
        <br />
        <br />
            <asp:GridView ID="gvApps" runat="server">
            </asp:GridView>
             <br />
           
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnUpdate" runat="server" 
            Text="Update Account" onclick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnFind" 
            runat="server" onclick="btnFind_Click" Text="Find Username" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Account" Width="101px" />
         </asp:Content>
