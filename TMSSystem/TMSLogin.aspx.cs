using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSBiz.Interface;
using TMSBiz.Service;
using TMSBiz.VMModel;

namespace TMSSystem
{
    public partial class TMSLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {
            LoginVMModel vmModel = new LoginVMModel();
            ILoginInterface iLoginInterface = new LoginService();
            Response.Cookies["UserName"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            vmModel.Username = Username.Text.Trim();
            vmModel.Password = password.Text.Trim();
            bool msg = iLoginInterface.ValidateCredentials(vmModel);
            if (msg)
            {

                Response.Redirect("TMSCoach.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}