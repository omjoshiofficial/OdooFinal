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
    public partial class AddBook : System.Web.UI.Page
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

            if (IsPostBack == false)
            {
                if (Request.QueryString["edt"] != null)
                {
                    var bid = Request.QueryString["edt"].ToString();
                    cmd = new SqlCommand("select * from BookTable where bid=@bid", cn);
                    cmd.Parameters.AddWithValue("@bid", bid);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        isbntxt.Text = ds.Tables[0].Rows[0]["isbn"].ToString();
                        titletx.Text = ds.Tables[0].Rows[0]["title"].ToString();
                        authortxt.Text = ds.Tables[0].Rows[0]["author"].ToString();
                        publishertxt.Text = ds.Tables[0].Rows[0]["publisher"].ToString();
                        yeartxt.Text = ds.Tables[0].Rows[0]["year"].ToString();
                        genretxt.Text = ds.Tables[0].Rows[0]["genre"].ToString();
                        quantitytxt.Text = ds.Tables[0].Rows[0]["quantity"].ToString();
                        bookimgurl.ImageUrl = ds.Tables[0].Rows[0]["bookimg"].ToString();

                    }
                }
            }

        }

        protected void btn_submit_book_Click(object sender, EventArgs e)
        {
            var uid = Convert.ToInt32(Request.Cookies["login"].Values["uid"].ToString());


            if (Request.QueryString["edt"] != null)
            {
                var bid = Request.QueryString["edt"].ToString();

                cmd = new SqlCommand("update BookTable set isbn=@isbn , title=@title , author=@author , publisher=@publisher , year=@year , genre=@gen , quantity=@qty , date=@dt , bookimg=@fimage  where bid=@bid", cn);
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.Parameters.AddWithValue("@isbn", isbntxt.Text);
                cmd.Parameters.AddWithValue("@title", titletx.Text);
                cmd.Parameters.AddWithValue("@author", authortxt.Text);
                cmd.Parameters.AddWithValue("@publisher", publishertxt.Text);
                cmd.Parameters.AddWithValue("@year", yeartxt.Text);
                cmd.Parameters.AddWithValue("@gen", genretxt.Text);
                cmd.Parameters.AddWithValue("@qty", quantitytxt.Text);
                cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToString());

                if (bookimg.HasFile)
                {
                    if (bookimg.PostedFile.ContentLength <= 5 * 1024 * 1024)
                    {
                        string path = "../images/" + bookimg.FileName;
                        bookimg.SaveAs(Server.MapPath(path));

                        bookimgurl.ImageUrl = path;

                        cmd.Parameters.AddWithValue("@fimage", path);
                    }
                    else
                    {
                        Response.Write("<script>alert('Upload Image Under 5 MB')</script>");
                        return;

                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fimage", bookimgurl.ImageUrl);
                }
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data Update Successfully!!')</script>");
                Response.Redirect("../UserSide/booklist.aspx");

            }
            else
            {
                cmd = new SqlCommand("insert into BookTable values(@isbn,@title,@author,@publisher,@year,@gen,@qty,@dt,@uid,@fimage)", cn);
                cmd.Parameters.AddWithValue("@isbn", isbntxt.Text);
                cmd.Parameters.AddWithValue("@title", titletx.Text);
                cmd.Parameters.AddWithValue("@author", authortxt.Text);
                cmd.Parameters.AddWithValue("@publisher", publishertxt.Text);
                cmd.Parameters.AddWithValue("@year", yeartxt.Text);
                cmd.Parameters.AddWithValue("@gen", genretxt.Text);
                cmd.Parameters.AddWithValue("@qty", quantitytxt.Text);
                cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@uid", uid);

                if (bookimg.HasFile)
                {
                    if (bookimg.PostedFile.ContentLength <= 5 * 1024 * 1024)
                    {
                        string path = "../images/" + bookimg.FileName;
                        bookimg.SaveAs(Server.MapPath(path));

                        bookimgurl.ImageUrl = path;

                        cmd.Parameters.AddWithValue("@fimage", path);
                    }
                    else
                    {
                        Response.Write("<script>alert('Upload Image Under 5 MB')</script>");
                        return;

                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fimage", bookimgurl.ImageUrl);
                }
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data Added Successfully!!')</script>");

            }

        }
    }
}