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
    ///Student_ 的摘要说明：图书信息实体
    /// </summary>

    public class Student_
    {
        /*学号*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*学生姓名*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*性别*/
        private string _sex;
        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /*所在班级*/
        private string _classInfo;
        public string classInfo
        {
            get { return _classInfo; }
            set { _classInfo = value; }
        }

        /*出生日期*/
        private DateTime _birthday;
        public DateTime birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /*政治面貌*/
        private string _zhengzhimianmao;
        public string zhengzhimianmao
        {
            get { return _zhengzhimianmao; }
            set { _zhengzhimianmao = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*家庭地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

    }
}
