<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="HouseTypeList.aspx.cs" Inherits="HouseTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    
    <div class="container badge-light"  style="margin-top: 10px">
        <div>
            <a href="HouseTypeSetup.aspx" id="hyrf" class="btn btn-primary">Add New House Type</a>
        </div>
        <asp:GridView runat="server" ID="GV_HouseType" AutoGenerateColumns="False" CssClass="  table table-hover "  OnRowCommand="GV_HouseType_OnRowCommand" OnRowDeleting="GV_HouseType_OnRowDeleting" OnRowEditing="GV_HouseType_OnRowEditing">
            <Columns>
                <asp:BoundField DataField="HouseTypeName"  HeaderText="House Type"/>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnedit" Text="Edit" CssClass="btn btn-primary" CommandName="edit"
                                        CommandArgument='<%#Eval("HouseTypeId") %>'/>
                                    
                        <asp:LinkButton runat="server" ID="btndelele" Text="Delete" OnClientClick="return confirm('Are you want to delete?');" CssClass="btn btn-primary" CommandName="delete"
                                        CommandArgument='<%#Eval("HouseTypeId") %>'/>
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>

