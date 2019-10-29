<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TMSPlayer.aspx.cs" Inherits="TMSSystem.TMSPlayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 25px;">
            <div class=" col-md-6">
                <div class="form-group">
                    <label for="exampleInputTeam">Team <span style="color: red;">*</span></label>
                    <asp:DropDownList ID="TeamID" AppendDataBoundItems="true" class="form-control" runat="server">
                        <asp:ListItem>------ Choose Team ------</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" runat="server" ControlToValidate="TeamID" ErrorMessage="Please choose coach " ForeColor="#993333"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class=" col-md-6">
                <div class="form-group">
                    <label for="txtName">Name:</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="submit" ControlToValidate="txtName" runat="server" ErrorMessage="Please enter team name"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
            <div class=" col-md-6">
                <div class="form-group">
                    <label for="exampleInputGender">Gender</label>
                    <asp:DropDownList ID="GenderList" class="form-control" runat="server">
                        <asp:ListItem>------ Choose Gender ------</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Save" ControlToValidate="GenderList" ErrorMessage="Please enter gender" ForeColor="#993333"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class=" col-md-6">
                <div class="form-group">
                    <label for="Position">Position:</label>
                    <asp:TextBox ID="Position" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="submit" ControlToValidate="Position" runat="server" ErrorMessage="Please enter state"></asp:RequiredFieldValidator>
                </div>
            </div>
        <br />
        <asp:Button ID="btnSave" ValidationGroup="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Reset" class="btn btn-info" OnClick="BtnReset_Click" />
        <br />
        <br />
    </div>
    <div class="box-body">
        <div id="datatable-responsive_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
            <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover"
                AutoGenerateColumns="false" EmptyDataText="No Record Found" DataKeyNames="ID"
                AllowPaging="false" PageSize="10" OnRowCommand="grd_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Player Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("Name") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TeamName" HeaderText="Team Name" />
                    <asp:BoundField DataField="Position" HeaderText="Position" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="butEnable" runat="server" class="btn btn-info btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
