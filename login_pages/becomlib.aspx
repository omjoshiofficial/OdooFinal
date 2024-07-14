<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="becomlib.aspx.cs" Inherits="LibraryManagement.login_pages.becomlib" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <!-- google font -->
    <link href="https://fonts.googleapis.com/css?family=poppins:300,400,500,600,700" rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="assets/plugins/iconic/css/material-design-iconic-font.min.css" />
    <!-- bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- style -->
    <link rel="stylesheet" href="assets/css/pages/extra_pages.css" />
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
                            <span class="login100-form-title p-b-34 p-t-27">Provide Your Role
                            </span>

                            <div class="wrap-input100 validate-input" data-validate="enter email">

                                <asp:TextBox runat="server" ID="email" class="input100" placeholder="Email" />

                                <span class="focus-input100" data-placeholder="&#xf207;"></span>

                            </div>


                            <div class="container-login100-form-btn">

                                <asp:Button Text="Send Request" ID="loginbtn" runat="server" OnClick="loginbtn_Click" Visible="true" class="login100-form-btn" />
                                <asp:Button Text=" Within 24 hours You will be a Member of System " ID="textbtn" runat="server" Visible="false"  class="login100-form-btn" />

                            </div>
                            <div class="text-center p-t-27">
                                <a class="txt1" style="text-decoration: none;font-size:15px" href="../login_pages/Login.aspx">Go To Login Page</a>
                                <br />
                                <a class="txt1" style="text-decoration: none;font-size:15px" href="../login_pages/Registration.aspx">Go To Registration Page</a>
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
