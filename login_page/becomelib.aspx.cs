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

public partial class UserSide_becomelib : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection cn;
    SqlDataAdapter da;
    DataSet ds;

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

    void mycon()
    {
        cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\omjoshi\.net\Exam Helper\Exam Helper\App_Data\ExamHelper.mdf;Integrated Security=True");
        cn.Open();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginbtn_Click(object sender, EventArgs e)
    {
        mycon();

        cmd = new SqlCommand("select * from UserTable where email=@email and password=@pass", cn);
        cmd.Parameters.AddWithValue("@email", email.Text);

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);



    }
}