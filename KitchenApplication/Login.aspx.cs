using KitchenApplication.KitchenServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblStatus.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            KitchenUser user = service.Login(txtUsername.Text, txtPassword.Text);
            Session["user"] = user;

            if (user.UserID != 0)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblStatus.Text = "Login Failed";
            }
        }
    }
}