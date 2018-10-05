<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Subscribe.aspx.cs" Inherits="NHUB.Subscribe" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    





        <div style="height: 510px">


            <div style="position: relative; left: 0px; top: 0px; height: 503px">
                <br />
                <table class="nav-justified" style="height: 422px">
                    <tr>
                        <td class="text-center" style="width: 425px">Name:</td>
                        <td>
                            <asp:TextBox ID="EventName" runat="server" Enabled="False" Height="30px" Width="236px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 425px; height: 58px">Available Channels:</td>
                        <td style="height: 58px">
                            <asp:CheckBox EnableViewState="false" ID="IntranetCheck" runat="server" Text="Intranet" />
&nbsp;&nbsp;
                            <asp:CheckBox EnableViewState="false"  ID="EmailCheckbox" runat="server" Text="Emails" />
                            <br />
                            <asp:CheckBox  ID="UnabotCheckBox" runat="server" Text="Una Bot" />
&nbsp;&nbsp;
                            <asp:CheckBox ID="SmsCheckBox"  runat="server" Text="SMS" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 425px">Confidential Events:</td>
                        <td>
                            <asp:CheckBox  ID="ConfCheck" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 425px">Mandetory Events: </td>
                        <td>
                            <asp:CheckBox  ID="MandCheck" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 425px">Service LIne:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [ServiceLine]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 425px">End User:</td>
                        
                                     <script type="text/javascript">
                                 $(function () {
            $('#UserListBox').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>  

                        <td>&nbsp;<asp:ListBox ID="UserListBox" runat="server" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                            &nbsp;Press Ctrl and select multiple users&nbsp;
                            <asp:PlaceHolder ID="SelectedPeopleList" runat="server"></asp:PlaceHolder>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NotificationHubConnectionString %>" SelectCommand="SELECT [Id], [UserName] FROM [AspNetUsers]"></asp:SqlDataSource>
                            <br />
                            <asp:Button ID="Adduser" runat="server" OnClick="Adduser_Click1" Text="AddUser" />
                            &nbsp;
                            <asp:Button ID="RemoveButton" runat="server" OnClick="RemoveButton_Click" Text="Remove" />
                            <br />
&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="width: 425px">
                            <asp:Button ID="CancleButton"  runat="server" Height="32px" OnClick="CancleButton_Click" Text="Cancel" Width="74px" />
                        </td>
                        <td>
                            <asp:Button ID="UpdateButton"  runat="server" Height="31px" OnClick="UpdateButton_Click" Text="Update" Width="88px" />
                        </td>
                    </tr>
                </table>
            </div>


        </div>

    </asp:Content>