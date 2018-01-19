using KitchenApplication.KitchenServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenApplication
{
    public partial class Meals : System.Web.UI.Page
    {
        static int index = 1;
        static List<MealIngredients> IngredientList = new List<MealIngredients>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            string pageRole = "Meals";
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
                    if (role.Equals(pageRole))
                    {
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
            Meal m = service.GetMealByID(index.ToString());
            dgvMeals.DataSource = service.GetAllMeals();
            dgvMeals.DataBind();
            updateFields(m);

            if (!IsPostBack)
            {
                ddlIngredients.DataSource = service.GetAllIngredients();
                ddlIngredients.DataTextField = "IngredientName";
                ddlIngredients.DataBind();
                updateIngredientList(m);
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (index > 1)
            {
                index--;
                var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
                Meal m = service.GetMealByID(index.ToString());
                updateIngredientList(m);
                updateFields(m);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            if (index < service.GetAllMeals().Length)
            {
                index++;
                Meal m = service.GetMealByID(index.ToString());
                updateIngredientList(m);
                updateFields(m);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            Meal m = service.GetMealByID(index.ToString());

            service.SaveMeal(int.Parse(lblMealID.Text), txtMealName.Text, int.Parse(txtMealServings.Text), chkMealVege.Checked);
            ddlIngredients.DataSource = service.GetAllIngredients();
            ddlIngredients.DataTextField = "IngredientName";
            ddlIngredients.DataBind();
            updateIngredientList(m);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lblMealID.Text = "0";
            txtMealName.Text = "";
            txtMealServings.Text = "";
            chkMealVege.Checked = false;
            dgvMealIngredients.DataSource = new List<Meal>();
            dgvMealIngredients.DataBind();
            IngredientList = new List<MealIngredients>();
        }

        protected void btnAddIngredient_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            int ingid = service.SearchIngredients(ddlIngredients.SelectedValue)[0].IngredientID;

            service.SaveMealIngredient(0, int.Parse(lblMealID.Text), ingid, int.Parse(txtIngredientCount.Text));
            updateFields(service.GetMealByID(index.ToString()));
        }

        protected void btnRemoveIngredient_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            try
            {
                service.RemoveIngredientFromMeal(int.Parse(lblMealID.Text), service.SearchIngredients(ddlMealIngredient.SelectedValue)[0].IngredientID);
            }
            catch
            {
                updateIngredientList(service.GetMealByID(index.ToString()));
            }
            updateFields(service.GetMealByID(index.ToString()));
        }

        private void updateIngredientList(Meal m)
        {
            ddlMealIngredient.DataSource = m.MealIngredients;
            ddlMealIngredient.DataTextField = "IngredientName";
            ddlMealIngredient.DataBind();
        }

        private void updateFields(Meal m)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            lblMealID.Text = m.MealID.ToString();
            txtMealName.Text = m.MealName;
            txtMealServings.Text = m.MealServingSize.ToString();
            chkMealVege.Checked = m.MealVegetarian;

            IngredientList = m.MealIngredients.ToList();
            dgvMealIngredients.DataSource = IngredientList;
            dgvMealIngredients.DataBind();
        }
    }
}