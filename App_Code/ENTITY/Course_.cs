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
    ///Course_ ��ժҪ˵����ͼ����Ϣʵ��
    /// </summary>

    public class Course_
    {
        /*�γ̱��*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*�γ�����*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*�ο���ʦ*/
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        /*�ܿ�ʱ*/
        private int _courseCount;
        public int courseCount
        {
            get { return _courseCount; }
            set { _courseCount = value; }
        }

        /*�γ�ѧ��*/
        private float _courseScore;
        public float courseScore
        {
            get { return _courseScore; }
            set { _courseScore = value; }
        }

    }
}
