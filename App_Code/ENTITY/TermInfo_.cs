using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///TermInfo_ 的摘要说明：图书信息实体
    /// </summary>

    public class TermInfo_
    {
        /*学期编号*/
        private int _termId;
        public int termId
        {
            get { return _termId; }
            set { _termId = value; }
        }

        /*学期名称*/
        private string _termName;
        public string termName
        {
            get { return _termName; }
            set { _termName = value; }
        }

    }
}
