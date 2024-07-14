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

public partial class login_page_forgot_password : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection cn;
    SqlDataAdapter da;
    DataSet ds;

    void mycon()
    {
        cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\omjoshi\.net\Exam Helper\Exam Helper\App_Data\ExamHelper.mdf;Integrated Security=True");
        cn.Open();

    }


    public void mailsend(string tomail, string subjecttxt, string bodytxt)
    {


        // Email details
        string toEmail = tomail; // Replace with recipient's email address
        string subject = subjecttxt;
        string body = bodytxt;

        // Gmail SMTP settings
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587;
        string smtpUsername = "rajanupadhyaydeveloper@gmail.com"; // Replace with your Gmail address
        string smtpPassword = "zqge awja bazr qwgf";   // Replace with your Gmail password

        // Create an SMTP client
        using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
        {
            smtpClient.EnableSsl = true;// Enable SSL/TLS
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            // Create an email message
            using (MailMessage mailMessage = new MailMessage(smtpUsername, toEmail, subject, body))
            {
                mailMessage.IsBodyHtml = true;

                try
                {
                    // Send the email
                    smtpClient.Send(mailMessage);
                    // Optionally, you can store the OTP in session or database for verification

                    //HttpContext.Current.Session["OTP"] = otp;
                    HttpContext.Current.Response.Write("<script>alert('OTP sent successfully.')</script>");
                    //return 1;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("<script>alert('Error sending OTP')</script>");
                    //return 0;
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        mycon();
    }

    protected void forgotbtn_Click(object sender, EventArgs e)
    {
        Random random = new Random();
        int otp = random.Next(100000, 999999);
        string body = "Your OTP is "+otp+". Please use this OTP to verify your account.";
        mailsend(forgottxt.Text, "otp verification", body);
        Session["OTP"] = otp.ToString();
        forgotvisible.Visible = false;
        updatediv.Visible = true;
        newpass.Visible = true;
    }

    protected void updatebtn_Click(object sender, EventArgs e)
    {

        mycon();

        if (Session["OTP"] != null)
        {
            if (Session["OTP"].ToString() == otptxt.Text)
            {
                cmd = new SqlCommand("select * from UserTable where email=@email", cn);
                cmd.Parameters.AddWithValue("@email", forgottxt.Text);

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmd = new SqlCommand("update UserTable set password=@pass where email=@email", cn);
                    cmd.Parameters.AddWithValue("@email", forgottxt.Text);
                    cmd.Parameters.AddWithValue("@pass", updatedpasstxt.Text);

                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Data Update Successfully!!')</script>");
                    forgottxt.Text = String.Empty;
                    otptxt.Text = String.Empty;
                    updatedpasstxt.Text = String.Empty;
                    forgotvisible.Visible = true;
                    updatediv.Visible = false;
                    newpass.Visible = false;

                }
                else
                {
                    Response.Write("<script>alert('Email is Not Exist!!')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('OTP Does Not Match')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Click On Send OTP Button')</script>");
        }
    }
}