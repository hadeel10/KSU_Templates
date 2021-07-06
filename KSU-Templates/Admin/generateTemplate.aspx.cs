using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailMessage = System.Net.Mail.MailMessage;

namespace KSU_Templates.Admin
{
    public partial class generateTemplate : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            String template = ddtemplate.Text.ToString();
            switch (template)
            {
                case "Effective Date Notice":
                    Effective_Date_Notice();
                    break;
                case "Trainee Attendance":
                    Trainee_Attendance();
                    break;
                case "Follow Up form":
                    Follow_Up_form();
                    break;
            }

        }

        protected void Effective_Date_Notice()
        {
            // code to connect to db  and pull student and institution information 
            CRUD myCrud = new CRUD();

            string mySql = @"select * from trainee 
							  
                              Inner Join major on trainee.majorId= major.majorId
							  Inner Join track on trainee.trackId= track.trackId
							  Inner Join  institution on institution.institutionId = trainee.institutionId 
							  Inner Join institutionSupervisor on institution.institutionSupervisorId=institutionSupervisor.institutionSupervisorId
							  Where institution.institutionId=1";


            SqlDataReader dr = myCrud.getDrPassSql(mySql);




            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            Object oMissing = System.Reflection.Missing.Value;
            String successful = "";



            // dr.Read() returns true if there are more rows; otherwise false.

            while (dr.Read())
            {
                document = application.Documents.Add(Template: @"C:\projects\noticeForm.dotx");

                //application.Visible = true;
                foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                {

                    if (field.Code.Text.Contains("name"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["trainee"]);

                    }
                    else if (field.Code.Text.Contains("major"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["major"]);

                    }
                    else if (field.Code.Text.Contains("track"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["track"]);

                    }
                    else if (field.Code.Text.Contains("id"))
                    {
                        int m = Convert.ToInt32(dr["id"]);
                        field.Select();
                        application.Selection.TypeText(m.ToString());

                    }
                    else if (field.Code.Text.Contains("mobile"))
                    {
                        int m = Convert.ToInt32(dr["traineeMobile"]);
                        field.Select();
                        application.Selection.TypeText(m.ToString());

                    }
                    else if (field.Code.Text.Contains("homeTelephone"))
                    {
                        int m = Convert.ToInt32(dr["homeTelephone"]);
                        field.Select();
                        application.Selection.TypeText(m.ToString());
                    }

                    else if (field.Code.Text.Contains("traineeEmail"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["traineeEmail"]);

                    }
                    else if (field.Code.Text.Contains("institution"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["institution"]);

                    }
                    else if (field.Code.Text.Contains("address"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["address"]);

                    }
                    else if (field.Code.Text.Contains("department"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["department"]);

                    }
                    else if (field.Code.Text.Contains("trainingSupervisor"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["institutionSupervisor"]);

                    }
                    else if (field.Code.Text.Contains("position"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["position"]);

                    }
                    else if (field.Code.Text.Contains("officeTelephone"))
                    {
                        int m = Convert.ToInt32(dr["officeTelephone"]);
                        field.Select();
                        application.Selection.TypeText(m.ToString());
                    }


                    else if (field.Code.Text.Contains("supervisorMobile"))
                    {
                        int m = Convert.ToInt32(dr["institutionSupervisorMobile"]);
                        field.Select();
                        application.Selection.TypeText(m.ToString());
                    }


                    else if (field.Code.Text.Contains("supervisorEmail"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["institutionSupervisorEmail"]);

                    }
                    else if (field.Code.Text.Contains("startingDate"))
                    {

                        field.Select();
                        application.Selection.TypeText((String)dr["triningStartingDate"]);

                    }
                    else if (field.Code.Text.Contains("traineeSignature"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["trainee"]);
                        // application.Selection.InlineShapes.AddPicture(@"C:\Users\altoo\Downloads\seal.jpg");
                    }

                }
                document.SaveAs2(FileName: @"C:\projects\Effective_Date_Notice.dox");

                document.Close();

                successful = sendEmailViaGmail((String)dr["traineeEmail"]);
                File.Delete(@"C:\projects\Effective_Date_Notice.dox");




            }
            if (successful.Equals("Email Send successfully"))
            {
                //Label1.Text = successful;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Emails have been sent successfully!')", true);

            }


            application.Quit();



        }

        protected void Follow_Up_form()
        {


            SqlDataReader dr = recharge_dr();
            SqlDataReader usernames_dr = CountUsernames();



            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            Object oMissing = System.Reflection.Missing.Value;
            String successful = "";
            String traineeEmail = "";



            // dr.Read() returns true if there are more rows; otherwise false.
            while (usernames_dr.Read())
            {
                dr = recharge_dr();
                document = application.Documents.Add(Template: @"C:\projects\follow-up.dotx");//B
                while (dr.Read())
                {
                    //document = application.Documents.Add(Template: @"C:\projects\follow-up.dotx"); A

                    if (dr["userName"].ToString() == usernames_dr["userName"].ToString())
                    {
                        traineeEmail = (String)dr["traineeEmail"];



                        //application.Visible = true;
                        foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                        {

                            if (field.Code.Text.Contains("name"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["trainee"]);

                            }
                            else if (field.Code.Text.Contains("id"))
                            {
                                int m = Convert.ToInt32(dr["id"]);
                                field.Select();
                                application.Selection.TypeText(m.ToString());

                            }

                            else if (field.Code.Text.Contains("institution"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["institution"]);

                            }
                            else if (field.Code.Text.Contains("startDate"))
                            {

                                field.Select();
                                application.Selection.TypeText((String)dr["triningStartingDate"]);

                            }

                            else if (field.Code.Text.Contains("supervisorName"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["institutionSupervisor"]);

                            }


                            else if (field.Code.Text.Contains("week1"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 1)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }

                            }
                            else if (field.Code.Text.Contains("week2"))
                            {
                                field.Select();
                                if (Convert.ToInt32(dr["weekId"]) == 2)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                            else if (field.Code.Text.Contains("week3"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 3)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                            else if (field.Code.Text.Contains("week4"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 4)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                            else if (field.Code.Text.Contains("week5"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 5)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                            else if (field.Code.Text.Contains("week6"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 6)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                            else if (field.Code.Text.Contains("week7"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 7)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                            else if (field.Code.Text.Contains("week8"))
                            {
                                if (Convert.ToInt32(dr["weekId"]) == 8)
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["task1"]);
                                    application.Selection.TypeText((String)dr["task2"]);
                                    application.Selection.TypeText((String)dr["task3"]);
                                    application.Selection.TypeText((String)dr["task4"]);
                                }
                            }
                        }
                    }
                }
                document.SaveAs2(FileName: @"C:\projects\follow-up.dox");
                document.Close();
                successful = sendEmailViaGmail(traineeEmail);
                File.Delete(@"C:\projects\follow-up.dox");
            }
            if (successful.Equals("Email Send successfully"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Emails have been sent successfully!')", true);
            }
            application.Quit();
        }

        protected void Trainee_Attendance()
        {
            SqlDataReader dr = recharge_dr();
            SqlDataReader usernames_dr = CountUsernames();


            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            Object oMissing = System.Reflection.Missing.Value;
            String successful = "";
            String traineeEmail = "";



            while (usernames_dr.Read())
            {
                dr = recharge_dr();
                document = application.Documents.Add(Template: @"C:\projects\attendance.dotx");
                while (dr.Read())
                {
                    if (dr["userName"].ToString() == usernames_dr["userName"].ToString())
                    {
                        traineeEmail = (String)dr["traineeEmail"];

                        foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                        {

                            if (field.Code.Text.Contains("name"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["trainee"]);

                            }
                            else if (field.Code.Text.Contains("id"))
                            {
                                int m = Convert.ToInt32(dr["id"]);
                                field.Select();
                                application.Selection.TypeText(m.ToString());

                            }

                            else if (field.Code.Text.Contains("institution"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["institution"]);

                            }
                            else if (field.Code.Text.Contains("startDate"))
                            {

                                field.Select();
                                application.Selection.TypeText((String)dr["triningStartingDate"]);

                            }

                            else if (field.Code.Text.Contains("supervisorName"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["institutionSupervisor"]);

                            }
                            else if (field.Code.Text.Contains("signature"))
                            {
                                field.Select();
                                application.Selection.TypeText((String)dr["trainee"]);
                            }
                            else if (Convert.ToInt32(dr["week"]) == 1 && Convert.ToInt32(dr["dayId"]) == 1)//row 1
                            {
                                if (field.Code.Text.Contains("w1d1Date"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["date"]);
                                }
                                else if (field.Code.Text.Contains("w1d1in"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeIn"]);
                                }
                                else if (field.Code.Text.Contains("w1d1out"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeOut"]);
                                }
                                else if (field.Code.Text.Contains("w1d1comments"))
                                {
                                    field.Select();
                                    if ((String)dr["comment"] == "")
                                        application.Selection.TypeText("None");
                                    else
                                        application.Selection.TypeText((String)dr["comment"]);
                                }

                            }

                            else if (Convert.ToInt32(dr["week"]) == 1 && Convert.ToInt32(dr["dayId"]) == 2)//row 1
                            {
                                if (field.Code.Text.Contains("w1d2Date"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["date"]);
                                }
                                else if (field.Code.Text.Contains("w1d2in"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeIn"]);
                                }
                                else if (field.Code.Text.Contains("w1d2out"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeOut"]);
                                }
                                else if (field.Code.Text.Contains("w1d2comments"))
                                {
                                    field.Select();
                                    if ((String)dr["comment"] == "")
                                        application.Selection.TypeText("None");
                                    else
                                        application.Selection.TypeText((String)dr["comment"]);
                                }

                            }
                            else if (Convert.ToInt32(dr["week"]) == 1 && Convert.ToInt32(dr["dayId"]) == 3)//row 1
                            {
                                if (field.Code.Text.Contains("w1d3Date"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["date"]);
                                }
                                else if (field.Code.Text.Contains("w1d3in"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeIn"]);
                                }
                                else if (field.Code.Text.Contains("w1d3out"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeOut"]);
                                }
                                else if (field.Code.Text.Contains("w1d3comments"))
                                {
                                    field.Select();
                                    if ((String)dr["comment"] == "")
                                        application.Selection.TypeText("None");
                                    else
                                        application.Selection.TypeText((String)dr["comment"]);
                                }

                            }
                            else if (Convert.ToInt32(dr["week"]) == 1 && Convert.ToInt32(dr["dayId"]) == 4)//row 1
                            {
                                if (field.Code.Text.Contains("w1d4Date"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["date"]);
                                }
                                else if (field.Code.Text.Contains("w1d4in"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeIn"]);
                                }
                                else if (field.Code.Text.Contains("w1d4out"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeOut"]);
                                }
                                else if (field.Code.Text.Contains("w1d4comments"))
                                {
                                    field.Select();
                                    if ((String)dr["comment"] == "")
                                        application.Selection.TypeText("None");
                                    else
                                        application.Selection.TypeText((String)dr["comment"]);
                                }

                            }
                            else if (Convert.ToInt32(dr["week"]) == 1 && Convert.ToInt32(dr["dayId"]) == 5)//row 1
                            {
                                if (field.Code.Text.Contains("w1d5Date"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["date"]);
                                }
                                else if (field.Code.Text.Contains("w1d5in"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeIn"]);
                                }
                                else if (field.Code.Text.Contains("w1d5out"))
                                {
                                    field.Select();
                                    application.Selection.TypeText((String)dr["timeOut"]);
                                }
                                else if (field.Code.Text.Contains("w1d5comments"))
                                {
                                    field.Select();
                                    if ((String)dr["comment"] == "")
                                        application.Selection.TypeText("None");
                                    else
                                        application.Selection.TypeText((String)dr["comment"]);

                                }
                            }
                        }
                    }
                }
                document.SaveAs2(FileName: @"C:\projects\attendance.dox");
                document.Close();
                successful = sendEmailViaGmail(traineeEmail);
                File.Delete(@"C:\projects\follow-up.dox");
            }

            if (successful.Equals("Email Send successfully"))
            {
                //Label1.Text = successful;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Emails have been sent successfully!')", true);
            }
            application.Quit();
        }

        protected SqlDataReader CountUsernames()
        {
            CRUD myCrud = new CRUD();
            string mySql = "";

            String template = ddtemplate.Text.ToString();
            switch (template)
            {
                case "Effective Date Notice":

                    break;
                case "Trainee Attendance":
                    mySql = @"SELECT DISTINCT userName FROM attendance";
                    break;
                case "Follow Up form":
                    mySql = @"SELECT DISTINCT userName FROM followup";
                    break;
            }

            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            return dr;
        }

        protected SqlDataReader recharge_dr()
        {
            // code to connect to db  and pull student and institution information 
            CRUD myCrud = new CRUD();
            string mySql = "";

            String template = ddtemplate.Text.ToString();
            switch (template)
            {
                case "Effective Date Notice":

                    break;
                case "Trainee Attendance":
                    mySql = @"select * from attendance 
                           Inner Join trainee on trainee.userName= attendance.userName
                           Inner Join institution on institution.institutionId = trainee.institutionId
                           Inner join institutionSupervisor on institutionSupervisor.institutionSupervisorId= institution.institutionSupervisorId";
                    break;
                case "Follow Up form":
                    mySql = @"select * from followup 
                           Inner Join trainee on trainee.userName= followup.userName
                           Inner Join institution on institution.institutionId = trainee.institutionId
                           Inner join institutionSupervisor on institutionSupervisor.institutionSupervisorId= institution.institutionSupervisorId";

                    break;
            }


            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            return dr;
        }

        public string sendEmailViaGmail(String traineeEmail) // worked 100%, this is a nice one use it with  properties
        {
            string myFrom = "ksu.templates@gmail.com"; // put your email account (from )
            string myTo = traineeEmail; // put your email account (to )
            string mySubject = "KSU Templates";
            string myBody = "Hi, You can find your trining form in the attachments in this email! , Thank You for using KSU Templates";

            string myHostsmtpAddress = "smtp.gmail.com";//"smtp.mail.yahoo.com";  //mail.wdbcs.com 
            int myPortNumber = 587;
            bool myEnableSSL = true;
            string myUserName = "ksu.templates@gmail.com";//;
            string myPassword = "KFMC123456";//;

            //string visitorUserName = Page.User.Identity.Name;
            using (MailMessage m = new MailMessage(myFrom, myTo, mySubject, myBody)) // .............................1
            {
                SmtpClient sc = new SmtpClient(myHostsmtpAddress, myPortNumber); //..................................2
                try
                {

                    System.Net.Mail.Attachment attachment;
                    String template = ddtemplate.Text.ToString();
                    switch (template)
                    {
                        case "Effective Date Notice":
                            attachment = new System.Net.Mail.Attachment(@"C:\projects\Effective_Date_Notice.dox");
                            break;
                        case "Trainee Attendance":
                            attachment = new System.Net.Mail.Attachment(@"C:\projects\attendance.dox");
                            break;
                        case "Follow Up form":
                            attachment = new System.Net.Mail.Attachment(@"C:\projects\follow-up.dox");
                            break;

                        default:
                            attachment = new System.Net.Mail.Attachment(@"C:\projects\Effective_Date_Notice.dox");
                            break;

                    }
                    m.Attachments.Add(attachment);




                    sc.Credentials = new System.Net.NetworkCredential(myUserName, myPassword);  //.................3
                    sc.EnableSsl = true;
                    sc.Send(m);
                    return "Email Send successfully";
                }
                catch (SmtpFailedRecipientException ex)
                {
                    SmtpStatusCode statusCode = ex.StatusCode;
                    if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                    {   // wait 5 seconds, try a second time
                        Thread.Sleep(5000);
                        sc.Send(m);
                        return ex.Message.ToString();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    m.Dispose();
                }
            }// end using 
        }


        protected void DownloadImage()
        {
            CRUD myCrud = new CRUD();

            string mySql = @"select * from trainee 
							  
							  Inner Join  institution on institution.institutionId = trainee.institutionId 
							  Inner Join institutionSupervisor on institution.institutionSupervisorId=institutionSupervisor.institutionSupervisorId
							  Where institution.institutionId=1";


            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            byte[] seal = null;
            byte[] tSignature = null;
            byte[] sSignature = null;
            ////////////////////////
            while (dr.Read())
            {
                seal = (byte[])dr["institutionSeal"];
                sSignature = (byte[])dr["institutionSupervisorSignature"];
                if (dr["traineeSignature"] != null)
                {
                    tSignature = (byte[])dr["traineeSignature"];
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + dr["userName"].ToString() + "Signature.jpg");
                    Response.BinaryWrite(tSignature);//var
                    Response.Flush();
                }

            }
            ////////////////////
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AppendHeader("Content-Disposition", "attachment; filename=seal.jpg");
            Response.BinaryWrite(seal);//var
            Response.Flush();
            ///////////////////
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AppendHeader("Content-Disposition", "attachment; filename=supervisorSignature.jpg");
            Response.BinaryWrite(sSignature);//var
            Response.Flush();



        }

        protected void download_Click(object sender, EventArgs e)
        {
            DownloadImage();
        }
    }

}