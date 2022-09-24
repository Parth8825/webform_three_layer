using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormThreeLayer
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvCustomer.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int custId = int.Parse(txtCustID.Text);
            string custName = txtCustName.Text;
            string city = txtCity.Text;
            double grade = double.Parse(txtGrade.Text);
            int salesId = int.Parse(txtSalesId.Text);

            CustomerBO newCustomer = new CustomerBO()
            {
                CustomerId = custId,
                CustomerName = custName,
                City = city,
                Grade = grade,
                SalesId = salesId
            };

            CustomerBL businessLogic = new CustomerBL();
            var result = businessLogic.InsertNewCustomer(newCustomer);

            if(result > 0)
            {
                string message = "Customer details have been saved successfully.";
                gvCustomer.DataBind();
                ClearFormFields();
                DataSaveMessage(message);
            }
            else
            {
                string message = "ERROR!!!!! failed to insert new customer.";
                DataSaveMessage(message);
            }
        }

        private void ClearFormFields()
        {
            txtCustID.Text = "";
            txtCustName.Text = "";
            txtCity.Text = "";
            txtGrade.Text = "";
            txtSalesId.Text = "";
            txtCustID.Focus();

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