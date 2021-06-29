
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, majorId=@majorId , trackId=@trackId , traineeMobile=@traineeMobile , homeTelephone=@homeTelephone ,traineeEmail= @traineeEmail ,
                         universitySupervisor=@universitySupervisor , universitySupervisorEmail=@universitySupervisorEmail , institutionId=@institutionId ,triningStartingDate = @strDate
                        WHERE userName = @userName ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", txtName.Value.ToString());
            myPara.Add("@id",txtId.Text);
            myPara.Add("@majorId","1");
            myPara.Add("@trackId","1");
            myPara.Add("@traineeMobile",txtMobile.Text.ToString());
            myPara.Add("@homeTelephone",txtHomeTelephone.Text.ToString());
            myPara.Add("@traineeEmail",txtEmail.Text.ToString());
            myPara.Add("@universitySupervisor",usName.Text.ToString());
            myPara.Add("@universitySupervisorEmail",usEmail.Text.ToString());
            myPara.Add("@institutionId","1");
            myPara.Add("@strDate", startingDate.Text.ToString());
            myPara.Add("@userName", Session["Username"]);
            myCrud.InsertUpdateDelete(mySql, myPara);
        }
    }
}

        

       
    
