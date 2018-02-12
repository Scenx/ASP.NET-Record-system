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
    public partial class M_EditTermInfo_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["termId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "termId")))
            {
                ENTITY.TermInfo_ termInfo_ = BLL.bllTermInfo_.getSomeTermInfo_(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "termId")));
                termName.Value = termInfo_.termName;
            }
        }

        protected void BtnTermInfo_Save_Click(object sender, EventArgs e)
        {
            ENTITY.TermInfo_ termInfo_ = new ENTITY.TermInfo_();
            termInfo_.termName = termName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "termId")))
            {
                termInfo_.termId = int.Parse(Request["termId"]);
                if (BLL.bllTermInfo_.EditTermInfo_(termInfo_))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditTermInfo_.aspx?termId=" + Request["termId"] + "\"} else  {location.href=\"M_TermInfo_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllTermInfo_.AddTermInfo_(termInfo_))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditTermInfo_.aspx\"} else  {location.href=\"M_TermInfo_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_TermInfo_List.aspx");
        }
    }
}

