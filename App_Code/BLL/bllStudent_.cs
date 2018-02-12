using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学生信息业务逻辑层*/
    public class bllStudent_{
        /*添加学生信息*/
        public static bool AddStudent_(ENTITY.Student_ student_)
        {
            return DAL.dalStudent_.AddStudent_(student_);
        }

        /*根据studentNumber获取某条学生信息记录*/
        public static ENTITY.Student_ getSomeStudent_(string studentNumber)
        {
            return DAL.dalStudent_.getSomeStudent_(studentNumber);
        }

        /*更新学生信息*/
        public static bool EditStudent_(ENTITY.Student_ student_)
        {
            return DAL.dalStudent_.EditStudent_(student_);
        }

        /*删除学生信息*/
        public static bool DelStudent_(string p)
        {
            return DAL.dalStudent_.DelStudent_(p);
        }

        /*根据条件分页查询学生信息*/
        public static System.Data.DataTable GetStudent_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudent_.GetStudent_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学生信息*/
        public static System.Data.DataSet getAllStudent_()
        {
            return DAL.dalStudent_.getAllStudent_();
        }
    }
}
