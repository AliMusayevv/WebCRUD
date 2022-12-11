using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebCRUD
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();
            }

        }
        protected void Fill()
        {
            using (SqlConnection conn = new SqlConnection(Connection.DS)) 

  
            {
                conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from WebCRUD", conn);
                SqlDataReader DR = cmd.ExecuteReader();
                if (DR.HasRows == true)
                {
                    GrdResults.DataSource = DR;
                    GrdResults.DataBind();
                }
            }
        }

        protected void GrdResults_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdResults.EditIndex = e.NewEditIndex;
            Fill();
        }

        protected void GrdResults_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string test1 = ((TextBox)GrdResults.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string test2 = ((TextBox)GrdResults.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string test3 = ((TextBox)GrdResults.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string test4 = ((TextBox)GrdResults.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string test5 = ((TextBox)GrdResults.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            int id = Convert.ToInt32(GrdResults.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection conn = new SqlConnection(Connection.DS))
            {
                int n = Connection.Update(test1,test2,test3 ,test4 ,test5,id );    

                
                if(n>0)
                {
                    Response.Write("<script>alert('Data successfully uptating')</script>");
                    GrdResults.EditIndex = -1;
                    Fill();
                }
            }
  

        }

        protected void GrdResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
        
        {
            int id = Convert.ToInt32(GrdResults.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection conn = new SqlConnection(Connection.DS);
            int x = Connection.Delete(id);
            if (x > 0)
            {

                Response.Write("<script>alert('Data successfully deleting')</script>");
                GrdResults.EditIndex = -1;
                Fill();
            }





        }

    protected void GrdResults_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdResults.EditIndex = -1;
            Fill();
        }
    }
}