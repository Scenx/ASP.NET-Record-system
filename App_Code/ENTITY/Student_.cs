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
    ///Student_ ��ժҪ˵����ͼ����Ϣʵ��
    /// </summary>

    public class Student_
    {
        /*ѧ��*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*ѧ������*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*�Ա�*/
        private string _sex;
        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /*���ڰ༶*/
        private string _classInfo;
        public string classInfo
        {
            get { return _classInfo; }
            set { _classInfo = value; }
        }

        /*��������*/
        private DateTime _birthday;
        public DateTime birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /*������ò*/
        private string _zhengzhimianmao;
        public string zhengzhimianmao
        {
            get { return _zhengzhimianmao; }
            set { _zhengzhimianmao = value; }
        }

        /*��ϵ�绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*��ͥ��ַ*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

    }
}
