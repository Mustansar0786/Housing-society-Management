<%@ Page Title="" Language="C#" MasterPageFile="~/RootUserMasterPage.master" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="AdminList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <div class=" container badge-light" style="margin-top: 1%">

        <asp:HyperLink runat="server" ID="hypAddAdmin" CssClass="btn btn-primary" NavigateUrl="AdminSetup.aspx" Text="Add Admin" />
        
        <asp:DropDownList runat="server" ID="ddlStatus" CssClass="float-right btn btn-primary" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged" AutoPostBack="True"  >
            <asp:ListItem Value="0" Text="All"></asp:ListItem>
            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
            <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>

        </asp:DropDownList>
        <label class="float-right h4" style="margin-right: 10px"> List Admin  </label>
        <asp:GridView runat="server" ID="GV_AdminList" CssClass="table table-hover" AutoGenerateColumns="False" OnRowCommand="GV_AdminList_OnRowCommand"  OnRowEditing="GV_AdminList_OnRowEditing" OnRowDeleting="GV_AdminList_OnRowDeleting">
            <Columns>
                <asp:BoundField HeaderText="First Name" DataField="AFirstName" />
                <asp:BoundField HeaderText="Last Name" DataField="ALastName" />
                <asp:BoundField HeaderText="Phone No" DataField="APhoneNo" />
                <asp:BoundField HeaderText="CNIC No" DataField="ANationalId" />
                <asp:BoundField HeaderText="Email" DataField="AEmailAdresss" />
                <asp:BoundField HeaderText="Status" DataField="Astatus" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnedit" Text="Edit" CssClass="btn btn-primary" CommandName="edit"
                                        CommandArgument='<%#Eval("adminId") %>' />
                        <asp:LinkButton runat="server" ID="btndelele" Text="Delete" OnClientClick="return confirm('Are you want to delete?');" CssClass="btn btn-primary" CommandName="delete"
                                        CommandArgument='<%#Eval("adminId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>


    

</asp:Content>

