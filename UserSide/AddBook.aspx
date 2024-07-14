<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/MainMaster.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryManagement.UserSide.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <!-- TOP Nav Bar -->
    <div class="iq-top-navbar">
        <div class="iq-navbar-custom">
            <nav class="navbar navbar-expand-lg navbar-light p-0">
                <div class="iq-menu-bt d-flex align-items-center">
                    <div class="wrapper-menu">
                        <div class="main-circle"><i class="las la-bars"></i></div>
                    </div>
                    <div class="iq-navbar-logo d-flex justify-content-between">
                        <a href="index.html" class="header-logo">
                            <img src="images/logo.png" class="img-fluid rounded-normal" alt="">
                            <div class="logo-title">
                                <span class="text-primary text-uppercase">Exam Helper</span>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="navbar-breadcrumb">
                    <h5 class="mb-0">Public Library</h5>
                    
                </div>
                
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-label="Toggle navigation">
                    <i class="ri-menu-3-line"></i>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto navbar-list">

                        <li class="line-height pt-3">
                            <a href="#" class="search-toggle iq-waves-effect d-flex align-items-center">
                                <i class="fa fa-user m-2" style="font-size: 28px"></i>
                                <div class="caption">
                                    <h6 class="mb-1 line-height" id="User_cookie" runat="server"></h6>
                                </div>
                            </a>
                            <div class="iq-sub-dropdown iq-user-dropdown">
                                <div class="iq-card shadow-none m-0">
                                    <div class="iq-card-body p-0 ">
                                        <div class="bg-primary p-3">
                                            <h5 class="mb-0 text-white line-height">Hello</h5>
                                            <span class="text-white font-size-12" id="sub_user_cookie" runat="server"></span>
                                        </div>
                                        <a href="#" class="iq-sub-card iq-bg-primary-hover">
                                            <div class="media align-items-center">
                                                <div class="rounded iq-card-icon iq-bg-primary">
                                                    <i class="ri-file-user-line"></i>
                                                </div>
                                                <div class="media-body ml-3">
                                                    <h6 class="mb-0 ">My Profile</h6>
                                                    <p class="mb-0 font-size-12">View personal profile details.</p>
                                                </div>
                                            </div>
                                        </a>
                                        <a href="#" class="iq-sub-card iq-bg-primary-hover">
                                            <div class="media align-items-center">
                                                <div class="rounded iq-card-icon iq-bg-primary">
                                                    <i class="ri-profile-line"></i>
                                                </div>
                                                <div class="media-body ml-3">
                                                    <h6 class="mb-0 ">Edit Profile</h6>
                                                    <p class="mb-0 font-size-12">Modify your personal details.</p>
                                                </div>
                                            </div>
                                        </a>
                                        <a href="#" class="iq-sub-card iq-bg-primary-hover">
                                            <div class="media align-items-center">
                                                <div class="rounded iq-card-icon iq-bg-primary">
                                                    <i class="ri-account-box-line"></i>
                                                </div>
                                                <div class="media-body ml-3">
                                                    <h6 class="mb-0 ">Account settings</h6>
                                                    <p class="mb-0 font-size-12">Manage your account parameters.</p>
                                                </div>
                                            </div>
                                        </a>
                                        <a href="#" class="iq-sub-card iq-bg-primary-hover">
                                            <div class="media align-items-center">
                                                <div class="rounded iq-card-icon iq-bg-primary">
                                                    <i class="ri-lock-line"></i>
                                                </div>
                                                <div class="media-body ml-3">
                                                    <h6 class="mb-0 ">Privacy Settings</h6>
                                                    <p class="mb-0 font-size-12">Control your privacy parameters.</p>
                                                </div>
                                            </div>
                                        </a>
                                        <div class="d-inline-block w-100 text-center p-3">
                                            <a class="bg-primary iq-sign-btn" href="login_page/loginLibrary.aspx" role="button">Sign out<i class="ri-login-box-line ml-2"></i></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    </div>
    <!-- TOP Nav Bar END -->

    <!-- Page Content  -->
    <div id="content-page" class="content-page">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12">
                    <div class="iq-card">
                        <div class="iq-card-header d-flex justify-content-between">
                            <div class="iq-header-title">
                                <h4 class="card-title">Add Book</h4>
                            </div>
                        </div>

                        <div class="iq-card-body">
                            <div>

                                <div class="form-group">

                                    <label>ISBN:</label>
                                    <asp:TextBox ID="isbntxt" class="form-control" runat="server" />

                                </div>

                                <div class="form-group">

                                    <label>Title:</label>
                                    <asp:TextBox ID="titletx" class="form-control" runat="server" />

                                </div>

                                <div class="form-group">

                                    <label>Author:</label>
                                    <asp:TextBox ID="authortxt" class="form-control" runat="server" />

                                </div>

                                <div class="form-group">

                                    <label>Publisher:</label>
                                    <asp:TextBox ID="publishertxt" class="form-control" runat="server" />

                                </div>

                                <div class="form-group">

                                    <label>Year:</label>
                                    <asp:TextBox ID="yeartxt" class="form-control" runat="server" />

                                </div>

                                <div class="form-group">

                                    <label>Genre:</label>
                                    <asp:DropDownList ID="genretxt" runat="server">
                                        <asp:ListItem Text="---Select Genre ---" />
                                        <asp:ListItem Text="romance" />
                                        <asp:ListItem Text="horror" />
                                        <asp:ListItem Text="thriller" />
                                    </asp:DropDownList>

                                </div>

                                <div class="form-group">

                                    <label>Quantity:</label>
                                    <asp:TextBox ID="quantitytxt" class="form-control" runat="server" />

                                </div>

                                <div class="form-group">
                                    <label>Book Image:</label>
                                    <div class="custom-file">
                                        <asp:FileUpload runat="server" ID="bookimg" Style="width: 80%; background-color: ghostwhite" />

                                        <%--<label class="custom-file-label" style="width:80%">Choose file</label>--%>
                                        <asp:Image ImageUrl="imageurl" ID="bookimgurl" Style="height: 60px; width: 60px; border: 1px solid silver; border-radius: 5px" runat="server" />

                                    </div>


                                </div>
                                
                                <asp:Button Text="Submit" CssClass="btn btn-primary" ID="btn_submit_book" OnClick="btn_submit_book_Click" runat="server" />
                                
                                <button type="reset" class="btn btn-danger">Cancle</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Wrapper END -->



</asp:Content>
