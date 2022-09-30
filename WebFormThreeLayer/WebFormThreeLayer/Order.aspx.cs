﻿using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebFormThreeLayer
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNo = int.Parse(txtOrderNo.Text);
                decimal purchAmt = decimal.Parse(txtPurchAmt.Text);
                DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
                int customerId = int.Parse(dlCustId.Text);
                int salesmanId = int.Parse(dlSalesmanId.Text);

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

                string message = "Order details have been saved successfully.";
                string key = "Success";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Order data.";
                    key = "Error";
                }
                IfCondition(result, message, key);
            }
            catch (FormatException)
            {
                string emptyMessage = "Please enter the value";
                string emptyKey = "Warning";
                MessageBox(emptyMessage, emptyKey);
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNo = int.Parse(txtOrderNo.Text);
                decimal purchAmt = decimal.Parse(txtPurchAmt.Text);
                DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
                int customerId = int.Parse(dlCustId.Text);
                int salesmanId = int.Parse(dlSalesmanId.Text);

                OrderBO order = new OrderBO()
                {
                    OrderNo = orderNo,
                    PurchAmt = purchAmt,
                    OrderDate = orderDate,
                    CustomerId = customerId,
                    SalesmanId = salesmanId,
                };

                OrderBL businessLogic = new OrderBL();
                var result = businessLogic.UpdateOrder(order);

                string message = "Order details have been successfully updated.";
                string key = "Success";

                if (result == 0)
                {
                    message = "ERROR!!!!! failed to update Order data. Data does not exists.";
                    key = "Error";
                }
                IfCondition(result, message, key);
            }
            catch (FormatException)
            {
                string emptyMessage = "Please enter the value";
                string emptyKey = "Warning";
                MessageBox(emptyMessage, emptyKey);

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNo = int.Parse(txtDeleteId.Text);

                OrderBO order = new OrderBO()
                {
                    OrderNo = orderNo
                };

                OrderBL businessLogic = new OrderBL();
                var result = businessLogic.DeleteOrder(order);

                string message = "Order details have been successfully deleted.";
                string key = "Delete";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to delete Order data.";
                    key = "Error";
                }
                IfCondition(result, message, key);
            }
            catch (FormatException)
            {
                string emptyMessage = "Please enter the value";
                string emptyKey = "Warning";
                MessageBox(emptyMessage, emptyKey);
            }
        }
        private void BindGridView()
        {
            try
            {
                DataTable dt = new DataTable();

                OrderBL businessLogic = new OrderBL();
                var result = businessLogic.OrderDate(dt);

                if (result > 0)
                {
                    gvOrder.DataSource = dt;
                    gvOrder.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }

        }
        private void ClearFormFields()
        {
            dlCustId.SelectedIndex= 0;
            txtOrderDate.Text = "";
            txtOrderNo.Text = "";
            txtPurchAmt.Text = "";
            dlSalesmanId.SelectedIndex = 0;
            txtDeleteId.Text = "";
            txtOrderNo.Focus();
        }

        private void IfCondition(int ifResult, string ifMessage, string messageKey)
        {
            if (ifResult > 0)
            {
                BindGridView();
                MessageBox(ifMessage, messageKey);
                ClearFormFields();
            }
            else
            {
                MessageBox(ifMessage, messageKey);
                ClearFormFields();
            }
        }
        private void MessageBox(string message, string key)
        {
            //Display success message.

            if (key == "Success")
            {
                string script = "swal('Saved','";
                script += message;
                script += "', 'success')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if (key == "Delete")
            {
                string script = "swal('Deleted','";
                script += message;
                script += "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if (key == "Error")
            {
                string script = "swal('Sorry!!','";
                script += message;
                script += "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if (key == "Warning")
            {
                string script = "swal('Empty!!','";
                script += message;
                script += "', 'warning')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);

            }
        }

        
    }
}