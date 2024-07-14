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
    public partial class LibRequest : System.Web.UI.Page
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

        void fill_rep()
        {
            cmd = new SqlCommand("select * from TempLibRole", cn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                user_list_show.DataSource = ds;
                user_list_show.DataBind();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            mycon();

            fill_rep();

            if (Request.QueryString["dlt"] != null)
            {
                var tid = Convert.ToInt32(Request.QueryString["dlt"].ToString());

                cmd = new SqlCommand("delete from TempLibRole where tid=@tid", cn);
                cmd.Parameters.AddWithValue("@tid", tid);

                cmd.ExecuteNonQuery();
                Response.Redirect("librequest.aspx");


            }

            if (IsPostBack == false)
            {
                if (Request.QueryString["edttemp"] != null)
                {
                    var tid = Convert.ToInt32(Request.QueryString["edttemp"].ToString());

                    cmd = new SqlCommand("select * from TempLibRole where tid=@tid", cn);
                    cmd.Parameters.AddWithValue("@tid", tid);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var uid = ds.Tables[0].Rows[0]["uid"].ToString();

                        cmd = new SqlCommand("update UserTable set role=@role where uid=@uid", cn);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.AddWithValue("@role", "Librarian");

                        cmd.ExecuteNonQuery();

                        var t = Convert.ToInt32(Request.QueryString["edttemp"].ToString());

                        cmd = new SqlCommand("delete from TempLibRole where tid=@tid", cn);
                        cmd.Parameters.AddWithValue("@tid", t);

                        cmd.ExecuteNonQuery();


                        Response.Redirect("librequest.aspx");

                    }

                }
            }


        }
    }
}