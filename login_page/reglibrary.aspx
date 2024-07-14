<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reglibrary.aspx.cs" Inherits="login_page_reglibrary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta name="description" content="Responsive Admin Template" />
    <meta name="author" content="SmartUniversity" />
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

    <title>Library Management</title>

    <style>

        .validation_myclass {
    font-size: 25px;
    position: absolute;
    bottom: 330px;
    width: 400px;
    right: 70px;
    padding: 15px;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>


            <div class="limiter">
                <div class="container-login100 page-background">
                    <div class="wrap-login100">
                        <div class="login100-form validate-form">
                            <span class="login100-form-logo">
                                <img alt="" src="../assets/images/examhelper.jpg" />
                            </span>
                            <span class="login100-form-title p-b-34 p-t-27">Registration
                            </span>
                            <%--<asp:RequiredFieldValidator ErrorMessage="UserName is Required" ForeColor="Red" ControlToValidate="usernametxt" runat="server" />--%>

                            <div class="row">

                                <div class="col-lg-6 p-t-20">
                                    <div class="wrap-input100 validate-input" data-validate="Enter username">

                                        <asp:TextBox runat="server" ID="usernametxt" class="input100" placeholder="Username" required="required" />

                                        <%--<input class="input100" type="text" name="username" placeholder="Username">--%>
                                        <span class="focus-input100" data-placeholder="&#xf207;"></span>

                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    
                                    <div class="wrap-input100 validate-input" data-validate="Enter email">

                                        <asp:TextBox runat="server" ID="emailtxt" class="input100" placeholder="Email" />

                                        <%--<input class="input100" type="email" name="email" placeholder="Email">--%>
                                        <span class="focus-input100" data-placeholder="&#xf207;"></span>

                                    </div>
                                </div>

                               
                                <div class="col-lg-12 p-t-20">

                                    

                                    <div class="wrap-input100 validate-input" data-validate="Enter password">

                                        <asp:TextBox runat="server" ID="passwordtxt" class="input100" placeholder="Password" />
                                        <span class="focus-input100" data-placeholder="&#xf191;"></span>

                                    </div>
                                </div>
                               
                                <div class="col-lg-6 p-t-20">

                                    <asp:Button Text="Send OTP" class="login100-form-btn" ID="otp" OnClick="otp_Click" runat="server" />

                                </div>

                                <div class="col-lg-6 p-t-20">
                                    <div class="wrap-input100 validate-input" data-validate="Enter password again">

                                        <asp:TextBox runat="server" ID="otptxt" class="input100" placeholder="Enter OTP" />

                                        <%--<input class="input100" type="password" name="pass2" placeholder="Confirm password">--%>
                                        <span class="focus-input100" data-placeholder="&#xf191;"></span>

                                    </div>

                                </div>
                            </div>

                            <div class="container-login100-form-btn mt-4">

                                <asp:Button Text="Sign Up" ID="registrationbtn" OnClick="registrationbtn_Click" class="login100-form-btn" runat="server" />

                                <%--<button class="login100-form-btn">
	
						</button>--%>
                            </div>
                            <div class="text-center p-t-50">
                                <a class="txt1" style="text-decoration: none" href="login_page.aspx">You already Sign In?
                                </a>

                                <br />

                                <a href="paper_material_provider.aspx" class="txt1" style="text-decoration: none; font: bold; font-size: 15px">Become A Librarian</a>

                            </div>

                            <div class="validation_myclass">
                                <%--Password--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" runat="server" ErrorMessage="One Lower , One Upper , Special Character , One Number , 8 Length" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"
                                        ControlToValidate="passwordtxt"></asp:RegularExpressionValidator>
                                
                                <%--Email--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailtxt"
                                        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        ErrorMessage="Invalid email address" />

                            </div>

                        </div>
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
