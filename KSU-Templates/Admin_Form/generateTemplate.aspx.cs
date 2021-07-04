using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using KSU_Templates.App_Code;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailMessage = System.Net.Mail.MailMessage;

namespace KSU_Templates.Admin_Form
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

                    break;
                case "Follow Up form":

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
							  Where institution.institutionId=@institutionId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@institutionId", 1);

            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);


            // gvInternData.DataSource = dr;
            // gvInternData.DataBind();

            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            Object oMissing = System.Reflection.Missing.Value;


            // dr.Read() returns true if there are more rows; otherwise false.
            int i = 1;

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
                    else if (field.Code.Text.Contains("institutionSeal"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["institutionSeal"]);

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
                    else if (field.Code.Text.Contains("supervisorSignature"))
                    {
                        field.Select();
                        application.Selection.TypeText("xxxxxxxxx");

                    }
                    else if (field.Code.Text.Contains("startingDate"))
                    {

                        field.Select();
                        application.Selection.TypeText((String)dr["triningStartingDate"]);

                    }
                    else if (field.Code.Text.Contains("traineeSignature"))
                    {
                        field.Select();
                        application.Selection.TypeText("ssss");

                    }

                }
                //document.SaveAs2(FileName: @"C:\projects\Effective_Date_Notice2.pdf");
                document.SaveAs2(FileName: @"C:\projects\Effective_Date_Notice.dox");

                document.Close();
                ++i;
                Label1.Text = sendEmailViaGmail((String)dr["traineeEmail"]);
                File.Delete(@"C:\projects\Effective_Date_Notice.dox");




            }
            
            application.Quit();



        }

       
     

        public string sendEmailViaGmail( String traineeEmail) // worked 100%, this is a nice one use it with  properties
        {
            string myFrom = "ksu.templates@gmail.com"; // put your email account (from )
            string myTo = traineeEmail; // put your email account (to )
            string mySubject = "test sending email ";
            string myBody = " email message content";

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
                    attachment = new System.Net.Mail.Attachment(@"C:\projects\Effective_Date_Notice.dox");
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

        


    }

}
