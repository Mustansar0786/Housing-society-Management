<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">
   <div class="container-fluid bg-light">   
       <div align="center">
       
        <label class="font-weight-bold h1 align-content-center justify-content-center"  >Welcome To Housing Society Management</label>
       <asp:Image  runat="server" ImageUrl="imges/Home Image.jpg"  ImageAlign="Middle" Width="50%"/>
   </div>
   </div>

</asp:content>

