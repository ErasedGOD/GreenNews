using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenTest
{
    public partial class Newsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadSubjects();
                divFinalImage.Visible = false;
            }
            
        }

        private void LoadSubjects()
        {

            DataTable dt = Components.Newsletter.GetSources();
            ddlSource.DataSource = dt;
            ddlSource.DataTextField = "Description";
            ddlSource.DataBind();
            
            // Add the initial item
            ddlSource.Items.Insert(0, new ListItem("<Select Source>", "0"));

        }

        public void Submit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            int idSource = ddlSource.SelectedIndex;
            string reason = txtReason.Text;

            if (email != "" && idSource != 0)
            {
                bool queryResult = Components.Newsletter.InsertSubmit(email, idSource,reason);

                if (queryResult != true)
                {
                    /* Fail Message*/
                    Response.Write("<script>alert('There is already a record for this newsletter!');</script>");
                }
                else
                {
                    /* Sucess Message */
                    divNewsletter.Visible = false;
                    divFinalImage.Visible = true;
                    Response.Write("<script>alert('Newsletter Submit Succesfully!');</script>");
                }
            }
        }

    }
}