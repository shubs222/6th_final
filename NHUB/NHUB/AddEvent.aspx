<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddEvent.aspx.cs" Inherits="NHUB.AddEvent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="text-center" style="height: 602px; width: 921px; ">

            <div class="text-center">
                `<br />
                <strong>Add an Event</strong><br />
            </div>
            <div class="text-center" style="height: 276px">
                <table class="nav-justified" style="height: 276px">
                    <tr>
                        <td style="width: 360px; height: 40px">Source:</td>
                        <td style="width: 322px; height: 40px" class="text-left">
                            <asp:DropDownList ID="SourceDropList" runat="server" Height="27px" Width="200px" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString2 %>" SelectCommand="SELECT [Id], [Name] FROM [Source]"></asp:SqlDataSource>
                        </td>
                        <td class="text-left" style="height: 40px"></td>
                    </tr>
                    <tr>
                        <td style="width: 360px; height: 39px">Name:</td>
                        <td style="width: 322px; height: 39px" class="text-left">
                            <asp:TextBox ID="NameTextBox" runat="server" Width="202px" Height="20px"></asp:TextBox>
                        </td>
                        <td class="text-left" style="height: 39px">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 360px; height: 66px">Available Channels:</td>
                        <td style="width: 322px; height: 66px" class="text-left">
                            <asp:CheckBoxList ID="ChannelCheckBoxList" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id" Height="61px" Width="253px">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [Channel]"></asp:SqlDataSource>
                        </td>
                        <td class="text-left" style="height: 66px"></td>
                    </tr>
                    <tr>
                        <td style="width: 360px">Confidential Event:</td>
                        <td style="width: 322px" class="text-left">
                            <asp:CheckBox ID="ConfidentialEventCheckBox" runat="server" />
                        </td>
                        <td class="text-left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 360px">Mandetory Event:</td>
                        <td style="width: 322px" class="text-left">
                            <asp:CheckBox ID="MandetoryEventCheckBox" runat="server" />
                        </td>
                        <td class="text-left">&nbsp;</td>
                    </tr>
                    
                </table>
                <br/>
                <br />
                <% if (Context.User.IsInRole("Service Line Manager"))
                    {%>
                <%} %>
                <br/>
                <br />
                <table style="width: 922px; margin-bottom: 0px">
                    <tr>
                        <td class="text-right" style="width: 379px">
                            <asp:Button ID="CancelButton" runat="server" Height="42px" OnClick="CancelButton_Click1" Text="Cancel" Width="92px" />
                        </td>
                        <td>
                            <asp:Button ID="AddButton" runat="server" Height="36px" OnClick="AddButton_Click1" Text="Add" Width="88px" />
                        </td>
                    </tr>
                </table>
            </div>

           </div>

</asp:Content>