using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*成绩信息业务逻辑层实现*/
    public class dalScore_
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加成绩信息实现*/
        public static bool AddScore_(ENTITY.Score_ score_)
        {
            string sql = "insert into Score_(studentNo,courseNo,termId,score) values(@studentNo,@courseNo,@termId,@score)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@termId",SqlDbType.Int),
             new SqlParameter("@score",SqlDbType.Float)
            };
            /*给参数赋值*/
            parm[0].Value = score_.studentNo; //所属学生
            parm[1].Value = score_.courseNo; //所属课程
            parm[2].Value = score_.termId; //所在学期
            parm[3].Value = score_.score; //成绩得分

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据scoreId获取某条成绩信息记录*/
        public static ENTITY.Score_ getSomeScore_(int scoreId)
        {
            /*构建查询sql*/
            string sql = "select * from Score_ where scoreId=" + scoreId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Score_ score_ = new ENTITY.Score_();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                score_.scoreId = Convert.ToInt32(DataRead["scoreId"]);
                score_.studentNo = DataRead["studentNo"].ToString();
                score_.courseNo = DataRead["courseNo"].ToString();
                score_.termId = Convert.ToInt32(DataRead["termId"]);
                score_.score = float.Parse(DataRead["score"].ToString());
            }
            return score_;
        }

        /*更新成绩信息实现*/
        public static bool EditScore_(ENTITY.Score_ score_)
        {
            string sql = "update Score_ set studentNo=@studentNo,courseNo=@courseNo,termId=@termId,score=@score where scoreId=@scoreId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@termId",SqlDbType.Int),
             new SqlParameter("@score",SqlDbType.Float),
             new SqlParameter("@scoreId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = score_.studentNo;
            parm[1].Value = score_.courseNo;
            parm[2].Value = score_.termId;
            parm[3].Value = score_.score;
            parm[4].Value = score_.scoreId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除成绩信息*/
        public static bool DelScore_(string p)
        {
            string sql = "delete from Score_ where scoreId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询成绩信息*/
        public static System.Data.DataTable GetScore_(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Score_";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "scoreId", strShow, strSql, strWhere, " scoreId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllScore_()
        {
            try
            {
                string strSql = "select * from Score_";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
