<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="noticeForm.aspx.cs" Inherits="KSU_Templates.Student.Templates.noticeForm" %>
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
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Effective Date Notice Form</h2>
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
                                        <h3 class="heading">Trainee's information</h3>
                                        <p>Please enter your infomation.  </p>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Name</legend>
                                                <asp:TextBox ID="txtName" placeholder="Name" class="form-control" runat="server"></asp:TextBox>
                                                 </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>ID</legend>
                                                <asp:TextBox ID="txtId" placeholder="ID" class="form-control" runat="server" ></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <asp:DropDownList ID="major" runat="server" DataSourceID="SqlDataSource1" DataTextField="major" DataValueField="majorId"></asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KSU_Templates_ConStr %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
                                            <%--<select name="major" ID="major">
                                                    <option value="major" disabled selected>Major</option>
                                                    <option value="1">IT</option>
                                                    <option value="2">CS</option>
                                                    <option value="3">SWE</option>
                                                    <option value="4">IS</option>
                                                </select>--%>
                                          
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                          
                                            <asp:DropDownList ID="track" runat="server" DataSourceID="SqlDataSource2" DataTextField="track" DataValueField="trackId"></asp:DropDownList>
                                               <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:KSU_Templates_ConStr %>" SelectCommand="SELECT * FROM [track]"></asp:SqlDataSource>
                                            <%-- <select name="track" ID="track">
                                                    <option value="track" disabled selected>Track</option>
                                                    <option value="1">Network & Security</option>
                                                    <option value="2">Data Management</option>
                                                    <option value="3">Web Technologies & Multimedia</option>
                                                    <option value="4">Cyber Security</option>
                                                    <option value="5">Data Science</option>
                                                    <option value="6">Networks & Internet of Things</option>
                                                </select>--%>
                                        
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>E-mail</legend>
                                                <asp:TextBox ID="txtEmail" placeholder="Email" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Mobile</legend>
                                                <asp:TextBox ID="txtMobile" placeholder="Mobile" runat="server" TextMode="Phone" class="form-control"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Home-Telephone</legend>
                                                <asp:TextBox ID="txtHomeTelephone" placeholder="Home-Telephone" runat="server" TextMode="Phone" class="form-control"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <hr />
                                     <div class="wizard-header">
                                        <h3 class="heading">University Supervisor</h3>
                                        <p>Please enter your university supervisor infomation.</p>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Name</legend>
                                                <asp:TextBox ID="usName" placeholder="Name" class="form-control" runat="server" ></asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>E-mail</legend>
                                                <asp:TextBox ID="usEmail" placeholder="Email" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <hr />
                                     <div class="wizard-header">
                                        <h3 class="heading">Training's information</h3>
                                        <p>Please enter your training infomation.  </p>
                                    </div>

                                     <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                          
                                            <asp:DropDownList ID="ddInstitution" runat="server" class="form-control" placeholder="Institution" DataSourceID="SqlDataSource3" DataTextField="institution" DataValueField="institutionId"></asp:DropDownList>
                                        
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:KSU_Templates_ConStr %>" SelectCommand="SELECT [institutionId], [institution] FROM [institution]"></asp:SqlDataSource>
                                        
                                        </div>
                                    </div>

                                    <div class="form-row form-row-date">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                 <legend>Starting Date <asp:Label ID="startDateError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
                                           <asp:TextBox class="input100" textmode="Date" type="text" name="startingDate" id="startingDate" runat="server"></asp:TextBox>
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
                                 <asp:Button class="login100-form-btn" Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" ></asp:Button>
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
