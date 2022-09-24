using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormThreeLayer
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvOrders.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int orderNo = int.Parse(txtOrderNo.Text);
            double purchAmt = double.Parse(txtPurchAmt.Text);
            DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
            int customerId = int.Parse(txtCustId.Text);
            int salesmanId = int.Parse(txtSalsId.Text);

            OrderBO newOrder = new OrderBO()
            {
                OrderNo = orderNo,
                PurchAmt = purchAmt,
                OrderDate = orderDate,
                CustomerId = customerId,
                SalesmanId = salesmanId,
            };

            OrderBL businessLogic = new OrderBL();
            var result = businessLogic.InsertNewOrder(newOrder);
            
            if(result > 0)
            {
                string message = "Order details have been saved successfully.";
                gvOrders.DataBind();
                ClearFormFields();
                DataSaveMessage(message);
            }
            else
            {
                string message = "ERROR!!!!! failed to insert new order.";
                DataSaveMessage(message);
            }

        }

        private void ClearFormFields()
        {
            txtCustId.Text = "";
            txtOrderDate.Text = "";
            txtOrderNo.Text = "";
            txtPurchAmt.Text = "";
            txtSalsId.Text = "";
            txtOrderNo.Focus();
        }
        private void DataSaveMessage(string message)
        {
            //Display success message.
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }
    }
}