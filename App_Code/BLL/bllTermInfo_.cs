using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ����Ϣҵ���߼���*/
    public class bllTermInfo_{
        /*���ѧ����Ϣ*/
        public static bool AddTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            return DAL.dalTermInfo_.AddTermInfo_(termInfo_);
        }

        /*����termId��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.TermInfo_ getSomeTermInfo_(int termId)
        {
            return DAL.dalTermInfo_.getSomeTermInfo_(termId);
        }

        /*����ѧ����Ϣ*/
        public static bool EditTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            return DAL.dalTermInfo_.EditTermInfo_(termInfo_);
        }

        /*ɾ��ѧ����Ϣ*/
        public static bool DelTermInfo_(string p)
        {
            return DAL.dalTermInfo_.DelTermInfo_(p);
        }

        /*����������ҳ��ѯѧ����Ϣ*/
        public static System.Data.DataTable GetTermInfo_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTermInfo_.GetTermInfo_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧ����Ϣ*/
        public static System.Data.DataSet getAllTermInfo_()
        {
            return DAL.dalTermInfo_.getAllTermInfo_();
        }
    }
}
