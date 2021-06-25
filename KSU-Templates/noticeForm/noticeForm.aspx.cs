
using KSU_TemplatesConnectionString.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.noticeForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void generate_Click(object sender, EventArgs e)
        {
            // code to connect to db  and pull student and institution information 
            CRUD myCrud = new CRUD();

            string mySql = @"select * from institution 
							  Inner Join institutionSupervisor on institution.institutionSupervisorId=institutionSupervisor.institutionSupervisorId
                              Inner Join  trainee on institution.institutionId = trainee.institutionId 
							  Inner Join major on trainee.majorId= major.majorId
							  Inner Join track on trainee.trackId= track.trackId
                             where trainee.id=@traineeId And institution.institutionId=@institutionId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@institutionId", ddInstitution.SelectedValue);
            myPara.Add("@traineeId", tId.Text);

            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);


            // gvInternData.DataSource = dr;
            // gvInternData.DataBind();

            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();

            document = application.Documents.Add(Template: @"C:\projects\noticeForm.dotx");

            application.Visible = true;

            if (dr.Read()) {
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
                        field.Select();
                        application.Selection.TypeText(tId.Text);

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
                        application.Selection.TypeText(m.ToString()); }

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
                        application.Selection.TypeText(startinDate.ToString());

                    }
                    else if (field.Code.Text.Contains("startingDate"))
                    {
                        field.Select();
                        application.Selection.TypeText(startinDate.SelectedDate.ToShortDateString());

                    }
                    else if (field.Code.Text.Contains("traineeSignature"))
                    {
                        field.Select();
                        application.Selection.TypeText((String)dr["traineeSignature"]);

                    }
                }

            }

            document.SaveAs2(FileName: @"c:\projects\trainee notice form.docx");
            document.Close();
            application.Quit();

        }
    }
}

        

       
    
