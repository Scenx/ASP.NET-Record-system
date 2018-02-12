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
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditClass_.aspx?classNo=" + Request["classNo"] + "\"} else  {location.href=\"M_Class_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllClass_.AddClass_(class_))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditClass_.aspx\"} else  {location.href=\"M_Class_List.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Class_List.aspx");
        }
    }
}

