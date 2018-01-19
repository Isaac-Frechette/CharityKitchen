using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["user"] as KitchenServiceProxy.KitchenUser;
            if (user == null || user.UserID == 0)
            {
                Response.Redirect("~/Login.aspx");
            }
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            lblGreeting.Text = "Welcome, " + user.UserName;
            dgvRoles.DataSource = service.GetUserRoles(user);
            dgvRoles.DataBind();
        }
    }
}