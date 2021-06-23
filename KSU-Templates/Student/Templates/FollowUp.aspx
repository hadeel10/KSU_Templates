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
                <i class="fas fa-star"></i></div>
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
                                                <input type="text" class="form-control" id="txtName" name="name" placeholder="Name" runat="server">
                                            </fieldset>
                                        </div>
                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>ID</legend>
                                                <input type="text" class="form-control" id="id" name="id" placeholder="ID" runat="server">
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Institution</legend>
                                                <input type="text" name="institution" id="institution" class="form-control" placeholder="Institution" runat="server">
                                            </fieldset>
                                        </div>
                                    </div>
                               
                                    <div class="form-row form-row-date">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Starting Date:</label>
                                                <select name="year" id="year">
                                                <option value="YYYY" disabled selected>YYYY</option>
                                                <option value="2025">2025</option>
                                                <option value="2024">2024</option>
                                                <option value="2023">2023</option>
                                                <option value="2022">2022</option>
                                                <option value="2021">2021</option>
                                            </select>
                                            <select name="month" id="month">
                                                <option value="MM" disabled selected>MM</option>
                                                <option value="Feb">Jan</option>
                                                <option value="Feb">Feb</option>
                                                <option value="Mar">Mar</option>
                                                <option value="Apr">Apr</option>
                                                <option value="May">May</option>
                                                 <option value="Jun">Jun</option>
                                                 <option value="Jul">Jul</option>
                                                 <option value="Aug">Aug</option>
                                                 <option value="Sep">Sep</option>
                                                 <option value="Oct">Oct</option>
                                                 <option value="Nov">Nov</option>
                                                 <option value="Dec">Dec</option>
                                               

                                            </select>
                                            <select name="date" id="date">
                                                <option value="DD" disabled selected>DD</option>
                                                 <option value="9">9</option>
                                                 <option value="10">10</option>
                                                 <option value="11">11</option>
                                                 <option value="12">12</option>
                                                 <option value="13">13</option>
                                                 <option value="14">14</option>
                                                <option value="15">15</option>
                                                 <option value="16">16</option>
                                                <option value="17">17</option>
                                                <option value="18">18</option>
                                                <option value="19">19</option>
                                            </select>
                         
                                        </div>
                                    </div>


                                    <div class="wizard-header">
                                        <h3 class="heading">Assigned Task</h3>
                                        <p>Filled by trainee and signed by supervisor </p>
                                    </div>


                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task1:</label>

                                            <textarea name="task1" id="task1" class="form-control" placeholder="Write your task1 here..." runat="server" ></textarea>

                                        </div>
                                    </div>

                                    
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task2:</label>

                                            <textarea name="task2" id="task2" class="form-control" placeholder="Write your task2 here..." runat="server" ></textarea>

                                        </div>
                                    </div>


                                    
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Task3:</label>

                                            <textarea name="task3" id="task3" class="form-control" placeholder="Write your task3 here..." runat="server" ></textarea>

                                        </div>
                                    </div>


                                    
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Tas4:</label>

                                            <textarea name="task4" id="task4" class="form-control" placeholder="Write your task4 here..." runat="server" ></textarea>

                                        </div>
                                    </div>

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
    <%-- <h2 class="page-section-heading text-center mb-0" style="color:#467bc7;">Trainee's information</h2>
    <br />
    <br />
    <br />
    <table style="margin-left: auto; margin-right: auto;">
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
        <tr>
            <td>
                	<div class="wrap-input100 validate-input" data-validate = "Enter Name" id="userError" runat="server">
						<asp:TextBox class="input100" type="text" name="username" placeholder="name" id="uName" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>

					</div>

            </td>
                        <td style="padding: 0 100px;"></td>

              <td>
                	<div class="wrap-input100 validate-input" data-validate = "Enter ID" id="Div1" runat="server">
						<asp:TextBox class="input100" type="text" name="id" placeholder="ID" id="TextBox1" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe822;"></span>

					</div>

            </td>
        </tr>
         <tr>
            <td>
                	<div class="wrap-input100 validate-input" data-validate = "Enter Institution Name" id="Div2" runat="server">
						<asp:TextBox class="input100" type="text" name="institution" placeholder="institution" id="TextBox2" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe801;"></span>

					</div>

            </td>
                        <td style="padding: 0 100px;"></td>

              <td>
                	<div class="wrap-input100 validate-input" data-validate = "Enter Starting Date" id="Div3" runat="server">
						<asp:TextBox class="input100" type="text" name="startingDate" placeholder="Starting date" id="TextBox3" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe836;"></span>

					</div>

            </td>
        </tr>

    </table>
     <br />
    <br />
     <h2 class="page-section-heading text-center mb-0" style="color:#467bc7;">Assigned Tasks</h2>
     <br />
    <br />
     <br />
   <table style="margin-left: auto; margin-right: auto;">
       <tr>
        <td>
                	<div class="wrap-input100 validate-input" data-validate = "Task 1" id="Div4" runat="server">
						<textarea class="input100" type="text" name="task1" placeholder="Task 1" id="TextBox4" runat="server"></textarea>
						<span class="focus-input100" data-placeholder="&#xe802;"></span>

					</div>

            </td>
                        <td style="padding: 0 100px;"></td>
            <td>
                	<div class="wrap-input100 validate-input" data-validate = "Task 2" id="Div5" runat="server">
						<textarea class="input100" type="text" name="task2" placeholder="Task 2" id="Textarea1" runat="server"></textarea>
						<span class="focus-input100" data-placeholder="&#xe802;"></span>

					</div>

            </td>
           </tr>

   </table>--%>
</asp:Content>
