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
    ///TermInfo_ ��ժҪ˵����ͼ����Ϣʵ��
    /// </summary>

    public class TermInfo_
    {
        /*ѧ�ڱ��*/
        private int _termId;
        public int termId
        {
            get { return _termId; }
            set { _termId = value; }
        }

        /*ѧ������*/
        private string _termName;
        public string termName
        {
            get { return _termName; }
            set { _termName = value; }
        }

    }
}
