using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;

namespace NHUB
{
    public partial class AddEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CancelButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Notification.aspx");
        }

        protected void AddButton_Click1(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                Label1.Text = "Please Enter Name";
            }
            else
            {
                AddNotificationRepository addNotificationRepository = new AddNotificationRepository();
                int Eid;
                
                Eid = addNotificationRepository.InsertEvent(NameTextBox.Text, Convert.ToInt32(SourceDropList.SelectedValue),ConfidentialEventCheckBox.Checked,MandetoryEventCheckBox.Checked);

                for (int Count = 0; Count < 4; Count++)
                {
                    if (ChannelCheckBoxList.Items[Count].Selected)
                    {
                        addNotificationRepository.InsertEventChannel(Eid, Convert.ToInt32(ChannelCheckBoxList.Items[Count].Value));
                    }
                }
                Response.Redirect("Notifications.aspx");
               
            }
            
        }
    }
}
        
            
    
 

