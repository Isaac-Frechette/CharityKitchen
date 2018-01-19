using KitchenApplication.KitchenServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenApplication
{
    public partial class Ingredients : System.Web.UI.Page
    {
        static int index = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            string pageRole = "Ingredients";
            bool allowed = false;
            try
            {
                var user = Session["user"] as KitchenServiceProxy.KitchenUser;
                if (user.UserID == 0)
                {
                    Response.Redirect("~/Default.aspx");
                }
                foreach (string role in service.GetUserRoles(user))
                {
                    if (role.Equals(pageRole)){
                        allowed = true;
                    }
                }
                if (!allowed)
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/login.aspx");
            }
            
            if (!IsPostBack)
            {
                updateFields(service.GetIngredientByID(index.ToString()));
            }
            DGVIngredients.DataSource = service.GetAllIngredients();
            DGVIngredients.DataBind();

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (index > 1)
            {
                var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
                index--;
                updateFields(service.GetIngredientByID(index.ToString()));
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            if (index < service.GetAllIngredients().Length)
            {
                index++;
                updateFields(service.GetIngredientByID(index.ToString()));
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lblIngredientID.Text = "0";
            txtIngredientName.Text = "";
            txtMeasurement.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            service.SaveIngredient(int.Parse(lblIngredientID.Text), txtIngredientName.Text, txtMeasurement.Text);
            lblIngredientID.Text = service.GetAllIngredients().Length.ToString();
            DGVIngredients.DataSource = service.GetAllIngredients();
            DGVIngredients.DataBind();
        }

        private void updateFields(Ingredient ing)
        {
            lblIngredientID.Text = ing.IngredientID.ToString();
            txtIngredientName.Text = ing.IngredientName;
            txtMeasurement.Text = ing.IngredientMeasurementType;
        }
    }
}