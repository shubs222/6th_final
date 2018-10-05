using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;
using System.Data;

namespace NHUB
{
    public partial class EditEvent : System.Web.UI.Page
    {
        AddNotificationRepository addNotificationRepository = new AddNotificationRepository();
        NotificationsRepository ns = new NotificationsRepository();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            //ns.getDetails();
            //SourceList.SelectedValue = ns.SourceList;
            if (!Page.IsPostBack)
            {
                DataTable tb = addNotificationRepository.GetEventData(0).Tables[0];
                DataRow dr = tb.Select("Id = " + id)[0];
                NameTextBox.Text = dr[1].ToString();
                MandetoryCheckBox.Checked = Convert.ToBoolean(dr[3]);
                ConfidentialCheckBox.Checked = Convert.ToBoolean(dr[4]);
              
                SourceList.SelectedValue = dr[2].ToString();
                SourceList.Enabled = false;

                DataTable tb1 = addNotificationRepository.EventChannelGetData(id).Tables[0];
                for (int count = 0; count < tb1.Rows.Count; count++)
                {
                    //    if(tb1.Rows[count])
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 1)
                    {
                        Intranet.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 2)
                    {
                        EmailsCheckBox.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 3)
                    {
                        UnaBotCheckBox.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 4)
                    {
                        SmsCheckBox.Checked = true;
                    }

                }
            }

        }

        protected void MandetoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                Status.Text = "Please Enter Name";
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                addNotificationRepository.UpdateEventData(id, NameTextBox.Text,MandetoryCheckBox.Checked,ConfidentialCheckBox.Checked);
                addNotificationRepository.DeleteChannel(id);

                if (Intranet.Checked)
                {
                    addNotificationRepository.InsertEventChannel(id, 1);
                }
                if (EmailsCheckBox.Checked)
                {
                    addNotificationRepository.InsertEventChannel(id, 2);
                }
                if (UnaBotCheckBox.Checked)
                {
                    addNotificationRepository.InsertEventChannel(id, 3);
                }
                if (SmsCheckBox.Checked)
                {
                    addNotificationRepository.InsertEventChannel(id, 4);
                }

                Response.Redirect("Notifications.aspx");
            }
            
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications.aspx");
        }
    }
}