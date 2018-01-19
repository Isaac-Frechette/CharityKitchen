using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenApplication
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            if (txtUsername.Text != null && txtPassword.Text != null && txtRoleLevel.Text != null)
            {
                service.CreateUser(txtUsername.Text, txtPassword.Text, int.Parse(txtRoleLevel.Text));
            }
            Response.Redirect("Login.aspx");
        }
    }
}