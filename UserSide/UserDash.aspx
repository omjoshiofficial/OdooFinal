<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/MainMaster.Master" AutoEventWireup="true" CodeBehind="UserDash.aspx.cs" Inherits="LibraryManagement.UserSide.UserDash" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <span class="text-primary text-uppercase">Library Management</span>
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
                                            <a class="bg-primary iq-sign-btn" href="login_page/login_page.aspx" role="button">Sign out<i class="ri-login-box-line ml-2"></i></a>
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
    <div id="content-page" class="content-page">
        <div class="container-fluid">

            <div class="row">
                <div class="col-lg-12">
                    <div class="iq-card iq-card-block iq-card-stretch iq-card-height">
                        <div class="iq-card-header d-flex justify-content-between align-items-center position-relative">
                            <div class="iq-header-title">
                                <h4 class="card-title mb-0">Browse Books</h4>
                            </div>
                            <div class="iq-card-header-toolbar d-flex align-items-center">
                                <a href="category.html" class="btn btn-sm btn-primary view-more">View More</a>
                            </div>
                        </div>
                        <div class="iq-card-body">
                             <div id="form2" runat="server">
                        <div>
                            <label for="queryInput">Enter Search Query:</label>
                            <asp:TextBox ID="queryInput" runat="server"></asp:TextBox>
                            <asp:Button ID="fetchButton" runat="server" Text="Search" OnClick="fetchButton_Click" />
                        </div>
                        <hr />
                        <div>
                            <asp:Repeater ID="booksRepeater" runat="server">
                                <ItemTemplate>
                                    <%--<div>
                        <h3><%# Eval("Title") %></h3>
                        <p><strong>Author:</strong> <%# Eval("Author") %></p>
                        <p><strong>Publisher:</strong> <%# Eval("Publisher") %></p>
                        <p><strong>Published Date:</strong> <%# Eval("PublishedDate") %></p>
                        <p><strong>Description:</strong> <%# Eval("Description") %></p>
                        <p><strong>Page Count:</strong> <%# Eval("PageCount") %></p>
                        <div>
                            <asp:Image ID="thumbnailImage" runat="server" ImageUrl='<%# Eval("Thumbnail") %>' />
                        </div>
                    </div>--%>

                                    <br />
                                    <br />
                                    <div class="col-sm-6 col-md-4 col-lg-3">
                                        <div class="iq-card iq-card-block iq-card-stretch iq-card-height browse-bookcontent">
                                            <div class="iq-card-body p-0">
                                                <div class="d-flex align-items-center">
                                                    <div class="col-6 p-0 position-relative image-overlap-shadow">
                                                        <a href="javascript:void();">
                                                            
                                                             <asp:Image ID="thumbnailImage" CssClass="img-fluid rounded w-100" runat="server" ImageUrl='<%# Eval("Thumbnail") %>' />
                                                        </a>

                                                        <div class="view-book">
                                                            <a href="OrderBook.aspx?otitle=<%# Eval("Id") %>" class="btn btn-sm btn-white">View Book</a>
                                                        </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div class="mb-2">
                                                            <h6 class="mb-1"><%# Eval("Title") %></h6>
                                                            <p class="font-size-13 line-height mb-1"><%# Eval("Author") %></p>
                                                            <div class="d-block line-height">
                                                                <span class="font-size-11 text-warning">
                                                                    <i class="fa fa-star"></i>
                                                                    <i class="fa fa-star"></i>
                                                                    <i class="fa fa-star"></i>
                                                                    <i class="fa fa-star"></i>
                                                                    <i class="fa fa-star"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="price d-flex align-items-center">
                                                            <span class="pr-1 old-price">$100</span>
                                                            <h6><b>$89</b></h6>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <hr />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
