using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWorkingWeb.Pages
{
    public partial class gridWithCheckbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                BindData();
                //DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Name"), new DataColumn("Country") });
                //dt.Rows.Add("John Hammond", "Canada");
                //dt.Rows.Add("Rick Stewards", "United States");
                //dt.Rows.Add("Huang He", "China");
                //dt.Rows.Add("Mudassar Khan", "India");
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
            }
        }

        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("EmployeeId"), new DataColumn("FirstName") });
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string EmployeeId = row.Cells[1].Text;
                        string FirstName = (row.Cells[2].FindControl("lblFirst") as Label).Text;
                        dt.Rows.Add(EmployeeId, FirstName);
                    }
                }
            }
            gvSelected.DataSource = dt;
            gvSelected.DataBind();
        }

        protected void BindData()
        {
            //Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\799688\Documents\claimsdb.mdf;Integrated Security=True;Connect Timeout=30

            string strConnection = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
           GridView1.DataSource = ds;
           GridView1.DataBind();
            con.Close();
        }

        protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("EmployeeId"), new DataColumn("FirstName") });
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string EmployeeId = row.Cells[1].Text;
                        string FirstName = (row.Cells[2].FindControl("lblFirst") as Label).Text;
                        dt.Rows.Add(EmployeeId, FirstName);
                    }
                }
            }
            gvSelected.DataSource = dt;
            gvSelected.DataBind();
           GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}