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
    public partial class TMSPlayer : System.Web.UI.Page
    {
           IPlayerInterface _service = new PlayerService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                TeamList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PlayerVMModel pr = new PlayerVMModel();
            pr.Name = txtName.Text.Trim();
            pr.TeamID = Convert.ToInt32(TeamID.Text);
            pr.Position = Position.Text.Trim();
            pr.Gender = GenderList.Text;
            if (HiddenField1.Value != "")
                pr.ID = Convert.ToInt32(HiddenField1.Value);
            bool result = _service.AddEditPlayerMaster(pr);
            if (result)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Player.aspx");
            }
            bindGrid();
        }


        protected void bindGrid()
        {
            ListToDatatable lsttodt = new ListToDatatable();
            var lst = _service.GetPlayerList();
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
                var lst = _service.PlayerListGetByID(Convert.ToInt32(teacherid));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["Id"].ToString();
                    TeamID.Text = dt.Rows[0]["TeamID"].ToString();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    Position.Text = dt.Rows[0]["Position"].ToString();
                    GenderList.Text = dt.Rows[0]["Gender"].ToString();
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
                bool result = _service.DelPlayer(Convert.ToInt32(teacherid));
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
        protected void TeamList()
        {
            ITeamInterface coachInterface = new TeamService();
            var lst = coachInterface.GetTeamList().Select(x => new { x.TeamName, x.ID }).ToList();
            DataTable dt = ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                TeamID.DataSource = dt;
                TeamID.DataTextField = "TeamName";
                TeamID.DataValueField = "ID";
                TeamID.DataBind();

            }
            else
            {
                TeamID.DataBind();
            }
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("TMSPlayer.aspx");
        }
    }
}