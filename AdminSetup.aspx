<%@ Page Title="" Language="C#" MasterPageFile="~/RootUserMasterPage.master" AutoEventWireup="true" CodeFile="AdminSetup.aspx.cs" Inherits="AdminSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-md-4 col-lg-4"></div>
            <div class="col-sm-4 col-md-4 col-lg-4 bg-light" style="margin-top: 5%; padding: 3%">
                <h2 class="card-title  " style="text-align: center; padding-bottom: 10px; color: black">Admin registration</h2>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="font-weight-bold" ID="Label3">First Name</asp:Label>
                    <asp:TextBox runat="server" ID="txtfName" Width="100%" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtfName" Text="Enter First Name" SetFocusOnError="True"  ForeColor="red"></asp:RequiredFieldValidator>

                </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="font-weight-bold" ID="Label4">Last Name</asp:Label>
                <asp:TextBox runat="server" ID="txtlname" Width="100%" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtlname" Text="Enter Last Name" SetFocusOnError="True" ForeColor="red"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="font-weight-bold" ID="Label5">Phone No</asp:Label>
                <asp:TextBox runat="server" ID="txtphoneNo" TextMode="Phone" Width="100%" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtphoneNo" Text="Enter Phone No" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" CssClass="float-right" SetFocusOnError="True" ControlToValidate="txtphoneNo" Text="Email is not in valid formate" ForeColor="red" ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"></asp:RegularExpressionValidator>

            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="font-weight-bold" ID="Label6">CNIC No</asp:Label>
                <asp:TextBox runat="server" ID="txtCNIC" TextMode="Number" Width="100%" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCNIC" Text="Enter CNIC No" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtCNIC" CssClass="float-right" SetFocusOnError="True" ValidationExpression="^[0-9]{5}[0-9]{7}[0-9]$" ForeColor="red" ErrorMessage="CNIC not in valid formate" runat="server"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group ">
                <asp:Label runat="server" CssClass="font-weight-bold" ID="lblemail">Email Address</asp:Label>
                <asp:TextBox runat="server" ID="txtemail" TextMode="Email" Width="100%" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtemail_OnTextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail" Text="Enter Email" SetFocusOnError="True" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" CssClass="float-right" ControlToValidate="txtemail" SetFocusOnError="True" Text="Email formate valid" ForeColor="red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               <div><asp:Label runat="server" ForeColor="red" ID="lblemailexixt"></asp:Label></div> 
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="font-weight-bold" ID="Label1">Password</asp:Label>
                <asp:TextBox runat="server" ID="txtpassword" TextMode="Password"  Width="100%" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpassword" Text="Enter Password" SetFocusOnError="True" ForeColor="red"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="font-weight-bold" ID="Label2">Confirm Password</asp:Label>
                <asp:TextBox runat="server" ID="txtconfirmpass" TextMode="Password" Width="100%" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtconfirmpass" Text="Enter Confirm Password" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ControlToValidate="txtconfirmpass" ControlToCompare="txtpassword" SetFocusOnError="True" Text="Password Does not Mach" ForeColor="red"></asp:CompareValidator>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass=" font-weight-bold" ID="Label7">Status</asp:Label>
                <asp:DropDownList runat="server" CssClass="form-control" Width="100%" ID="ddlstatus">
                    <asp:ListItem Value="0" Text="Select Status"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlstatus" InitialValue="0" Text="Select Status" SetFocusOnError="True" ForeColor="red"></asp:RequiredFieldValidator>


            </div>

            <div class="form-group">
                <asp:Button runat="server" ID="btnlogin" CssClass=" col-lg-5 btn btn-primary" Text="Save" OnClick="btnlogin_OnClick"></asp:Button>
                <asp:HyperLink runat="server" ID="hypadminlist" CssClass="col-lg-5 btn btn-primary float-right" NavigateUrl="AdminList.aspx" Text="Admin List"></asp:HyperLink>
                <asp:Label runat="server" ID="lblmsg"></asp:Label>
            </div>
            </div>

        </div>
    </div>

</asp:Content>

