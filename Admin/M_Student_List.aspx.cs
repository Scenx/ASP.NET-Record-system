using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace _.Admin
{
    public partial class M_Student_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindClass_();
                string sqlstr = " where 1=1 ";
                if (Request["studentNumber"] != null && Request["studentNumber"].ToString() != "")
                {
                    sqlstr += "  and studentNumber like '%" + Request["studentNumber"].ToString() + "%'";
                    studentNumber.Text = Request["studentNumber"].ToString();
                }
                if (Request["studentName"] != null && Request["studentName"].ToString() != "")
                {
                    sqlstr += "  and studentName like '%" + Request["studentName"].ToString() + "%'";
                    studentName.Text = Request["studentName"].ToString();
                }
                if (Request["classInfo"] != null && Request["classInfo"].ToString() != "")
                {
                    sqlstr += "  and classInfo='" + Request["classInfo"].ToString() + "'";
                    classInfo.SelectedValue = Request["classInfo"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindClass_()
        {
            classInfo.DataSource = BLL.bllClass_.getAllClass_();
            classInfo.DataTextField = "className";
            classInfo.DataValueField = "classNo";
            classInfo.DataBind();
            ListItem li = new ListItem("=请选择=", "");
            classInfo.Items.Add(li);
            classInfo.SelectedValue = "";
        }

        protected void BtnStudent_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditStudent_.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllStudent_.DelStudent_(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "M_Student_List.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllStudent_.GetStudent_(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpStudent_.DataSource = dsLog;
            RpStudent_.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpStudent__ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllStudent_.DelStudent_((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "M_Student_List.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "M_Student_List.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "M_Student_List.aspx");
                }
            }
        }
        public string GetClass_(string classInfo)
        {
            return BLL.bllClass_.getSomeClass_(classInfo).className;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Student_List.aspx?studentNumber=" + studentNumber.Text.Trim() + "&&studentName=" + studentName.Text.Trim() + "&&classInfo=" + classInfo.SelectedValue.Trim());
        }
    }
}
