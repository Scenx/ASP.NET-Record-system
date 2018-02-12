using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*班级信息业务逻辑层*/
    public class bllClass_{
        /*添加班级信息*/
        public static bool AddClass_(ENTITY.Class_ class_)
        {
            return DAL.dalClass_.AddClass_(class_);
        }

        /*根据classNo获取某条班级信息记录*/
        public static ENTITY.Class_ getSomeClass_(string classNo)
        {
            return DAL.dalClass_.getSomeClass_(classNo);
        }

        /*更新班级信息*/
        public static bool EditClass_(ENTITY.Class_ class_)
        {
            return DAL.dalClass_.EditClass_(class_);
        }

        /*删除班级信息*/
        public static bool DelClass_(string p)
        {
            return DAL.dalClass_.DelClass_(p);
        }

        /*根据条件分页查询班级信息*/
        public static System.Data.DataTable GetClass_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalClass_.GetClass_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的班级信息*/
        public static System.Data.DataSet getAllClass_()
        {
            return DAL.dalClass_.getAllClass_();
        }
    }
}
