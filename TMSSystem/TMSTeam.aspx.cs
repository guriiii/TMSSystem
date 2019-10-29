using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSBiz.Interface;
using TMSBiz.Service;
using TMSBiz.VMModel;

namespace TMSSystem
{
    public partial class TMSTeam : System.Web.UI.Page
    {
        ITeamInterface _service = new TeamService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                CoachList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TeamVMModel vmModel = new TeamVMModel();
            vmModel.TeamName = txtTeamName.Text.Trim();
            vmModel.CoachID = Convert.ToInt32(CoachID.Text);
            vmModel.State = State.Text.Trim();
            vmModel.City = City.Text.Trim();
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            bool result = _service.AddEditTeamMaster(vmModel);
            if (result)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Team.aspx");
            }
            bindGrid();
        }


        protected void bindGrid()
        {
            ListToDatatable lsttodt = new ListToDatatable();
            var lst = _service.GetTeamList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataBind();
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string teacherid = this.grd.DataKeys[rowIndex]["ID"].ToString();

            if (e.CommandName == "updates")
            {
                ListToDatatable lsttodt = new ListToDatatable();
                var lst = _service.TeamListGetByID(Convert.ToInt32(teacherid));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["Id"].ToString();
                    CoachID.Text = dt.Rows[0]["CoachID"].ToString();
                    txtTeamName.Text = dt.Rows[0]["TeamName"].ToString();
                    State.Text = dt.Rows[0]["State"].ToString();
                    City.Text = dt.Rows[0]["City"].ToString();
                    btnSave.Text = "Update";
                }
                else
                {
                    //do nothing
                    btnSave.Text = "Save";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = _service.DelTeam(Convert.ToInt32(teacherid));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] VMModel = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in VMModel)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[VMModel.Length];
                for (int i = 0; i < VMModel.Length; i++)
                {

                    values[i] = VMModel[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        protected void CoachList()
        {
            ICoachInterface coachInterface = new CoachService();
            var lst = coachInterface.GetCoachList().Select(x => new { x.CoachName, x.ID }).ToList();
            DataTable dt = ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                CoachID.DataSource = dt;
                CoachID.DataTextField = "CoachName";
                CoachID.DataValueField = "ID";
                CoachID.DataBind();

            }
            else
            {
                CoachID.DataBind();
            }
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("TMSTeam.aspx");
        }
    }
}