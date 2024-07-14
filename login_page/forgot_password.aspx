<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot_password.aspx.cs" Inherits="login_page_forgot_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta name="description" content="Responsive Admin Template" />
    <meta name="author" content="SmartUniversity" />
    <title>Exam Helper</title>
    <!-- google font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="assets/plugins/iconic/css/material-design-iconic-font.min.css" />
    <!-- bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- style -->
    <link rel="stylesheet" href="assets/css/pages/extra_pages.css" />
    <!-- favicon -->
    <%--<link rel="shortcut icon" href="assets/img/favicon.ico" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="limiter">
                <div class="container-login100 page-background">
                    <div class="wrap-login100">
                        <form class="login100-form validate-form">
                            <span class="login100-form-logo">
                                <img alt="" src="../assets/images/examhelper.jpg" />
                            </span>
                            <p class="text-center txt-small-heading">
                                Forgot Your Password ? Let Us Help You.
                            </p>

                            <div class="wrap-input100 validate-input" data-validate="Enter username">

                                <asp:TextBox runat="server" ID="forgottxt" class="input100" placeholder="Enter Your Register Email Address" />
                                
                                <span class="focus-input100" data-placeholder="&#xf207;"></span>

                            </div>

                            <div class="row">


                                <div class="col-lg-6 p-t-20" id="forgotvisible" runat="server" visible="true">

                                    <asp:Button Text="Send" runat="server" ID="forgotbtn" OnClick="forgotbtn_Click" class="login100-form-btn" />

                                </div>


                                <div class="col-lg-6 p-t-20">
                                    <div class="wrap-input100 validate-input" data-validate="Enter password again">

                                        <asp:TextBox runat="server" ID="otptxt" class="input100" placeholder="Enter OTP" />

                                        <%--<input class="input100" type="password" name="pass2" placeholder="Confirm password">--%>
                                        <span class="focus-input100" data-placeholder="&#xf191;"></span>

                                    </div>

                                </div>

                                <div class="col-lg-6 p-t-20" id="newpass" runat="server" visible="false">
                                    <div class="wrap-input100 validate-input" data-validate="Enter password again">

                                        <asp:TextBox runat="server" ID="updatedpasstxt" class="input100" placeholder="New Password" />
                                        <%--<asp:RequiredFieldValidator ErrorMessage="Enter New Password" ControlToValidate="updatedpasstxt" runat="server" />--%>
                                        <span class="focus-input100" data-placeholder="&#xf191;"></span>

                                    </div>

                                </div>


                            </div>


                              <div class="container-login100-form-btn" id="updatediv" runat="server" visible="false">

                                    <asp:Button Text="Update" runat="server" ID="updatebtn" OnClick="updatebtn_Click" class="login100-form-btn" />

                                </div>


                            <div class="text-center p-t-27">
                                <a class="txt1" href="loginLibrary.aspx">Login?
                                </a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!-- start js include path -->
            <script src="assets/plugins/jquery/jquery.min.js"></script>
            <!-- bootstrap -->
            <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
            <script src="assets/js/pages/extra_pages/login.js"></script>
            <!-- end js include path -->

        </div>
    </form>
</body>
</html>
