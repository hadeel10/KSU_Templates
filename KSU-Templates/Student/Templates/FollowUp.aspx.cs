
using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.Templates
{
    public partial class FollowUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  // means do it only once for each user session
            {
                populateWeekComb();
                getStudentInfo();
            }
        }
        //***************************************************************
        protected void populateWeekComb()
        {
            CRUD myCrud = new CRUD();
            string mysql = "select weekId, week from week";
            SqlDataReader dr = myCrud.getDrPassSql(mysql);
            ddlWeek.DataValueField = "weekId";
            ddlWeek.DataTextField = "weekId";

            ddlWeek.DataSource = dr;
            ddlWeek.DataBind();
            ddlWeek.Items.Insert(0, new ListItem("Select", "0"));
        }
        //***************************************************************
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            removeError();
            if (isEmptyFields())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill out the required fields !!')", true);
            }
            else
            {
                submitInformation();
                updateTrainee();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('week1 task submited succefully')", true);
                Response.Redirect(Request.RawUrl);

            }
        }
        //***************************************************************
        protected void submitInformation()
        {
            int tasksNumber = getTasksNumber();
            using (var con = new SqlConnection("Data Source=SQL5085.site4now.net;Initial Catalog=db_a75975_hadeell10;User Id=db_a75975_hadeell10_admin;Password=kfmc123456"))
            {
                con.Open();
                var sql = @"INSERT INTO followup (userName,taskId,weekId,task)
                    VALUES (@userName, @taskId,@weekId,@task)";

                using (var comm = new SqlCommand(sql, con))
                {
                    comm.Parameters.Add("@userName", SqlDbType.NVarChar);
                    comm.Parameters.Add("@taskId", SqlDbType.Int);
                    comm.Parameters.Add("@weekId", SqlDbType.Int);
                    comm.Parameters.Add("@task", SqlDbType.NVarChar);
                    while (tasksNumber > 0)
                    {
                        {
                            comm.Parameters["@userName"].Value = Session["Username"];
                            comm.Parameters["@taskId"].Value = tasksNumber;
                            comm.Parameters["@weekId"].Value = int.Parse(ddlWeek.SelectedValue);
                            if (tasksNumber == 1)
                            {
                                comm.Parameters["@task"].Value = task1.Text;
                            }
                            else if (tasksNumber == 2)
                            {
                                comm.Parameters["@task"].Value = task2.Text;
                            }
                            else if (tasksNumber == 3)
                            {
                                comm.Parameters["@task"].Value = task3.Text;
                            }
                            else if (tasksNumber == 4)
                            {
                                comm.Parameters["@task"].Value = task4.Text;
                            }

                            comm.ExecuteNonQuery();
                        }
                        tasksNumber--;
                    }
                }
                con.Close();
            }

        }
        //***************************************************************
        protected int getTasksNumber()
        {
            int tasksNumber = 0;
            if (!string.IsNullOrEmpty(task1.Text.Trim()))
            {
                tasksNumber++;
            }
            if (!string.IsNullOrEmpty(task2.Text.Trim()))
            {
                tasksNumber++;
            }
            if (!string.IsNullOrEmpty(task3.Text.Trim()))
            {
                tasksNumber++;
            }
            if (!string.IsNullOrEmpty(task4.Text.Trim()))
            {
                tasksNumber++;
            }

            return tasksNumber;
        }
        //***************************************************************
        protected void updateTrainee()
            {
                CRUD myCrud = new CRUD();
                string mySql = "sql command";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@name", txtName.Text.ToString());
                myPara.Add("@id", txtId.Text.ToString());
                myPara.Add("@strDate", startingDate.Text.ToString());
                myPara.Add("@userName", Session["Username"]);

                // Upload traineeSignature
                if (FileUpload1.HasFile)
                {
                 mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, triningStartingDate = @strDate, traineeSignature = @traineeSignature
                        WHERE userName = @userName ";
                myPara.Add("@traineeSignature", FileUpload1.FileBytes);
                }
               else
               {
                 mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, triningStartingDate = @strDate
                        WHERE userName = @userName ";
               }

                myCrud.InsertUpdateDelete(mySql, myPara);

        }
        //***************************************************************
        protected void getStudentInfo()
        {
            if (Session["Username"] != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select trainee, triningStartingDate, id, institutionId,traineeSignature from trainee where userName = @userName ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userName", Session["Username"]);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String namee = dr["trainee"].ToString();
                        String startingD = dr["triningStartingDate"].ToString();
                        String id = dr["id"].ToString();
                        txtName.Text = namee;
                        txtId.Text = id;
                        String institutionId = dr["institutionId"].ToString();
                        txtInstitution.Value = getInstitution(institutionId);

                        if (!string.IsNullOrEmpty(startingD))
                        {
                            DateTime d = DateTime.Parse(startingD);
                            startingDate.Text = d.ToString("yyyy-MM-dd");
                        }

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
        protected void removeError()
        {

            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                nameError.Visible = false;

            }
            if (!string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                idError.Visible = false;

            }
            if (!string.IsNullOrEmpty(txtInstitution.Value.Trim()))
            {
                institutionError.Visible = false;

            }
            if (!string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = false;

            }
            if (ddlWeek.SelectedIndex != 0)
            {
                weekError.Visible = false;

            }
           
            if (!string.IsNullOrEmpty(task1.Text.Trim()))
            {
                task1Error.Visible = false;

            }

        }
        //***************************************************************

        protected bool isEmptyFields()
        {

            bool isEmpty = false;

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                nameError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                idError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(txtInstitution.Value.Trim()))
            {
                institutionError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = true;

                isEmpty = true;
            }
            if (ddlWeek.SelectedIndex == 0)
            {
                weekError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(task1.Text.Trim()))
            {
                task1Error.Visible = true;

                isEmpty = true;
            }

            return isEmpty;
        }



        //***************************************************************
     

    }
}