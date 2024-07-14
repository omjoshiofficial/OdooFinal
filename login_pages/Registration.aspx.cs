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
    public partial class Registration : System.Web.UI.Page
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

        protected void registrationbtn_Click1(object sender, EventArgs e)
        {

            if (Session["OTP"] != null)
            {
                if (Session["OTP"].ToString() == otptxt.Text)
                {
                    cmd = new SqlCommand("select * from UserTable where email=@email", cn);
                    cmd.Parameters.AddWithValue("@email", emailtxt.Text);

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<script>alert('Data Already Exits!!')</script>");
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into UserTable values (@uname , @uemail , @pass ,@role ,@dt)", cn);
                        cmd.Parameters.AddWithValue("@uname", usernametxt.Text);
                        cmd.Parameters.AddWithValue("@uemail", emailtxt.Text);
                        cmd.Parameters.AddWithValue("@pass", passwordtxt.Text);
                        cmd.Parameters.AddWithValue("@role", "user");
                        cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToString());


                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Data Added Successfully!!')</script>");
                        usernametxt.Text = String.Empty;
                        emailtxt.Text = String.Empty;
                        passwordtxt.Text = String.Empty;
                        otptxt.Text = String.Empty;

                        otp.Visible = true;
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

        protected void otp_Click1(object sender, EventArgs e)
        {
            Random random = new Random();
            int otpnu = random.Next(100000, 999999);
            string body = "Your OTP is " + otpnu + ". Please use this OTP to verify your account.";
            mailsend(emailtxt.Text, "otp verification", body);
            Session["OTP"] = otpnu.ToString();
            //otp.Visible = false;
            otp.Visible = false;
        }
    }
}