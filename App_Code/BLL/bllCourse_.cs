using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�γ���Ϣҵ���߼���*/
    public class bllCourse_{
        /*��ӿγ���Ϣ*/
        public static bool AddCourse_(ENTITY.Course_ course_)
        {
            return DAL.dalCourse_.AddCourse_(course_);
        }

        /*����courseNo��ȡĳ���γ���Ϣ��¼*/
        public static ENTITY.Course_ getSomeCourse_(string courseNo)
        {
            return DAL.dalCourse_.getSomeCourse_(courseNo);
        }

        /*���¿γ���Ϣ*/
        public static bool EditCourse_(ENTITY.Course_ course_)
        {
            return DAL.dalCourse_.EditCourse_(course_);
        }

        /*ɾ���γ���Ϣ*/
        public static bool DelCourse_(string p)
        {
            return DAL.dalCourse_.DelCourse_(p);
        }

        /*����������ҳ��ѯ�γ���Ϣ*/
        public static System.Data.DataTable GetCourse_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourse_.GetCourse_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĿγ���Ϣ*/
        public static System.Data.DataSet getAllCourse_()
        {
            return DAL.dalCourse_.getAllCourse_();
        }
    }
}
