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
    public partial class M_EditClass_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["classNo"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "classNo")))
            {
                ENTITY.Class_ class_ = BLL.bllClass_.getSomeClass_(Common.GetMes.GetRequestQuery(Request, "classNo"));
                classNo.Value = class_.classNo;
                className.Value = class_.className;
                banzhuren.Value = class_.banzhuren;
                beginTime.Text = class_.beginTime.ToShortDateString();
            }
        }

        protected void BtnClass_Save_Click(object sender, EventArgs e)
        {
            ENTITY.Class_ class_ = new ENTITY.Class_();
            class_.classNo = this.classNo.Value;
            class_.className = className.Value;
            class_.banzhuren = banzhuren.Value;
            class_.beginTime = Convert.ToDateTime(beginTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "classNo")))
            {
                class_.classNo = Request["classNo"];
                if (BLL.bllClass_.EditClass_(class_))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditClass_.aspx?classNo=" + Request["classNo"] + "\"} else  {location.href=\"M_Class_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllClass_.AddClass_(class_))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditClass_.aspx\"} else  {location.href=\"M_Class_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Class_List.aspx");
        }
    }
}

