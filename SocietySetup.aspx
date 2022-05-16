<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SocietySetup.aspx.cs" Inherits="SocietySetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="container  badge-light">
        <h3>Society Setup</h3>

        <div class="row">
            <div class=" col-md-4 col-lg-4"></div>
            <div class=" col-md-4 col-lg-4">
                <div class="col-lg-12">
                    <div class="form-group">
                        <label>Society Name</label>
                        <asp:TextBox runat="server" ID="txtSName" CssClass="form-control" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvsname" SetFocusOnError="True" ControlToValidate="txtSName" ErrorMessage="Enter the Socity Name" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label>Total Houses No</label>
                        <asp:TextBox runat="server" ID="txtTotalHouses" TextMode="Number" CssClass="form-control" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtTotalHouses" ErrorMessage="Enter total no of houses" ForeColor="red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" ID="cvhouseNo" SetFocusOnError="True" ControlToValidate="txtTotalHouses" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="1" ErrorMessage="0 house is Not Valid " ForeColor="red"></asp:CompareValidator>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label>City Name</label>
                        <asp:DropDownList runat="server" ID="ddlcityName" CssClass="form-control" Width="250px"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvddlcity" SetFocusOnError="True" InitialValue="1" ControlToValidate="ddlcityName" ErrorMessage="Select City" ForeColor="red"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label>Address</label>
                        <asp:TextBox runat="server" ID="txtaddress" TextMode="MultiLine" CssClass="form-control" Width="250px"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="form-control btn btn-primary" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:HyperLink runat="server" ID="lbtnList" Text="Society List" CssClass="form-control btn btn-primary " NavigateUrl="SocietyList.aspx"></asp:HyperLink>
                    </div>
                    <label runat="server" id="lblmsg"></label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

