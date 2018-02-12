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
    public partial class M_EditStudent_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindClass_();
                if (Request["studentNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindClass_()
        {
            classInfo.DataSource = BLL.bllClass_.getAllClass_();
            classInfo.DataTextField = "className";
            classInfo.DataValueField = "classNo";
            classInfo.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "studentNumber")))
            {
                ENTITY.Student_ student_ = BLL.bllStudent_.getSomeStudent_(Common.GetMes.GetRequestQuery(Request, "studentNumber"));
                studentNumber.Value = student_.studentNumber;
                studentName.Value = student_.studentName;
                sex.Value = student_.sex;
                classInfo.SelectedValue = student_.classInfo;
                birthday.Text = student_.birthday.ToShortDateString();
                zhengzhimianmao.Value = student_.zhengzhimianmao;
                telephone.Value = student_.telephone;
                address.Value = student_.address;
            }
        }

        protected void BtnStudent_Save_Click(object sender, EventArgs e)
        {
            ENTITY.Student_ student_ = new ENTITY.Student_();
            student_.studentNumber = this.studentNumber.Value;
            student_.studentName = studentName.Value;
            student_.sex = sex.Value;
            student_.classInfo = classInfo.SelectedValue;
            student_.birthday = Convert.ToDateTime(birthday.Text);
            student_.zhengzhimianmao = zhengzhimianmao.Value;
            student_.telephone = telephone.Value;
            student_.address = address.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "studentNumber")))
            {
                student_.studentNumber = Request["studentNumber"];
                if (BLL.bllStudent_.EditStudent_(student_))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditStudent_.aspx?studentNumber=" + Request["studentNumber"] + "\"} else  {location.href=\"M_Student_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllStudent_.AddStudent_(student_))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditStudent_.aspx\"} else  {location.href=\"M_Student_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Student_List.aspx");
        }
    }
}

