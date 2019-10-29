using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSBiz.Interface;
using TMSBiz.Service;
using TMSBiz.VMModel;

namespace TMSSystem
{
    public partial class TMSCoach : System.Web.UI.Page
    {
        ICoachInterface _service = new CoachService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CoachVMModel pr = new CoachVMModel();
            pr.CoachName = txtCoachName.Text.Trim();
            if (HiddenField1.Value != "")
                pr.ID = Convert.ToInt32(HiddenField1.Value);
            bool result = _service.AddEditCoachMaster(pr);
            if (result)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
            }
            bindGrid();
        }


        protected void bindGrid()
        {
            ListToDatatable lsttodt = new ListToDatatable();
            var lst = _service.GetCoachList();
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
                var lst = _service.CoachListGetByID(Convert.ToInt32(teacherid));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    txtCoachName.Text = dt.Rows[0]["CoachName"].ToString();
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
                bool result = _service.DelCoach(Convert.ToInt32(teacherid));
                if (result)
                {
                    bindGrid();

                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("TMSCoach.aspx");
        }
    }
}