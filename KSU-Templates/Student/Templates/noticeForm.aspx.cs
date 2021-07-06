
using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  // means do it only once for each user session
            {
                GetStudentInfo();
            }
            }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, majorId=@majorId , trackId=@trackId , traineeMobile=@traineeMobile , homeTelephone=@homeTelephone ,traineeEmail= @traineeEmail ,
                         universitySupervisor=@universitySupervisor , universitySupervisorEmail=@universitySupervisorEmail , institutionId=@institutionId ,triningStartingDate = @strDate
                        WHERE userName = @userName ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", txtName.Text.ToString());
            myPara.Add("@id", txtId.Text);
            myPara.Add("@majorId", major.SelectedValue);
            myPara.Add("@trackId", track.SelectedValue);
            myPara.Add("@traineeMobile", txtMobile.Text.ToString());
            myPara.Add("@homeTelephone", txtHomeTelephone.Text.ToString());
            myPara.Add("@traineeEmail", txtEmail.Text.ToString());
            myPara.Add("@universitySupervisor", usName.Text.ToString());
            myPara.Add("@universitySupervisorEmail", usEmail.Text.ToString());
            myPara.Add("@institutionId", ddInstitution.SelectedValue);
            myPara.Add("@strDate", startingDate.Text.ToString());
            myPara.Add("@userName", Session["Username"]);

            // Upload traineeSignature
            if (FileUpload1.HasFile)
            {
                mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, majorId=@majorId , trackId=@trackId , traineeMobile=@traineeMobile , homeTelephone=@homeTelephone ,traineeEmail= @traineeEmail ,traineeSignature=@traineeSignature,
                         universitySupervisor=@universitySupervisor , universitySupervisorEmail=@universitySupervisorEmail , institutionId=@institutionId ,triningStartingDate = @strDate
                        WHERE userName = @userName";
                myPara.Add("@traineeSignature", FileUpload1.FileBytes);
            }
            else
            {
                mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, majorId=@majorId , trackId=@trackId , traineeMobile=@traineeMobile , homeTelephone=@homeTelephone ,traineeEmail= @traineeEmail ,
                         universitySupervisor=@universitySupervisor , universitySupervisorEmail=@universitySupervisorEmail , institutionId=@institutionId ,triningStartingDate = @strDate
                        WHERE userName = @userName";
            }
            int success= myCrud.InsertUpdateDelete(mySql, myPara);
            if (success == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The information submitted successfully!')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Somthing Wrong! please fill the information again')", true);

            }

            GetStudentInfo();
        }


        protected void GetStudentInfo()
        {
            if (Session["Username"] != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select * from trainee 
                                   inner join major on trainee.majorId=major.majorId
                                    inner join track on trainee.trackId=track.trackId where userName = @userName";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userName", Session["Username"]);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["trainee"].ToString();
                        txtId.Text = dr["id"].ToString();
                        major.SelectedValue= dr["majorId"].ToString();
                        track.SelectedValue = dr["trackId"].ToString();
                        txtEmail.Text= dr["traineeEmail"].ToString();
                        txtMobile.Text= dr["traineeMobile"].ToString();
                        txtHomeTelephone.Text= dr["homeTelephone"].ToString();
                        startingDate.Text= dr["triningStartingDate"].ToString();

                        //University Supervisor
                        usName.Text= dr["universitySupervisor"].ToString();
                        usEmail.Text= dr["universitySupervisorEmail"].ToString();



                        // Retrive and display traineeSignature
                        if (!Convert.IsDBNull(dr["traineeSignature"]))
                        {
                            byte[] imageData = (byte[])dr["traineeSignature"];
                            string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                            oldSignature.ImageUrl = "data:image/png;base64," + img;
                            oldSignature.Visible = true;
                        }
                    }

                }

            }
        }

       

    }
}





