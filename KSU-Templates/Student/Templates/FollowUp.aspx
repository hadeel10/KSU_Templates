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
    <script type="text/javascript">
          function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                     $('#<%=oldSignature.ClientID%>').hide();
                    $('#<%=newSignature.ClientID%>').show();
                    $('#<%=newSignature.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }

    </script>

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
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Follow up Form</h2>
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
                                                <legend>Name<asp:Label ID="nameError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
                                                <asp:TextBox class="form-control" ID="txtName" placeholder="Name" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>ID<asp:Label ID="idError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
                                                <asp:TextBox class="form-control" ID="txtId" placeholder="ID" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>
                                      <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Institution<asp:Label ID="institutionError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
                                                <input type="text" name="institution" id="txtInstitution" class="form-control" placeholder="Institution" readonly runat="server" style="background-color:white">
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
                                    <div class="wizard-header">
                                        <h3 class="heading">Assigned Task</h3>
                                        <p>Filled by trainee and signed by supervisor </p>
                                    </div>

                                    <%--Week Number--%>
                                    <div class="form-row form-row-date">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Week:  <asp:Label ID="weekError" runat="server" Text=" *" style="color:red; font-size:16px" Visible="false"></asp:Label></label>
                                            <asp:DropDownList CssClass="form-control" name="week" ID="ddlWeek" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                    

                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task1: <asp:Label ID="task1Error" runat="server" Text=" *" style="color:red; font-size:16px" Visible="false"></asp:Label></label>

                                            <asp:TextBox ID="task1" TextMode="MultiLine" class="form-control" placeholder="Write your task1 here..." runat="server"></asp:TextBox>

                                        </div>
                                    </div>


                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task2:</label>

                                            <asp:TextBox ID="task2" TextMode="MultiLine" class="form-control" placeholder="Write your task2 here..." runat="server"></asp:TextBox>

                                        </div>
                                    </div>



                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task3:</label>

                                            <asp:TextBox ID="task3" TextMode="MultiLine" class="form-control" placeholder="Write your task3 here..." runat="server"></asp:TextBox>

                                        </div>
                                    </div>



                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task4:</label>

                                            <asp:TextBox ID="task4" TextMode="MultiLine" class="form-control" placeholder="Write your task4 here..." runat="server"></asp:TextBox>

                                        </div>
                                    </div>


                                    <%--Signature upload--%>
                                    <div class="wizard-header">
                                        <h3 class="heading">Signature upload</h3>
                                        <p>Please upload your Signature </p>

                                        <br />
                                        <asp:FileUpload id="FileUpload1" runat="server" onchange="ImagePreview(this);" BackColor="#2c3e50" ForeColor="White" BorderColor="#2c3e50e" />
                                    </div>

                                  <div class="wizard-header" id="imageDiv">
                                      <asp:Image ID="oldSignature" Visible="false" runat="server" Height="200" Width="200" />
                                    <asp:Image ID="newSignature" style="display:none"  runat="server" Height="120px" Width="117px" />
                                        </div>

                                    <%--Submit button--%>
                                    <div class="form-row">
                                        <div class="container-login100-form-btn m-t-32">
                                            <asp:Button class="login100-form-btn" Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click"></asp:Button>
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
