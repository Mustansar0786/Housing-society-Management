<%@ Page Title="" Language="C#" MasterPageFile="~/RegistrationMasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="container">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 bg-light" style="margin-top: 3%; padding: 2%">
                <h2 class="card-title " style="text-align: center"> Admin Login</h2>
                <div class="form-group ">
                    <asp:Label runat="server" CssClass="font-weight-bold" ID="lblemail">Email Address</asp:Label>
                    <asp:TextBox runat="server"  ID="txtemail" TextMode="Email" Width="100%"  CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail" SetFocusOnError="True" Text="Enter Email Address" ForeColor="red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtemail" SetFocusOnError="True" Text="Email not valid" ForeColor="red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="font-weight-bold" ID="Label1">Password</asp:Label>
                    <asp:TextBox runat="server"  ID="txtpassword" TextMode="Password" Width="100%" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpassword" SetFocusOnError="True" ErrorMessage="Enter Password" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:CheckBox runat="server" ID="chkremember" Text="Remember me"/>
                   <asp:HyperLink runat="server" CssClass="float-right" ID="lbtnReset" NavigateUrl="ResetPassword.aspx" Text="Forgot Password?"></asp:HyperLink>
                    </div>
                <div class="form-group">
                    <asp:Button runat="server"   ID="btnlogin" CssClass="btn btn-primary" Width="100%" Text="Login" OnClick="btnlogin_OnClick"></asp:Button>
                    <asp:Label runat="server" CssClass="text-danger" ID="lblmsg"></asp:Label>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

