using KitchenApplication.KitchenServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenApplication
{
    public partial class Orders : System.Web.UI.Page
    {
        public static List<OrderLine> orderDetailsList = new List<OrderLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            string pageRole = "Orders";
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
            if (!IsPostBack)
            {
                ddlOrders.DataSource = service.GetAllOrders();
                ddlOrders.DataTextField = "OrderID";
                ddlOrders.DataBind();

                dgvOrders.DataSource = service.GetAllOrders();
                dgvOrders.DataBind();
                if (!IsPostBack)
                {
                    updateFields(service.GetOrderByID("1"));
                    ddlOrderMeals.DataSource = service.GetAllMeals();
                    ddlOrderMeals.DataTextField = "MealName";
                    ddlOrderMeals.DataBind();
                }
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            updateFields(service.GetOrderByID(ddlOrders.SelectedValue));
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lblOrderID.Text = "0";
            txtOrderDesc.Text = "";
            txtOrderStatus.Text = "";
            orderDetailsList = new List<OrderLine>();
            dgvOrderDetails.DataSource = orderDetailsList;
            dgvOrderDetails.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            service.SaveOrder(int.Parse(lblOrderID.Text), txtOrderDesc.Text, txtOrderStatus.Text);
            ddlOrders.DataSource = service.GetAllOrders();
            ddlOrders.DataTextField = "OrderID";
            ddlOrders.DataBind();

            dgvOrders.DataSource = service.GetAllOrders();
            dgvOrders.DataBind();

            ddlOrderMeals.DataSource = service.GetAllMeals();
            ddlOrderMeals.DataTextField = "MealName";
            ddlOrderMeals.DataBind();
        }

        protected void btnAddMeal_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            service.SaveOrderLine(0, int.Parse(lblOrderID.Text), service.SearchMeals(ddlOrderMeals.SelectedValue)[0].MealID, int.Parse(txtMealAmount.Text));
            updateFields(service.GetOrderByID(ddlOrders.SelectedValue));
        }

        protected void btnRemoveMeal_Click(object sender, EventArgs e)
        {
            var service = new KitchenServiceProxy.KitchenDataServiceSoapClient();
            service.RemovedMealFromOrder(int.Parse(lblOrderID.Text), service.SearchMeals(ddlOrderMeals.SelectedValue)[0].MealID);
            updateFields(service.GetOrderByID(ddlOrders.SelectedValue));
        }

        public void updateFields(Order o)
        {
            lblOrderID.Text = o.OrderID.ToString();
            txtOrderDesc.Text = o.OrderDescription;
            txtOrderStatus.Text = o.OrderStatus;
            orderDetailsList = o.Orders.ToList();
            dgvOrderDetails.DataSource = orderDetailsList;
            dgvOrderDetails.DataBind();
        }
    }
}