using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�ɼ���Ϣҵ���߼���*/
    public class bllScore_{
        /*��ӳɼ���Ϣ*/
        public static bool AddScore_(ENTITY.Score_ score_)
        {
            return DAL.dalScore_.AddScore_(score_);
        }

        /*����scoreId��ȡĳ���ɼ���Ϣ��¼*/
        public static ENTITY.Score_ getSomeScore_(int scoreId)
        {
            return DAL.dalScore_.getSomeScore_(scoreId);
        }

        /*���³ɼ���Ϣ*/
        public static bool EditScore_(ENTITY.Score_ score_)
        {
            return DAL.dalScore_.EditScore_(score_);
        }

        /*ɾ���ɼ���Ϣ*/
        public static bool DelScore_(string p)
        {
            return DAL.dalScore_.DelScore_(p);
        }

        /*����������ҳ��ѯ�ɼ���Ϣ*/
        public static System.Data.DataTable GetScore_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalScore_.GetScore_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳɼ���Ϣ*/
        public static System.Data.DataSet getAllScore_()
        {
            return DAL.dalScore_.getAllScore_();
        }
    }
}
