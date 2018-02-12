using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*课程信息业务逻辑层实现*/
    public class dalCourse_
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加课程信息实现*/
        public static bool AddCourse_(ENTITY.Course_ course_)
        {
            string sql = "insert into Course_(courseNo,courseName,teacherName,courseCount,courseScore) values(@courseNo,@courseName,@teacherName,@courseCount,@courseScore)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@courseCount",SqlDbType.Int),
             new SqlParameter("@courseScore",SqlDbType.Float)
            };
            /*给参数赋值*/
            parm[0].Value = course_.courseNo; //课程编号
            parm[1].Value = course_.courseName; //课程名称
            parm[2].Value = course_.teacherName; //任课老师
            parm[3].Value = course_.courseCount; //总课时
            parm[4].Value = course_.courseScore; //课程学分

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据courseNo获取某条课程信息记录*/
        public static ENTITY.Course_ getSomeCourse_(string courseNo)
        {
            /*构建查询sql*/
            string sql = "select * from Course_ where courseNo='" + courseNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Course_ course_ = new ENTITY.Course_();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                course_.courseNo = DataRead["courseNo"].ToString();
                course_.courseName = DataRead["courseName"].ToString();
                course_.teacherName = DataRead["teacherName"].ToString();
                course_.courseCount = Convert.ToInt32(DataRead["courseCount"]);
                course_.courseScore = float.Parse(DataRead["courseScore"].ToString());
            }
            return course_;
        }

        /*更新课程信息实现*/
        public static bool EditCourse_(ENTITY.Course_ course_)
        {
            string sql = "update Course_ set courseName=@courseName,teacherName=@teacherName,courseCount=@courseCount,courseScore=@courseScore where courseNo=@courseNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@courseCount",SqlDbType.Int),
             new SqlParameter("@courseScore",SqlDbType.Float),
             new SqlParameter("@courseNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = course_.courseName;
            parm[1].Value = course_.teacherName;
            parm[2].Value = course_.courseCount;
            parm[3].Value = course_.courseScore;
            parm[4].Value = course_.courseNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除课程信息*/
        public static bool DelCourse_(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Course_ where courseNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询课程信息*/
        public static System.Data.DataTable GetCourse_(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Course_";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "courseNo", strShow, strSql, strWhere, " courseNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCourse_()
        {
            try
            {
                string strSql = "select * from Course_";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
