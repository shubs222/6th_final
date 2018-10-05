<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditEvent.aspx.cs" Inherits="NHUB.EditEvent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div style="height: 434px">
            <br />
            <br />
            <table class="nav-justified" style="height: 188px" align="center">
                <tr>
                    <td class="text-center" style="width: 339px">Source:</td>
                    <td style="width: 301px" class="modal-sm">
                        <asp:DropDownList ID="SourceList" runat="server" Height="37px" Width="200px" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString2 %>" SelectCommand="SELECT [Id], [Name] FROM [Source]"></asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 339px; height: 39px">Name:</td>
                    <td style="height: 39px; width: 301px;">
                        <asp:TextBox ID="NameTextBox" runat="server" Height="22px" Width="200px"></asp:TextBox>
                    </td>
                    <td style="height: 39px">
                        <asp:Label ID="Status" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 339px; height: 59px">Available Channels</td>
                    <td style="height: 59px; width: 301px;">
                        <asp:CheckBox ID="Intranet" AutoPostBack="true" runat="server" CausesValidation="True" Text="Intranet" />
                        &nbsp;
                        <asp:CheckBox ID="EmailsCheckBox" AutoPostBack="true" runat="server" Text="Emails" />
                        <br />
                        <asp:CheckBox ID="UnaBotCheckBox" AutoPostBack="true" runat="server" Text="Una Bot" />
                        &nbsp;
                        <asp:CheckBox ID="SmsCheckBox" AutoPostBack="true" runat="server" Text="SMS" />
                    </td>
                    <td style="height: 59px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 339px; height: 29px;">Confidential Event
                    <td style="height: 29px; width: 301px">
                        <asp:CheckBox ID="ConfidentialCheckBox" runat="server" />
                    </td>
                    <td style="height: 29px"></td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 339px">Mandetory Event</td>
                    <td style="width: 301px" class="modal-sm">
                        <asp:CheckBox ID="MandetoryCheckBox" runat="server" OnCheckedChanged="MandetoryCheckBox_CheckedChanged" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
          
              
                <table class="nav-justified" style="height: 118px">
                    <tr>
                        <td class="text-center" style="width: 315px">Dynamic Fields:</td>
                        <td style="width: 222px">&nbsp;</td>
                        <td style="width: 187px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 315px">&nbsp;</td>
                        <td style="width: 222px">SourceField</td>
                        <td style="width: 187px">Type</td>
                        <td>Unique Alias</td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 315px">1.</td>
                        <td style="width: 222px">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 187px">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Width="133px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 315px">2.</td>
                        <td style="width: 222px">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 187px">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Width="133px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
              
            
            <table align="center" class="nav-justified" style="height: 41px; width: 89%; position: relative; left: 0px; top: 50px;">
                <tr>
                    <td class="text-center" style="width: 434px">
                        <asp:Button ID="CancelButton" runat="server" Height="31px" Text="Cancel" Width="89px" OnClick="CancelButton_Click" />
                    </td>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>