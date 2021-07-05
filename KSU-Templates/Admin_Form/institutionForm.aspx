<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="institutionForm.aspx.cs" Inherits="KSU_Templates.Admin_Form.WebForm1" %>

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
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Update Information</h2>
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
                                    <div class="wizard-header">
                                        
                                        <h3 class="heading">Institution's information</h3>
                                        <%-- <p>Please enter your infomation.  </p>--%>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Institution's Name</legend>
                                                <asp:TextBox ID="name" placeholder="Name" class="form-control" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Address </legend>
                                                <asp:TextBox ID="address" placeholder="Address" class="form-control" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Department</legend>
                                                <asp:TextBox ID="department" placeholder="Department" class="form-control" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>


                                                 <%--Seal upload--%>
                                    <div class="wizard-header">
                                        <h3 class="heading">Institution's seal upload</h3>
                                        <p>Please upload the Institution's seal</p>

                                        <br />
                                        <asp:FileUpload ID="FileUpload2" runat="server" onchange="ImagePreview(this);" BackColor="#2c3e50" ForeColor="White" BorderColor="#2c3e50e" />
                                    </div>

                                    <div class="wizard-header" id="imageDiv">
                                        <asp:Image ID="oldSeal" Visible="false" runat="server" Height="200" Width="200" />
                                        <asp:Image ID="newSeal" Style="display: none" runat="server" Height="120px" Width="117px" />
                                    </div>
                                   
                                    <hr />
                                    <div class="wizard-header">
                                        <h3 class="heading">Training Supervisor's information</h3>
                                        <%-- <p>Please enter your infomation.  </p>--%>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Supervisor's Name</legend>
                                                <asp:TextBox ID="tsName" placeholder="Name" class="form-control" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Position</legend>
                                                <asp:TextBox ID="position" placeholder="Position" class="form-control" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Mobile</legend>
                                                <asp:TextBox ID="mobile" placeholder="Mobile" runat="server" TextMode="Phone" class="form-control"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Office-Telephone</legend>
                                                <asp:TextBox ID="officeTelephone" placeholder="Office-Telephone" runat="server" TextMode="Phone" class="form-control"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Supervisor's E-mail</legend>
                                                <asp:TextBox ID="tsEmail" placeholder="Email" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>

                                                 <%--Signature upload--%>
                                    <div class="wizard-header">
                                        <h3 class="heading">Signature upload</h3>
                                        <p>Please upload your Signature </p>

                                        <br />
                                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="ImagePreview(this);" BackColor="#2c3e50" ForeColor="White" BorderColor="#2c3e50e" />
                                    </div>

                                    <div class="wizard-header" id="imageDiv">
                                        <asp:Image ID="oldSignature" Visible="false" runat="server" Height="200" Width="200" />
                                        <asp:Image ID="newSignature" Style="display: none" runat="server" Height="120px" Width="117px" />
                                    </div>




                                    <div class="form-row">
                                        <div class="container-login100-form-btn m-t-32">
                                            <asp:Button class="login100-form-btn" Text="Update" runat="server" ID="btnUbdate" OnClick="btnUbdate_Click"></asp:Button>
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
