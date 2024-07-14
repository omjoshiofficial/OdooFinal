<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagement.login_pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                <img alt="" src="../assets/images/examhelper.jpg"/>
                            </span>
                            <span class="login100-form-title p-b-34 p-t-27">log in
                            </span>
                            <div class="wrap-input100 validate-input" data-validate="enter username">

                                <asp:TextBox runat="server" ID="usernametxt" class="input100" placeholder="Email" />
                                
                                <%--<input class="input100" type="text" name="username" placeholder="username">--%>
                                <span class="focus-input100" data-placeholder="&#xf207;"></span>

                            </div>
                            <div class="wrap-input100 validate-input" data-validate="enter password">

                                <asp:TextBox runat="server" ID="passwordtxt" class="input100" placeholder="password" />
                                <%--<asp:RequiredFieldValidator ErrorMessage="Password is Required" ControlToValidate="passwordtxt" runat="server" />--%>
                                <%--<input class="input100" type="password" name="pass" placeholder="password">--%>
                                <span class="focus-input100" data-placeholder="&#xf191;"></span>

                            </div>
                            
                            <div class="container-login100-form-btn">

                                <asp:Button Text="Login" ID="loginbtn" OnClick="loginbtn_Click" runat="server" class="login100-form-btn" />

                            </div>
                            <div class="text-center p-t-27">

                                <a class="txt1" style="text-decoration:none" href="forgot_password.aspx">forgot password?</a>
                                <br/>
                                <a class="txt1" style="text-decoration:none" href="registration_page.aspx">Don't Have an Account Sign-Up</a>

                                <br />
                                <br />
                                <a href="becomelib.aspx" class="txt1" style="text-decoration:none;font:bold;font-size:15px">Become A Librarian</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- start js include path -->

            <script src="../../assets/plugins/jquery/jquery.min.js"></script>

            <!-- bootstrap -->

            <script src="../../assets/plugins/bootstrap/js/bootstrap.min.js"></script>
            <script src="../../assets/js/pages/extra_pages/login.js"></script>

            <!-- end js include path -->

        </div>
    </form>
</body>
</html>
