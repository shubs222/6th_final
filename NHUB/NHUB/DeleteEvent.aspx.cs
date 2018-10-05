using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;
namespace NHUB
{
    public partial class DeleteEvent : System.Web.UI.Page
    {
        AddNotificationRepository addNotificationRepository = new AddNotificationRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(Request.QueryString["id"]);
            addNotificationRepository.DeleteData(a);
            Response.Redirect("Notifications.aspx");

        }
    }
}