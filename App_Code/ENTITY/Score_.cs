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
    ///Score_ ��ժҪ˵����ͼ����Ϣʵ��
    /// </summary>

    public class Score_
    {
        /*�ɼ����*/
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
        }

        /*����ѧ��*/
        private string _studentNo;
        public string studentNo
        {
            get { return _studentNo; }
            set { _studentNo = value; }
        }

        /*�����γ�*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*����ѧ��*/
        private int _termId;
        public int termId
        {
            get { return _termId; }
            set { _termId = value; }
        }

        /*�ɼ��÷�*/
        private float _score;
        public float score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
