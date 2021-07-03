<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KSU_Templates.Contact" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <head>
        <title>Contact V16</title>
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

        <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

    </head>
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
       <section class="page-section" style="background-color: rgba(44, 62, 80,0.1);" id="follow-up">

        <!-- Followup Section Heading-->
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Contact us</h2>
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
                            <h2></h2>
                            <section>
                                <div class="inner">
                                    <div class="wizard-header">
                                        <h3 class="heading">Trainee's information</h3>
                                        <p>Please enter your infomation.  </p>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Institution<asp:Label ID="institutionError" runat="server" Text="  *" Style="color: red; font-size: 16px" Visible="false"></asp:Label></legend>
                                                <input type="text" name="institution" id="txtInstitution" class="form-control" placeholder="Institution" readonly runat="server" style="background-color: white">
                                            </fieldset>
                                        </div>
                                    </div>

                                    <%--Starting date--%>
                                    <div class="form-row form-row-date">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Starting Date
                                                    <asp:Label ID="startDateError" runat="server" Text="  *" Style="color: red; font-size: 16px" Visible="false"></asp:Label></legend>
                                                <asp:TextBox class="input100" TextMode="Date" type="text" name="startingDate" ID="startingDate" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>

                                    <%--Assigned Task--%>
                                    <div class="wizard-header" id="assignedTask">
                                        <h3 class="heading">Assigned Task</h3>
                                        <p>Filled by trainee and signed by supervisor </p>
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
