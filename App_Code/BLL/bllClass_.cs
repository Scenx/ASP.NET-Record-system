using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�༶��Ϣҵ���߼���*/
    public class bllClass_{
        /*��Ӱ༶��Ϣ*/
        public static bool AddClass_(ENTITY.Class_ class_)
        {
            return DAL.dalClass_.AddClass_(class_);
        }

        /*����classNo��ȡĳ���༶��Ϣ��¼*/
        public static ENTITY.Class_ getSomeClass_(string classNo)
        {
            return DAL.dalClass_.getSomeClass_(classNo);
        }

        /*���°༶��Ϣ*/
        public static bool EditClass_(ENTITY.Class_ class_)
        {
            return DAL.dalClass_.EditClass_(class_);
        }

        /*ɾ���༶��Ϣ*/
        public static bool DelClass_(string p)
        {
            return DAL.dalClass_.DelClass_(p);
        }

        /*����������ҳ��ѯ�༶��Ϣ*/
        public static System.Data.DataTable GetClass_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalClass_.GetClass_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еİ༶��Ϣ*/
        public static System.Data.DataSet getAllClass_()
        {
            return DAL.dalClass_.getAllClass_();
        }
    }
}
