<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="HouseTypeSetup.aspx.cs" Inherits="HouseTypeSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="container  badge-light">
        <h3>House Type </h3>

        <div class="row">
            <div class="col-md-4 col-lg-4"></div>
            <div class="col-md-4 col-lg-4">
                <div class="form-group">
                    <label>HouseType Name (BHK)</label>
                    <asp:TextBox runat="server" ID="txthtypeName" CssClass="form-control" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvsname" ControlToValidate="txthtypeName" SetFocusOnError="True" ErrorMessage="Enter the House Type (BHK)" ForeColor="red"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Button runat="server" ID="btnsave" OnClick="btnsave_OnClick" CssClass="btn btn-primary" Text="Save" />
                    <asp:HyperLink runat="server" ID="lbtnList" Text="House Type List" CssClass="form-control btn btn-primary " NavigateUrl="HouseTypeList.aspx"></asp:HyperLink>
                </div>
                <label runat="server" id="lblmsg"></label>
            </div>


        </div>
    </div>


</asp:Content>

