using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ����Ϣҵ���߼���*/
    public class bllStudent_{
        /*���ѧ����Ϣ*/
        public static bool AddStudent_(ENTITY.Student_ student_)
        {
            return DAL.dalStudent_.AddStudent_(student_);
        }

        /*����studentNumber��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.Student_ getSomeStudent_(string studentNumber)
        {
            return DAL.dalStudent_.getSomeStudent_(studentNumber);
        }

        /*����ѧ����Ϣ*/
        public static bool EditStudent_(ENTITY.Student_ student_)
        {
            return DAL.dalStudent_.EditStudent_(student_);
        }

        /*ɾ��ѧ����Ϣ*/
        public static bool DelStudent_(string p)
        {
            return DAL.dalStudent_.DelStudent_(p);
        }

        /*����������ҳ��ѯѧ����Ϣ*/
        public static System.Data.DataTable GetStudent_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudent_.GetStudent_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧ����Ϣ*/
        public static System.Data.DataSet getAllStudent_()
        {
            return DAL.dalStudent_.getAllStudent_();
        }
    }
}
