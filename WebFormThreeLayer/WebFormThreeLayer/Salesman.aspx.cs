﻿using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services.Description;
using DataAccess;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace WebFormThreeLayer
{
    public partial class Salesman : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
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

                string message = "Salesman details have been saved successfully.";
                string key = "Success";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Salesman data.";
                    key = "Error";
                }
                IfCondition(result,message, key);
            }
            catch(FormatException)
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
                int salesmanID = Convert.ToInt32(txtID.Text);
                string name = txtSalesmanName.Text;
                string city = txtCity.Text;
                float commision = float.Parse(txtCommission.Text);

                SalesmanBO salesman = new SalesmanBO()
                {
                    SalesmanId = salesmanID,
                    SalesmanName = name,
                    City = city,
                    Commision = commision
                };

                SalesmanBL businessLogic = new SalesmanBL();
                var result = businessLogic.UpdateSalesman(salesman);

                string message = "Salesman details have been successfully updated.";
                string key = "Success";

                if (result == 0)
                {
                    message = "ERROR!!!!! failed to update salesman data. Data does not exists.";
                    key="Error";
                }
               IfCondition(result, message, key);
            }
            catch(FormatException)
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
                int salesmanID = Convert.ToInt32(txtDeleteId.Text);

                SalesmanBO salesman = new SalesmanBO()
                {
                    SalesmanId = salesmanID,
                };

                SalesmanBL businessLogic = new SalesmanBL();
                var result = businessLogic.DeleteSalesman(salesman);

                string message = "Salesman details have been successfully deleted.";
                string key = "Delete";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to delete salesman data.";
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
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                var query = "select * from salesman;";
                SqlCommand cmd = new SqlCommand(query, connection);
                DataTable DT = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DT);

                if (DT.Rows.Count > 0)
                {
                    gvSalesman.DataSource = DT;
                    gvSalesman.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }
            finally { connection.Close(); }

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
        private void ClearFormFields()
        {
            txtSalesmanName.Text = "";
            txtID.Text = "";
            txtCommission.Text = "";
            txtCity.Text = "";
            txtDeleteId.Text = "";
            txtID.Focus();
        }

        private void MessageBox(string message, string key)
        {
            //Display success message.

            if(key == "Success")
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
            else if(key == "Error")
            {
                string script = "swal('Sorry!!','";
                script += message;
                script += "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if(key == "Warning")
            {
                string script = "swal('Empty!!','";
                script += message;
                script += "', 'warning')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key ,script, true);

            }
        }
    }
}