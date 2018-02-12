using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学期信息业务逻辑层*/
    public class bllTermInfo_{
        /*添加学期信息*/
        public static bool AddTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            return DAL.dalTermInfo_.AddTermInfo_(termInfo_);
        }

        /*根据termId获取某条学期信息记录*/
        public static ENTITY.TermInfo_ getSomeTermInfo_(int termId)
        {
            return DAL.dalTermInfo_.getSomeTermInfo_(termId);
        }

        /*更新学期信息*/
        public static bool EditTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            return DAL.dalTermInfo_.EditTermInfo_(termInfo_);
        }

        /*删除学期信息*/
        public static bool DelTermInfo_(string p)
        {
            return DAL.dalTermInfo_.DelTermInfo_(p);
        }

        /*根据条件分页查询学期信息*/
        public static System.Data.DataTable GetTermInfo_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTermInfo_.GetTermInfo_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学期信息*/
        public static System.Data.DataSet getAllTermInfo_()
        {
            return DAL.dalTermInfo_.getAllTermInfo_();
        }
    }
}
