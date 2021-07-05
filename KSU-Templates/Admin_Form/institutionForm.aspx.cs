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
            // Retrive and display traineeSignature
            if (!Convert.IsDBNull(dr["institutionSeal"]))
            {
                byte[] imageData = (byte[])dr["institutionSeal"];
                string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                oldSeal.ImageUrl = "data:image/png;base64," + img;
                oldSeal.Visible = true;


            }

            if (!Convert.IsDBNull(dr["institutionSupervisorSignature"]))
            {
                byte[] imageData = (byte[])dr["institutionSupervisorSignature"];
                string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                oldSignature.ImageUrl = "data:image/png;base64," + img;
                oldSignature.Visible = true;


            }


        }

        protected void btnUbdate_Click(object sender, EventArgs e)
        {
           int successful_Supervisor_Update= updateSupervisor();
            int successful_Institution_Update = updateInstitution();

            if(successful_Supervisor_Update==1 && successful_Institution_Update == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);
                load_Information();
            }

        }


        protected int updateSupervisor()
        {
            CRUD myCrud = new CRUD();
            string mySql = "sql command";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", tsName.Text.ToString());
            myPara.Add("@position", position.Text.ToString());
            myPara.Add("@officeTelephone", officeTelephone.Text.ToString());
            myPara.Add("@institutionSupervisorMobile", mobile.Text.ToString());
            myPara.Add("@institutionSupervisorEmail", tsEmail.Text.ToString());
            myPara.Add("@id",1);

            //myPara.Add("@institutionSupervisorSignature", "xxxx");

            // Upload traineeSignature
            if (FileUpload1.HasFile)
            {
                mySql = @"UPDATE institutionSupervisor
                     SET institutionSupervisor = @name, position=@position , officeTelephone=@officeTelephone ,
                         institutionSupervisorMobile=@institutionSupervisorMobile , institutionSupervisorEmail=@institutionSupervisorEmail ,
                         institutionSupervisorSignature= @institutionSupervisorSignature 
                        WHERE institutionSupervisorId =@id"; 

                myPara.Add("@institutionSupervisorSignature", FileUpload1.FileBytes);
            }
            else
            {
                mySql = @"UPDATE institutionSupervisor
                     SET institutionSupervisor = @name, position=@position , officeTelephone=@officeTelephone ,
                         institutionSupervisorMobile=@institutionSupervisorMobile , institutionSupervisorEmail=@institutionSupervisorEmail ,
                                                WHERE institutionSupervisorId =@id";
            }

            return myCrud.InsertUpdateDelete(mySql, myPara);

        }

        protected int updateInstitution()
        {
            CRUD myCrud = new CRUD();
            string mySql = "sql command";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", name.Text.ToString());
            myPara.Add("@address", address.Text.ToString());
            myPara.Add("@department", department.Text.ToString());
            myPara.Add("@id",1);

            if (FileUpload2.HasFile)
            {
                mySql = @"UPDATE institution
                     SET institution = @name, address = @address, department = @department,
                         institutionSupervisorId =@id, institutionSeal = @institutionSeal
                        WHERE institutionId =@id";

                myPara.Add("@institutionSeal", FileUpload2.FileBytes);
            }
            else
            {
                mySql = @"UPDATE institution
                     SET institution = @name, address = @address, department = @department,
                         institutionSupervisorId =@id
                        WHERE institutionId =@id";
            }


            return myCrud.InsertUpdateDelete(mySql, myPara);

        }
    }
}