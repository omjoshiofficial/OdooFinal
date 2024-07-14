using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace LibraryManagement.UserSide
{
    public partial class BookList : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;

        void mycon()
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\omjoshi\.net\LibraryManagement\App_Data\ExamHelper.mdf;Integrated Security=True");
            cn.Open();

        }
        void fill_book()
        {
            cmd = new SqlCommand("select * from BookTable", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                book_list_show.DataSource = ds;
                book_list_show.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            mycon();
            fill_book();

            if (Request.QueryString["dlt"] != null)
            {
                var bid = Convert.ToInt32(Request.QueryString["dlt"].ToString());

                cmd = new SqlCommand("delete from BookTable where bid=@bid", cn);
                cmd.Parameters.AddWithValue("@bid", bid);

                cmd.ExecuteNonQuery();
                Response.Redirect("../UserSide/booklist.aspx");

            }

        }
    }
}