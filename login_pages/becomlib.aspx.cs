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

namespace LibraryManagement.login_pages
{

    public partial class becomlib : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            mycon();
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            mycon();

            cmd = new SqlCommand("select * from UserTable where email=@email", cn);
            cmd.Parameters.AddWithValue("@email", email.Text);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                var uid = ds.Tables[0].Rows[0]["uid"].ToString();
                cmd = new SqlCommand("insert into TempLibRole values (@uid,@mail,@role,@date)", cn);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@mail", email.Text);
                cmd.Parameters.AddWithValue("@role", "Librarian");
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());

                cmd.ExecuteNonQuery();
                email.Text = string.Empty;

                Response.Write("<script> alert('Within 24 hours You will be a Member of System') </script>");

            }
            else
            {
                Response.Write("<script>alert('Please Enter a Valid Email')</script>");

            }



        }
    }
}