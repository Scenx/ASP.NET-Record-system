using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学生信息业务逻辑层实现*/
    public class dalStudent_
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学生信息实现*/
        public static bool AddStudent_(ENTITY.Student_ student_)
        {
            string sql = "insert into Student_(studentNumber,studentName,sex,classInfo,birthday,zhengzhimianmao,telephone,address) values(@studentNumber,@studentName,@sex,@classInfo,@birthday,@zhengzhimianmao,@telephone,@address)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@sex",SqlDbType.VarChar),
             new SqlParameter("@classInfo",SqlDbType.VarChar),
             new SqlParameter("@birthday",SqlDbType.DateTime),
             new SqlParameter("@zhengzhimianmao",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = student_.studentNumber; //学号
            parm[1].Value = student_.studentName; //学生姓名
            parm[2].Value = student_.sex; //性别
            parm[3].Value = student_.classInfo; //所在班级
            parm[4].Value = student_.birthday; //出生日期
            parm[5].Value = student_.zhengzhimianmao; //政治面貌
            parm[6].Value = student_.telephone; //联系电话
            parm[7].Value = student_.address; //家庭地址

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据studentNumber获取某条学生信息记录*/
        public static ENTITY.Student_ getSomeStudent_(string studentNumber)
        {
            /*构建查询sql*/
            string sql = "select * from Student_ where studentNumber='" + studentNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student_ student_ = new ENTITY.Student_();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                student_.studentNumber = DataRead["studentNumber"].ToString();
                student_.studentName = DataRead["studentName"].ToString();
                student_.sex = DataRead["sex"].ToString();
                student_.classInfo = DataRead["classInfo"].ToString();
                student_.birthday = Convert.ToDateTime(DataRead["birthday"].ToString());
                student_.zhengzhimianmao = DataRead["zhengzhimianmao"].ToString();
                student_.telephone = DataRead["telephone"].ToString();
                student_.address = DataRead["address"].ToString();
            }
            return student_;
        }

        /*更新学生信息实现*/
        public static bool EditStudent_(ENTITY.Student_ student_)
        {
            string sql = "update Student_ set studentName=@studentName,sex=@sex,classInfo=@classInfo,birthday=@birthday,zhengzhimianmao=@zhengzhimianmao,telephone=@telephone,address=@address where studentNumber=@studentNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@sex",SqlDbType.VarChar),
             new SqlParameter("@classInfo",SqlDbType.VarChar),
             new SqlParameter("@birthday",SqlDbType.DateTime),
             new SqlParameter("@zhengzhimianmao",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@studentNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = student_.studentName;
            parm[1].Value = student_.sex;
            parm[2].Value = student_.classInfo;
            parm[3].Value = student_.birthday;
            parm[4].Value = student_.zhengzhimianmao;
            parm[5].Value = student_.telephone;
            parm[6].Value = student_.address;
            parm[7].Value = student_.studentNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学生信息*/
        public static bool DelStudent_(string p)
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
            sql = "delete from Student_ where studentNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学生信息*/
        public static System.Data.DataTable GetStudent_(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Student_";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "studentNumber", strShow, strSql, strWhere, " studentNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStudent_()
        {
            try
            {
                string strSql = "select * from Student_";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
