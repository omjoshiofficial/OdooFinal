using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement.login_pages
{
    public partial class Login : System.Web.UI.Page
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
            cmd = new SqlCommand("select * from UserTable where email=@email and password=@pass", cn);
            cmd.Parameters.AddWithValue("@email", usernametxt.Text);
            cmd.Parameters.AddWithValue("@pass", passwordtxt.Text);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            HttpCookie loginck = new HttpCookie("login");


            if (ds.Tables[0].Rows.Count > 0)
            {
                loginck.Values.Add("uid", ds.Tables[0].Rows[0]["uid"].ToString());


                Response.Cookies.Add(loginck);


                Response.Write("<script>alert('Login Successfull!!')</script>");
                Response.Redirect("../UserSide/UserDash.aspx");
            }
            else
            {
                Response.Write("<script>alert('Enter Valid Email & Password!!')</script>");

            }
        }
    }
}