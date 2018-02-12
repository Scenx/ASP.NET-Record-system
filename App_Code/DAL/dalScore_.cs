using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�ɼ���Ϣҵ���߼���ʵ��*/
    public class dalScore_
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӳɼ���Ϣʵ��*/
        public static bool AddScore_(ENTITY.Score_ score_)
        {
            string sql = "insert into Score_(studentNo,courseNo,termId,score) values(@studentNo,@courseNo,@termId,@score)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@termId",SqlDbType.Int),
             new SqlParameter("@score",SqlDbType.Float)
            };
            /*��������ֵ*/
            parm[0].Value = score_.studentNo; //����ѧ��
            parm[1].Value = score_.courseNo; //�����γ�
            parm[2].Value = score_.termId; //����ѧ��
            parm[3].Value = score_.score; //�ɼ��÷�

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����scoreId��ȡĳ���ɼ���Ϣ��¼*/
        public static ENTITY.Score_ getSomeScore_(int scoreId)
        {
            /*������ѯsql*/
            string sql = "select * from Score_ where scoreId=" + scoreId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Score_ score_ = new ENTITY.Score_();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���³ɼ���Ϣʵ��*/
        public static bool EditScore_(ENTITY.Score_ score_)
        {
            string sql = "update Score_ set studentNo=@studentNo,courseNo=@courseNo,termId=@termId,score=@score where scoreId=@scoreId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@termId",SqlDbType.Int),
             new SqlParameter("@score",SqlDbType.Float),
             new SqlParameter("@scoreId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = score_.studentNo;
            parm[1].Value = score_.courseNo;
            parm[2].Value = score_.termId;
            parm[3].Value = score_.score;
            parm[4].Value = score_.scoreId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���ɼ���Ϣ*/
        public static bool DelScore_(string p)
        {
            string sql = "delete from Score_ where scoreId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�ɼ���Ϣ*/
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
