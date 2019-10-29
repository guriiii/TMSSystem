<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TMSTeam.aspx.cs" Inherits="TMSSystem.TMSTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 25px;">

        <div class=" col-md-6">
            <div class="form-group">
                <label for="exampleInputCoach">Coach <span style="color: red;">*</span></label>
                <asp:DropDownList ID="CoachID" AppendDataBoundItems="true" class="form-control" runat="server">
                    <asp:ListItem>------ Choose Coach ------</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" runat="server" ControlToValidate="CoachID" ErrorMessage="Please choose coach " ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class=" col-md-6">
            <div class="form-group">
                <label for="txtTeamName">Team Name:</label>
                <asp:TextBox ID="txtTeamName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="submit" ControlToValidate="txtTeamName" runat="server" ErrorMessage="Please enter team name"></asp:RequiredFieldValidator>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </div>

        <div class=" col-md-6">
            <div class="form-group">
                <label for="State">State:</label>
                <asp:TextBox ID="State" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="submit" ControlToValidate="State" runat="server" ErrorMessage="Please enter state"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class=" col-md-6">
            <div class="form-group">
                <label for="City">City:</label>
                <asp:TextBox ID="City" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="submit" ControlToValidate="City" runat="server" ErrorMessage="Please enter city"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
    </div>
    <asp:Button ID="btnSave" ValidationGroup="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />
    <asp:Button ID="BtnDelete" runat="server" Text="Reset" class="btn btn-info" OnClick="BtnReset_Click" />
    <br />
    <br />
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
                            Team Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("TeamName") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CoachName" HeaderText="Coach Name" />
                    <asp:BoundField DataField="State" HeaderText="State" />
                    <asp:BoundField DataField="City" HeaderText="City" />
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
