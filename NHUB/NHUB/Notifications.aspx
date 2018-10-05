<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Notifications.aspx.cs" Inherits="NHUB.Notifications" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
        <div class="auto-style1" style="height: 100%; z-index: 1; width: 100%; position: relative; top: 22px; left: -5px; text-align: right;">
            <h1 class="text-left">Notifications:</h1>
            <p class="text-left">
               <asp:PlaceHolder ID="NotificationPlaceHolder" runat="server"></asp:PlaceHolder>
            </p>

          
             <br />

       <asp:Button ID="AddNotificationButton" runat="server" style="margin-top: 0;" Text="Add Notification" OnClick="AddNotificationButton_Click" Height="58px" BackColor="Blue" BorderStyle="Ridge" ForeColor="White" />
    </div>
</asp:Content>