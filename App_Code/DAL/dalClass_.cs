using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*班级信息业务逻辑层实现*/
    public class dalClass_
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加班级信息实现*/
        public static bool AddClass_(ENTITY.Class_ class_)
        {
            string sql = "insert into Class_(classNo,className,banzhuren,beginTime) values(@classNo,@className,@banzhuren,@beginTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classNo",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@banzhuren",SqlDbType.VarChar),
             new SqlParameter("@beginTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = class_.classNo; //班级编号
            parm[1].Value = class_.className; //班级名称
            parm[2].Value = class_.banzhuren; //班主任姓名
            parm[3].Value = class_.beginTime; //开办日期

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据classNo获取某条班级信息记录*/
        public static ENTITY.Class_ getSomeClass_(string classNo)
        {
            /*构建查询sql*/
            string sql = "select * from Class_ where classNo='" + classNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Class_ class_ = new ENTITY.Class_();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                class_.classNo = DataRead["classNo"].ToString();
                class_.className = DataRead["className"].ToString();
                class_.banzhuren = DataRead["banzhuren"].ToString();
                class_.beginTime = Convert.ToDateTime(DataRead["beginTime"].ToString());
            }
            return class_;
        }

        /*更新班级信息实现*/
        public static bool EditClass_(ENTITY.Class_ class_)
        {
            string sql = "update Class_ set className=@className,banzhuren=@banzhuren,beginTime=@beginTime where classNo=@classNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@banzhuren",SqlDbType.VarChar),
             new SqlParameter("@beginTime",SqlDbType.DateTime),
             new SqlParameter("@classNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = class_.className;
            parm[1].Value = class_.banzhuren;
            parm[2].Value = class_.beginTime;
            parm[3].Value = class_.classNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除班级信息*/
        public static bool DelClass_(string p)
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
            sql = "delete from Class_ where classNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询班级信息*/
        public static System.Data.DataTable GetClass_(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Class_";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "classNo", strShow, strSql, strWhere, " classNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllClass_()
        {
            try
            {
                string strSql = "select * from Class_";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
