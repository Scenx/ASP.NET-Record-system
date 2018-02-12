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
    public partial class M_EditScore_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindStudent_();
                BindCourse_();
                BindTermInfo_();
                if (Request["scoreId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindStudent_()
        {
            studentNo.DataSource = BLL.bllStudent_.getAllStudent_();
            studentNo.DataTextField = "studentName";
            studentNo.DataValueField = "studentNumber";
            studentNo.DataBind();
        }

        private void BindCourse_()
        {
            courseNo.DataSource = BLL.bllCourse_.getAllCourse_();
            courseNo.DataTextField = "courseName";
            courseNo.DataValueField = "courseNo";
            courseNo.DataBind();
        }

        private void BindTermInfo_()
        {
            termId.DataSource = BLL.bllTermInfo_.getAllTermInfo_();
            termId.DataTextField = "termName";
            termId.DataValueField = "termId";
            termId.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "scoreId")))
            {
                ENTITY.Score_ score_ = BLL.bllScore_.getSomeScore_(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "scoreId")));
                studentNo.SelectedValue = score_.studentNo;
                courseNo.SelectedValue = score_.courseNo;
                termId.SelectedValue = score_.termId.ToString();
                score.Value = score_.score.ToString("0.00");
            }
        }

        protected void BtnScore_Save_Click(object sender, EventArgs e)
        {
            ENTITY.Score_ score_ = new ENTITY.Score_();
            score_.studentNo = studentNo.SelectedValue;
            score_.courseNo = courseNo.SelectedValue;
            score_.termId = int.Parse(termId.SelectedValue);
            score_.score = float.Parse(float.Parse(score.Value).ToString("0.00"));
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "scoreId")))
            {
                score_.scoreId = int.Parse(Request["scoreId"]);
                if (BLL.bllScore_.EditScore_(score_))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditScore_.aspx?scoreId=" + Request["scoreId"] + "\"} else  {location.href=\"M_Score_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllScore_.AddScore_(score_))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditScore_.aspx\"} else  {location.href=\"M_Score_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Score_List.aspx");
        }
    }
}

