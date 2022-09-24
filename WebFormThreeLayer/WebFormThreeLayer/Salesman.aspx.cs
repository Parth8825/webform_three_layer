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
    public partial class Salesman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvSalesman.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int salesmanID = Convert.ToInt32(txtID.Text);
            string name = txtSalesmanName.Text;
            string city = txtCity.Text;
            float commision = float.Parse(txtCommission.Text);

            SalesmanBO newSalesman = new SalesmanBO()
            {
                SalesmanId = salesmanID,
                SalesmanName = name,
                City = city,
                Commision = commision
            };

            SalesmanBL businessLogic = new SalesmanBL();
            var result = businessLogic.InsertNewSalesman(newSalesman);

            if(result > 0)
            {
                string message = "Salesman details have been saved successfully.";
                gvSalesman.DataBind();
                ClearFormFields();
                DataSaveMessage(message);
            }
            else
            {
                string message = "ERROR!!!!! failed to insert new salesman.";
                DataSaveMessage(message);
            }
        }

        private void ClearFormFields()
        {
            txtSalesmanName.Text = "";
            txtID.Text = "";
            txtCommission.Text = "";
            txtCity.Text = "";
            txtID.Focus();
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