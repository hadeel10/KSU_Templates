<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FollowUp.aspx.cs" Inherits="KSU_Templates.Templates.FollowUp" %>

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
                <p class="masthead-subheading font-weight-light mb-0" style="color: #ffffff; font-size: x-large">Training Plan - Effective Date Notice - Trainee Attendance - Follow Up form</p>
            </div>
        </div>
    </div>
    <!-- Follow up Temaplate Section-->
    <section class="page-section" id="contact">
        <div class="container">
            <!-- Contact Section Heading-->
            <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Follow up Form</h2>
            <!-- Icon Divider-->
            <div class="divider-custom">
                <div class="divider-custom-line"></div>
                <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
                <div class="divider-custom-line"></div>
            </div>
        </div>
    </section>
   <%-- <h2 class="page-section-heading text-center text-secondary mb-0">Trainee's information</h2>--%>
    <br />
    <br />
    <br />
  <%--  <table style="margin-left: auto; margin-right: auto;">
        <tr>
            <td>
                <!-- Name input-->
                <div class="form-floating mb-3">
                    <input class="form-control" id="name" type="text" placeholder="Enter your name..." data-sb-validations="required" />
                    <label for="name">Name</label>
                    <div class="invalid-feedback" data-sb-feedback="name:required">A name is required.</div>
                </div>
            </td>
            <td style="padding: 0 100px;"></td>
            <td>
                <!-- ID input-->
                <div class="form-floating mb-3">
                    <input class="form-control" id="id" type="text" placeholder="Enter your ID..." data-sb-validations="required" />
                    <label for="name">ID</label>
                    <div class="invalid-feedback" data-sb-feedback="name:required">An ID is required.</div>
                </div>
            </td>
        </tr>
          <tr>
            <td>
                <!-- Institution input-->
                <div class="form-floating mb-3">
                    <input class="form-control" id="name" type="text" placeholder="Enter your name..." data-sb-validations="required" />
                    <label for="name">Name</label>
                    <div class="invalid-feedback" data-sb-feedback="name:required">A name is required.</div>
                </div>
            </td>
            <td style="padding: 0 100px;"></td>
            <td>
                <!-- Startin Date input-->
                <div class="form-floating mb-3">
                    <input class="form-control" id="id" type="text" placeholder="Enter your ID..." data-sb-validations="required" />
                    <label for="name">ID</label>
                    <div class="invalid-feedback" data-sb-feedback="name:required">An ID is required.</div>
                </div>
            </td>
        </tr>

    </table>--%>

</asp:Content>
