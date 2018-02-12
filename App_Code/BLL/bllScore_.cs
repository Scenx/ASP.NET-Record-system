using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*成绩信息业务逻辑层*/
    public class bllScore_{
        /*添加成绩信息*/
        public static bool AddScore_(ENTITY.Score_ score_)
        {
            return DAL.dalScore_.AddScore_(score_);
        }

        /*根据scoreId获取某条成绩信息记录*/
        public static ENTITY.Score_ getSomeScore_(int scoreId)
        {
            return DAL.dalScore_.getSomeScore_(scoreId);
        }

        /*更新成绩信息*/
        public static bool EditScore_(ENTITY.Score_ score_)
        {
            return DAL.dalScore_.EditScore_(score_);
        }

        /*删除成绩信息*/
        public static bool DelScore_(string p)
        {
            return DAL.dalScore_.DelScore_(p);
        }

        /*根据条件分页查询成绩信息*/
        public static System.Data.DataTable GetScore_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalScore_.GetScore_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的成绩信息*/
        public static System.Data.DataSet getAllScore_()
        {
            return DAL.dalScore_.getAllScore_();
        }
    }
}
