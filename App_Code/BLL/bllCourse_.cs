using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*课程信息业务逻辑层*/
    public class bllCourse_{
        /*添加课程信息*/
        public static bool AddCourse_(ENTITY.Course_ course_)
        {
            return DAL.dalCourse_.AddCourse_(course_);
        }

        /*根据courseNo获取某条课程信息记录*/
        public static ENTITY.Course_ getSomeCourse_(string courseNo)
        {
            return DAL.dalCourse_.getSomeCourse_(courseNo);
        }

        /*更新课程信息*/
        public static bool EditCourse_(ENTITY.Course_ course_)
        {
            return DAL.dalCourse_.EditCourse_(course_);
        }

        /*删除课程信息*/
        public static bool DelCourse_(string p)
        {
            return DAL.dalCourse_.DelCourse_(p);
        }

        /*根据条件分页查询课程信息*/
        public static System.Data.DataTable GetCourse_(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourse_.GetCourse_(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的课程信息*/
        public static System.Data.DataSet getAllCourse_()
        {
            return DAL.dalCourse_.getAllCourse_();
        }
    }
}
