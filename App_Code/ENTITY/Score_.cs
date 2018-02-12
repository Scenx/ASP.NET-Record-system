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
    ///Score_ 的摘要说明：图书信息实体
    /// </summary>

    public class Score_
    {
        /*成绩编号*/
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
        }

        /*所属学生*/
        private string _studentNo;
        public string studentNo
        {
            get { return _studentNo; }
            set { _studentNo = value; }
        }

        /*所属课程*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*所在学期*/
        private int _termId;
        public int termId
        {
            get { return _termId; }
            set { _termId = value; }
        }

        /*成绩得分*/
        private float _score;
        public float score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
