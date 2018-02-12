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
    public partial class M_EditCourse_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["courseNo"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "courseNo")))
            {
                ENTITY.Course_ course_ = BLL.bllCourse_.getSomeCourse_(Common.GetMes.GetRequestQuery(Request, "courseNo"));
                courseNo.Value = course_.courseNo;
                courseName.Value = course_.courseName;
                teacherName.Value = course_.teacherName;
                courseCount.Value = course_.courseCount.ToString();
                courseScore.Value = course_.courseScore.ToString("0.00");
            }
        }

        protected void BtnCourse_Save_Click(object sender, EventArgs e)
        {
            ENTITY.Course_ course_ = new ENTITY.Course_();
            course_.courseNo = this.courseNo.Value;
            course_.courseName = courseName.Value;
            course_.teacherName = teacherName.Value;
            course_.courseCount = int.Parse(courseCount.Value);
            course_.courseScore = float.Parse(float.Parse(courseScore.Value).ToString("0.00"));
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "courseNo")))
            {
                course_.courseNo = Request["courseNo"];
                if (BLL.bllCourse_.EditCourse_(course_))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditCourse_.aspx?courseNo=" + Request["courseNo"] + "\"} else  {location.href=\"M_Course_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllCourse_.AddCourse_(course_))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditCourse_.aspx\"} else  {location.href=\"M_Course_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Course_List.aspx");
        }
    }
}

