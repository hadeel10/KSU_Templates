using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.Admin_Form
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                load_Information();

            }

        }

        protected void load_Information()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from institution 
                                inner join institutionSupervisor on institution.institutionSupervisorId = institutionSupervisor.institutionSupervisorId
                                where institutionId=1";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            if (dr.Read())
            {
                name.Text = (String)dr["institution"];
                address.Text = (String)dr["address"];
                department.Text= (String)dr["department"];
                tsName.Text= (String)dr["institutionSupervisor"];
                tsEmail.Text= (String)dr["institutionSupervisorEmail"];
                position.Text= (String)dr["position"];
                mobile.Text= (String)dr["institutionSupervisorMobile"];
                officeTelephone.Text= (String)dr["officeTelephone"];

            }
           
            
        }

        protected void btnUbdate_Click(object sender, EventArgs e)
        {
           int successful_Supervisor_Update= updateSupervisor();
            int successful_Institution_Update = updateInstitution();

            if(successful_Supervisor_Update==1 && successful_Institution_Update == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);
            }

        }


        protected int updateSupervisor()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE institutionSupervisor
                     SET institutionSupervisor = @name, position=@position , officeTelephone=@officeTelephone ,
                         institutionSupervisorMobile=@institutionSupervisorMobile , institutionSupervisorEmail=@institutionSupervisorEmail ,
                         institutionSupervisorSignature= @institutionSupervisorSignature 
                        WHERE institutionSupervisorId = 1";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", tsName.Text.ToString());
            myPara.Add("@position", position.Text.ToString());
            myPara.Add("@officeTelephone", officeTelephone.Text.ToString());
            myPara.Add("@institutionSupervisorMobile", mobile.Text.ToString());
            myPara.Add("@institutionSupervisorEmail", tsEmail.Text.ToString());
            myPara.Add("@institutionSupervisorSignature", "xxxx");


           
           return myCrud.InsertUpdateDelete(mySql, myPara);

        }

        protected int updateInstitution()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE institution
                     SET institution = @name, address=@address , department=@department ,
                         institutionSupervisorId=1 , institutionSeal=@institutionSeal
                        WHERE institutionId = 1";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", name.Text.ToString());
            myPara.Add("@address", address.Text.ToString());
            myPara.Add("@department", department.Text.ToString());
            myPara.Add("@institutionSeal", "xxxx");
            
            return myCrud.InsertUpdateDelete(mySql, myPara);

        }
    }
}