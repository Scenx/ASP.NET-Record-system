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
    ///Class_ ��ժҪ˵����ͼ����Ϣʵ��
    /// </summary>

    public class Class_
    {
        /*�༶���*/
        private string _classNo;
        public string classNo
        {
            get { return _classNo; }
            set { _classNo = value; }
        }

        /*�༶����*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*����������*/
        private string _banzhuren;
        public string banzhuren
        {
            get { return _banzhuren; }
            set { _banzhuren = value; }
        }

        /*��������*/
        private DateTime _beginTime;
        public DateTime beginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }

    }
}
