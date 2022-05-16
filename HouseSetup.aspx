<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="HouseSetup.aspx.cs" Inherits="SocietySetup" %>

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
                        <label> Society Name</label>
                        <asp:DropDownList runat="server" ID="ddlSocietyName" CssClass="form-control" Width="250px"/> 
                        <asp:RequiredFieldValidator runat="server"  SetFocusOnError="True" InitialValue="1" ControlToValidate="ddlSocietyName" ErrorMessage="Select City" ForeColor="red"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label>House No</label>
                        <asp:TextBox runat="server" ID="txtHouseNo" TextMode="Number" CssClass="form-control" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtHouseNo" ErrorMessage="Enter total no of houses" ForeColor="red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" ID="cvhouseNo" SetFocusOnError="True" ControlToValidate="txtHouseNo" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="1" ErrorMessage="0 house is Not Valid " ForeColor="red"></asp:CompareValidator>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label> No of Story</label>
                        <asp:DropDownList runat="server" ID="ddlStoryNo" CssClass="form-control" Width="250px">
                            <asp:ListItem value="0" text="select"/>
                            <asp:ListItem value="1" text="1"/>
                            <asp:ListItem value="2" text="2"/>
                            <asp:ListItem value="3" text="3"/>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvddlcity" SetFocusOnError="True" InitialValue="1" ControlToValidate="ddlcityName" ErrorMessage="Select City" ForeColor="red"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label><Details></Details></label>
                        <asp:TextBox runat="server" ID="txtdetail" TextMode="MultiLine" CssClass="form-control" Width="250px"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="form-control btn btn-primary" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:HyperLink runat="server" ID="lbtnList" Text="Houses List" CssClass="form-control btn btn-primary " NavigateUrl="HouseList.aspx"></asp:HyperLink>
                    </div>
                    <label runat="server" id="lblmsg">Sir two days ago, my hard disk demaged.i have to buy it new and whole earler project was lost. i write this code in simple test editor.  </label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

