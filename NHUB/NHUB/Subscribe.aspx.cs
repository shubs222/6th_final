using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;
using System.Data;
using Microsoft.AspNet.Identity;

namespace NHUB
{
    public partial class Subscribe : System.Web.UI.Page
    {
        AddNotificationRepository addNotificationRepository = new AddNotificationRepository();
        ListBox list;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            int qstring = Convert.ToInt32(Request.QueryString["Id"]);

            DataTable tb = addNotificationRepository.GetEventData(0).Tables[0];
            DataRow dr = tb.Select("Id = " + qstring)[0];

            EventName.Text = dr[1].ToString();
            ConfCheck.Enabled = false;
            MandCheck.Enabled = false;
            if (dr[4].ToString() == "True")
            {
                ConfCheck.Enabled = true;
                ConfCheck.Checked = true;
            }
            if (dr[3].ToString() == "True")
            {
                MandCheck.Enabled = true;
                MandCheck.Checked = true;
            }

            DataTable tb1 = addNotificationRepository.EventChannelGetData(qstring).Tables[0];
            IntranetCheck.Enabled = false;
            SmsCheckBox.Enabled = false;
            UnabotCheckBox.Enabled = false;
            EmailCheckbox.Enabled = false;
            if (!IsPostBack)
            {
                

                for (int count = 0; count < tb1.Rows.Count; count++)
                {
                    //    if(tb1.Rows[count])
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 1)
                    {
                        IntranetCheck.Enabled = true;
                        IntranetCheck.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 2)
                    {
                        EmailCheckbox.Enabled = true;
                        EmailCheckbox.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 3)
                    {
                        UnabotCheckBox.Enabled = true;
                        UnabotCheckBox.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 4)
                    {
                        SmsCheckBox.Enabled = true;
                        SmsCheckBox.Checked = true;
                    }

                }
            }
            DataTable SelectPeople = addNotificationRepository.GetData("select UserName from AspNetUsers where Id = any (select distinct(essu.UserId) from Event_slm_subscribe ess, Event_slm_subscribe_users essu where ess.Id = essu.Event_slm_subscribe_Id and ess.EventId = '" + qstring + "')");
            list = new ListBox();
            list.SelectionMode = ListSelectionMode.Multiple;
            SelectedPeopleList.Controls.Add(list);

            if (!IsPostBack)
            {
                for (int count = 0; count < SelectPeople.Rows.Count; count++)
                {
                    list.Items.Add(SelectPeople.Rows[count]["UserName"].ToString());

                    //ListBox1.Items.da DataValueField = "";

                    //ListBox1.;

                }
            }

            // for

        }
        int I;
        DataTable ServiceLineManagerId = new DataTable();
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            int qstring = Convert.ToInt32(Request.QueryString["Id"]);
            EventSubsribeNotification eventSubsribeNotification = new EventSubsribeNotification();
            //ServiceLineManagerId = addNotificationRepository.GetData("select slm.Id from ServiceLine sl, ServiceLineManager slm, AspNetUsers anu where sl.Id = slm.ServiceLineId and slm.UserId = anu.Id and anu.Id = '" + Context.User.Identity.GetUserId().ToString() + "' and sl.Name = '" + DropDownList1.SelectedItem + "'");
            //I = Convert.ToInt32(ServiceLineManagerId.Rows[0]["Id"].ToString());
            int evsubid = eventSubsribeNotification.InsertEvent_slm_subscribe(qstring, Convert.ToInt32(DropDownList1.SelectedValue)/*Convert.ToInt32(Context.User.Identity.GetUserId())*/, 1, ConfCheck.Checked, MandCheck.Checked);

            if (IntranetCheck.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 1);
            }
            if (EmailCheckbox.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 2);
            }
            if (UnabotCheckBox.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 3);
            }
            if (SmsCheckBox.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 4);
            }
            for (int i = 0; i < UserListBox.Items.Count; i++)
            {
                if (UserListBox.Items[i].Selected)
                {
                    eventSubsribeNotification.InsertEvent_slm_subscribe_users(evsubid, UserListBox.Items[i].Value);
                }
            }

            Response.Redirect("Notifications.aspx");
        }

        protected void CancleButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications.aspx");
        }



        protected void Adduser_Click1(object sender, EventArgs e)
        {
            //for (int i = 0; i < UserListBox.Items.Count; i++)
            //{
            //list.Items.Contains(UserListBox.Items[i].Selected);
            //if (UserListBox.Items[i].Selected)
            //{
            //for (int count = 0; count < list.Items.Count; count++)
            //{
           
                ListItem s = list.Items.FindByValue(UserListBox.SelectedItem.Text);
                if (s != null)
                {
                    UserListBox.SelectedItem.Selected = false;
                Label1.Text = "User already exist";
                }
                else
                {
                    UserListBox.SelectedItem.Selected = true;
                    list.Items.Add(UserListBox.SelectedItem);
                    if (!Label1.Text.Contains(UserListBox.SelectedItem.Text))
                    {
                        Label1.Text += UserListBox.SelectedItem.Text + " ";
                        // Label1.Text = Label1.Text.Replace(UserListBox.SelectedItem.Text+" ", "");
                    }

                }
                // }
            // }
           // }
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {

        }
    }
}