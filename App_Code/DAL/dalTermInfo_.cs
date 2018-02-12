using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学期信息业务逻辑层实现*/
    public class dalTermInfo_
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学期信息实现*/
        public static bool AddTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            string sql = "insert into TermInfo_(termName) values(@termName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@termName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = termInfo_.termName; //学期名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据termId获取某条学期信息记录*/
        public static ENTITY.TermInfo_ getSomeTermInfo_(int termId)
        {
            /*构建查询sql*/
            string sql = "select * from TermInfo_ where termId=" + termId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TermInfo_ termInfo_ = new ENTITY.TermInfo_();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                termInfo_.termId = Convert.ToInt32(DataRead["termId"]);
                termInfo_.termName = DataRead["termName"].ToString();
            }
            return termInfo_;
        }

        /*更新学期信息实现*/
        public static bool EditTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            string sql = "update TermInfo_ set termName=@termName where termId=@termId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@termName",SqlDbType.VarChar),
             new SqlParameter("@termId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = termInfo_.termName;
            parm[1].Value = termInfo_.termId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学期信息*/
        public static bool DelTermInfo_(string p)
        {
            string sql = "delete from TermInfo_ where termId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学期信息*/
        public static System.Data.DataTable GetTermInfo_(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from TermInfo_";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "termId", strShow, strSql, strWhere, " termId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTermInfo_()
        {
            try
            {
                string strSql = "select * from TermInfo_";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
