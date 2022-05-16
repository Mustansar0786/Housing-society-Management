<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SocietyList.aspx.cs" Inherits="SocieryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <div class="container badge-light"  style="margin-top: 10px">
        <div >
            <a href="SocietySetup.aspx" id="hyrf" class="btn btn-primary">New Society</a>
            <label runat="server" class="font-weight-bolder text-danger" ID="lblfordelete"></label>
        </div>
        <asp:GridView runat="server" ID="gv_Houses" AutoGenerateColumns="False" CssClass="table-responsive-sm table table-hover "  OnRowCommand="gv_OnRowCommand" OnRowDeleting="gv_OnRowDeleting" OnRowEditing="gv_OnRowEditing">
            <Columns>
                <asp:BoundField DataField="HouseNo" HeaderText="House No"/>
                <asp:BoundField DataField="NoOfStory" HeaderText="No of Story"/>
                <asp:BoundField DataField="Housedetial" HeaderText="Detail"/>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnedit" Text="Edit" CssClass=" btn btn-primary" CommandName="edit"
                                        CommandArgument='<%#Eval("HouseId") %>'/>
                                    
                        <asp:LinkButton runat="server" ID="btndelele" Text="Delete" OnClientClick="return confirm('Are you want to delete?');" CssClass=" btn btn-primary" CommandName="delete"
                                        CommandArgument='<%#Eval("HouseId") %>'/>
                        
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    

</asp:Content>

