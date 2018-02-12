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
    ///Course_ 的摘要说明：图书信息实体
    /// </summary>

    public class Course_
    {
        /*课程编号*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*课程名称*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*任课老师*/
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        /*总课时*/
        private int _courseCount;
        public int courseCount
        {
            get { return _courseCount; }
            set { _courseCount = value; }
        }

        /*课程学分*/
        private float _courseScore;
        public float courseScore
        {
            get { return _courseScore; }
            set { _courseScore = value; }
        }

    }
}
