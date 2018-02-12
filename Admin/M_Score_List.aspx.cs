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
    public partial class M_Score_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindStudent_();
                BindCourse_();
                BindTermInfo_();
                string sqlstr = " where 1=1 ";
                if (Request["studentNo"] != null && Request["studentNo"].ToString() != "")
                {
                    sqlstr += "  and studentNo='" + Request["studentNo"].ToString() + "'";
                    studentNo.SelectedValue = Request["studentNo"].ToString();
                }
                if (Request["courseNo"] != null && Request["courseNo"].ToString() != "")
                {
                    sqlstr += "  and courseNo='" + Request["courseNo"].ToString() + "'";
                    courseNo.SelectedValue = Request["courseNo"].ToString();
                }
                if (Request["termId"] != null && Request["termId"].ToString() != "0")
                {
                    sqlstr += "  and termId=" + Request["termId"].ToString();
                    termId.SelectedValue = Request["termId"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindStudent_()
        {
            studentNo.DataSource = BLL.bllStudent_.getAllStudent_();
            studentNo.DataTextField = "studentName";
            studentNo.DataValueField = "studentNumber";
            studentNo.DataBind();
            ListItem li = new ListItem("=请选择=", "");
            studentNo.Items.Add(li);
            studentNo.SelectedValue = "";
        }

        private void BindCourse_()
        {
            courseNo.DataSource = BLL.bllCourse_.getAllCourse_();
            courseNo.DataTextField = "courseName";
            courseNo.DataValueField = "courseNo";
            courseNo.DataBind();
            ListItem li = new ListItem("=请选择=", "");
            courseNo.Items.Add(li);
            courseNo.SelectedValue = "";
        }

        private void BindTermInfo_()
        {
            termId.DataSource = BLL.bllTermInfo_.getAllTermInfo_();
            termId.DataTextField = "termName";
            termId.DataValueField = "termId";
            termId.DataBind();
            ListItem li = new ListItem("=请选择=", "0");
            termId.Items.Add(li);
            termId.SelectedValue = "0";
        }

        protected void BtnScore_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditScore_.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllScore_.DelScore_(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "M_Score_List.aspx");
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
            DataTable dsLog = BLL.bllScore_.GetScore_(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpScore_.DataSource = dsLog;
            RpScore_.DataBind();
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
        protected void RpScore__ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllScore_.DelScore_((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "M_Score_List.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "M_Score_List.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "M_Score_List.aspx");
                }
            }
        }
        public string GetStudent_(string studentNo)
        {
            return BLL.bllStudent_.getSomeStudent_(studentNo).studentName;
        }

        public string GetCourse_(string courseNo)
        {
            return BLL.bllCourse_.getSomeCourse_(courseNo).courseName;
        }

        public string GetTermInfo_(string termId)
        {
            return BLL.bllTermInfo_.getSomeTermInfo_(int.Parse(termId)).termName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Score_List.aspx?studentNo=" + studentNo.SelectedValue.Trim() + "&&courseNo=" + courseNo.SelectedValue.Trim() + "&&termId=" + termId.SelectedValue.Trim());
        }
    }
}
