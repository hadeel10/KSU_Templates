using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace KSU_Templates.Student.Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                displayAttendanceInformation();
                getStudentInfo();

            }


        }

        //***************************************************************

        protected void submit(object sender, EventArgs e) {

            removeError();
            if (!checkEmptyField())
            {
                saveAttendance();
                updateTrainee();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved succefully')", true);
                Response.Redirect(Request.RawUrl);

            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill out the required field !!')", true);
            }

        }
        //***************************************************************

        protected void displayAttendanceInformation()
        {

            string sqlCmd = "select * from attendance where userName ='" + Session["Username"] + "'";

            string conString = CRUD.conStr;//..CRUD.DB_CONN_ST; //WebConfigurationManager.ConnectionStrings["conStrInternship"].ConnectionString;//WebConfigurationManager.ConnectionStrings["FtreeConStrlocal"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(sqlCmd, conString);
            DataTable dtUserRoles = new DataTable();
            dad.Fill(dtUserRoles);
            gvUsers.DataSource = dtUserRoles;
            gvUsers.DataBind();


           /* DataTable dtUserRoles = new DataTable();
            dtUserRoles.Columns.Add("Day");
            dtUserRoles.Columns.Add("Date");
            dtUserRoles.Columns.Add("Time in");
            dtUserRoles.Columns.Add("Time out");
            dtUserRoles.Columns.Add("Signature");
            dtUserRoles.Columns.Add("Comments");
            dtUserRoles.Columns.Add("delete");

            dtUserRoles.Rows.Add("hadeel", "hadeel", "hadeel", "hadeel", "hadeel", "hadeel", "hadeel");

            gvUsers.DataSource = dtUserRoles;
            gvUsers.DataBind();*/




        }
        //***************************************************************

        protected void getStudentInfo()
        {
            if (Session["Username"] != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select name, triningStartingDate, id, institutionId from trainee where userName = @userN ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userN", Session["Username"]);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String namee = dr["name"].ToString();
                        String startingD = dr["triningStartingDate"].ToString();
                        String id = dr["id"].ToString();
                        name.Text = namee;
                        idd.Text = id;
                        String institutionId  = dr["institutionId"].ToString();
                        institution.Value = getInstitution(institutionId);
                        if(!string.IsNullOrEmpty(startingD)) { 
                        DateTime d = DateTime.Parse(startingD);
                        startingDate.Text = d.ToString("yyyy-MM-dd");}
                    }
                }
            }
        }
        //***************************************************************

        protected String getInstitution(String institutionId)
        {
            String institution = null;
            if (institutionId != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select institution from institution where institutionId = @id ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@id", institutionId);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        institution = dr["institution"].ToString();
                    }
                }
            }
                return institution;
            
        }
        //***************************************************************

        protected bool checkEmptyField() {

            bool isEmptyExist = false;

            if (string.IsNullOrEmpty(name.Text.Trim()))
            {
                nameError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(idd.Text.Trim()))
            {
                idError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(institution.Value.Trim()))
            {
                institutionError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = true;

                isEmptyExist = true;
            }
            if (week.SelectedIndex == 0)
            {
                weekError.Visible = true;

                isEmptyExist = true;
            }
            if (ddlDay.SelectedValue.Equals("Day"))
            {
                dayError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(attendanceDate.Text.Trim()))
            {
                dateError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(TimeInField.Text.Trim()))
            {
                timeInError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(timeOutField.Text.Trim()))
            {
                timeOutError.Visible = true;

                isEmptyExist = true;
            }
            /*    if (string.IsNullOrEmpty(comments.Value.Trim()))                  need to complete when adding image
                {
                    signatureError.Visible = true;

                    isEmptyExist = true;
                }*/

            return isEmptyExist;
        }

        //***************************************************************

        protected void removeError()
        {


            if (!string.IsNullOrEmpty(name.Text.Trim()))
            {
                nameError.Visible = false;

            }
            if (!string.IsNullOrEmpty(idd.Text.Trim()))
            {
                idError.Visible = false;

            }
            if (!string.IsNullOrEmpty(institution.Value.Trim()))
            {
                institutionError.Visible = false;

            }
            if (!string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = false;

            }
            if (week.SelectedIndex != 0)
            {
                weekError.Visible = false;

            }
            if (!ddlDay.SelectedValue.Equals("Day"))
            {
                dayError.Visible = false;

            }
            if (!string.IsNullOrEmpty(attendanceDate.Text.Trim()))
            {
                dateError.Visible = false;

            }
            if (!string.IsNullOrEmpty(TimeInField.Text.Trim()))
            {
                timeInError.Visible = false;

            }
            if (!string.IsNullOrEmpty(timeOutField.Text.Trim()))
            {
                timeOutError.Visible = false;

            }
            /*    if (string.IsNullOrEmpty(comments.Value.Trim()))                  need to complete when adding image
                {
                    signatureError.Visible = true;

                    isEmptyExist = true;
                }*/


        }
        //***************************************************************

        protected void saveAttendance() {

            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO attendance (week, dayId, date, comment, userName)
              VALUES (@week, @dayId , @date, @comment, @userName)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@week", week.Value.ToString());
            myPara.Add("@dayId", ddlDay.SelectedIndex.ToString());
            myPara.Add("@date", attendanceDate.Text.ToString());
            myPara.Add("@comment", comments.Value);
            myPara.Add("@userName", Session["Username"]);
            myCrud.InsertUpdateDelete(mySql, myPara);

        }
        protected void updateTrainee()
        {

            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE trainee
                     SET name = @name, id = @id, triningStartingDate = @strDate
                        WHERE userName = @userName ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", name.Text.ToString());
            myPara.Add("@id", idd.Text.ToString());
            myPara.Add("@strDate", startingDate.Text.ToString());
            myPara.Add("@userName", Session["Username"]);
            myCrud.InsertUpdateDelete(mySql, myPara);

        }
      /*  protected void updateIstituation()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE [dbo].[institution]
              SET institution = @institution
                WHERE institutionId = 1;";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@institution", institution.Value.ToString());
            myCrud.InsertUpdateDelete(mySql, myPara);

        } */

    }
}