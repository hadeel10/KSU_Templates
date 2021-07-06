<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="generateTemplate.aspx.cs" Inherits="KSU_Templates.Admin.generateTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <head>
        <title>Home Page V16</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!--===============================================================================================-->
        <link rel="icon" type="image/png" href="/images/icons/favicon.ico" />
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/animate/animate.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/css-hamburgers/hamburgers.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/animsition/css/animsition.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/select2/select2.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/daterangepicker/daterangepicker.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/css/util.css">
        <link rel="stylesheet" type="text/css" href="/css/main.css">
        <!--===============================================================================================-->
        <!-- Font-->
        <link rel="stylesheet" type="text/css" href="/Form_styles/css/opensans-font.css">
        <link rel="stylesheet" type="text/css" href="/Form_styles/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css">
        <!-- Main Style Css -->
        <link rel="stylesheet" href="/Form_styles/css/style.css" />
    </head>


    <!-- Header -->
    <div class="limiter">
        <div class="container-login100" style="background-image: url('/images/bg-01.jpg');">
            <div class="container d-flex align-items-center flex-column">
                <!-- Header Heading -->
                <h1 class="masthead-heading text-uppercase mb-0" style="color: #ffffff; font-size: 70px">KSU Templetes</h1>
                <!-- Icon Divider -->
                <div class="divider-custom divider-light">
                    <div class="divider-custom-line"></div>
                    <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
                    <div class="divider-custom-line"></div>
                </div>
                <!-- header Subheading -->
                <p class="masthead-subheading font-weight-light mb-0" style="color: #ffffff; font-size: x-large">Effective Date Notice - Trainee Attendance - Follow Up form</p>
            </div>
        </div>
    </div>
    <!-- Follow up Temaplate Section-->
    <section class="page-section" style="background-color: rgba(44, 62, 80,0.1);" id="follow-up">

        <!-- Contact Section Heading-->
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Templates Generation</h2>
        <!-- Icon Divider-->
        <div class="divider-custom">
            <div class="divider-custom-line"></div>
            <div class="divider-custom-icon">
                <i class="fas fa-star"></i>
            </div>
            <div class="divider-custom-line"></div>
        </div>

        <div class="page-content">
            <div class="form-v1-content">
                <div class="wizard-form">
                    <div class="form-register">
                        <div id="form-total">
                            <!-- SECTION 1 -->
                            <h2></h2>
                            <section>
                                <div class="inner">
                                   <%-- <div class="wizard-header">
                                        <h3 class="heading">Signaturs</h3>
                                        <p>Please download the trainees signature before choose a template</p>
                                    </div>

                                    <div class="form-row">
                                        <div class="container-login100-form-btn m-t-32">
                                 <asp:Button class="login100-form-btn" Text="Download" runat="server" ID="download" OnClick="download_Click"  ></asp:Button>
                                        </div>
                                    </div>
                                    <hr />--%>
                                    <div class="wizard-header">
                                        <h3 class="heading">Templetes</h3>
                                        <p>Please choose a template to send via email to trainees and thier supervisors  </p>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                             <legend>Templates</legend>
                                            <asp:DropDownList ID="ddtemplate" runat="server">
                                                <asp:ListItem Enabled="False" Selected="True">choose...</asp:ListItem>
                                                <asp:ListItem>Effective Date Notice</asp:ListItem>
                                                <asp:ListItem>Trainee Attendance</asp:ListItem>
                                                <asp:ListItem>Follow Up form</asp:ListItem>
                                             </asp:DropDownList>
                                          
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="container-login100-form-btn m-t-32">
                                 <asp:Button class="login100-form-btn" Text="Send" runat="server" ID="btnSend" OnClick="btnSend_Click"  ></asp:Button>
                                        </div>
                                    </div>
                                    
                                    <br />
                                    <br />
                                </div>
                            </section>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="/Form_styles/js/jquery-3.3.1.min.js"></script>
    <script src="/Form_styles/js/jquery.steps.js"></script>
    <script src="/Form_styles/js/main.js"></script>

</asp:Content>

