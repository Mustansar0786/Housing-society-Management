<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid border-bottom">
            <div class="row">
                <div class="col-lg-3 ">
                    <asp:Image runat="server" ImageUrl="imges/Brand_logo.jpg" CssClass="" AlternateText="Brand logo" Height="130px" />

                </div>
                <div class="col-lg-8">
                    <label class="h1" style="margin-top: 40px">
                        Society Management System
                        <label class="h3">(BSITF17M026)</label></label>
                </div>

            </div>
        </div>
        <div>



            <div class="container">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4 bg-light" style="margin-top: 1%; padding: 2%">
                        <h2 class="card-title " style="text-align: center">Password Reset </h2>
                        
                        <div class="form-group ">
                            <asp:Label runat="server" CssClass="font-weight-bold" ID="Label2">Email Address</asp:Label>
                            <asp:TextBox runat="server"  ID="txtemail" TextMode="Email" Width="100%"  CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail" SetFocusOnError="True" Text="Enter Email Address" ForeColor="red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtemail" SetFocusOnError="True" Text="Email formate is invalid " ForeColor="red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                        </div>
                        
                        <div class="form-group ">
                            <asp:Label runat="server" CssClass="font-weight-bold" ID="lblemail"> Password</asp:Label>
                            <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" Width="100%" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpassword" SetFocusOnError="True" Text="Enter Password  " ForeColor="red"></asp:RequiredFieldValidator>
                            
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="font-weight-bold" ID="Label1">Confirm Password</asp:Label>
                            <asp:TextBox runat="server" ID="txtconfirmpassword" TextMode="Password" Width="100%" CssClass="form-control"></asp:TextBox>
                            <asp:CompareValidator runat="server" ControlToValidate="txtconfirmpassword" SetFocusOnError="True" ControlToCompare="txtpassword"  Text="Password does not match" ForeColor="red"></asp:CompareValidator>
                            
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnReset" CssClass="btn btn-primary" OnClick="btnReset_OnClick" Width="100%" Text="Reset" ></asp:Button>
                            <asp:Label runat="server" ForeColor="red" ID="lblmsg"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>



            <div class="col-lg-12">
                <footer class="border-top">
                    <h5>&copy;2021 Society Management System. All Right Reserved to Mustansar Hussain (BSITF17M026)</h5>
                </footer>
            </div>

        </div>
    </form>
</body>
</html>
