<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjMaster.master" CodeFile="AccConfirmation.aspx.cs" Inherits="AccConfirmation" %>
<%@ PreviousPageType VirtualPath="~/AccDetails.aspx" %>
<%@ MasterType VirtualPath ="~/ProjMaster.master" %>

 <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>User Confirmation</h1>
        <asp:Label ID="lblUsername" runat="server" Text="User Name:"></asp:Label>
&nbsp;<asp:Label ID="lblName" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAddress2" runat="server" Text="Address: "></asp:Label>
        <asp:Label ID="lblAddress" runat="server"></asp:Label>
        <br />
        <br />
         </asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <asp:Label ID="lblFavLang2" runat="server" Text="Favorite Language:"></asp:Label>
&nbsp;<asp:Label ID="lblFavLang" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblWorstLang2" runat="server" Text="Worst Language:"></asp:Label>
&nbsp;<asp:Label ID="lblWorstLang" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblLastProgram2" runat="server" Text="Last program completed:"></asp:Label>
&nbsp;<asp:Label ID="lblLastProgram" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Update" />
        <br />
     </asp:Content>
