using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ����Ϣҵ���߼���ʵ��*/
    public class dalTermInfo_
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ����Ϣʵ��*/
        public static bool AddTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            string sql = "insert into TermInfo_(termName) values(@termName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@termName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = termInfo_.termName; //ѧ������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����termId��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.TermInfo_ getSomeTermInfo_(int termId)
        {
            /*������ѯsql*/
            string sql = "select * from TermInfo_ where termId=" + termId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TermInfo_ termInfo_ = new ENTITY.TermInfo_();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                termInfo_.termId = Convert.ToInt32(DataRead["termId"]);
                termInfo_.termName = DataRead["termName"].ToString();
            }
            return termInfo_;
        }

        /*����ѧ����Ϣʵ��*/
        public static bool EditTermInfo_(ENTITY.TermInfo_ termInfo_)
        {
            string sql = "update TermInfo_ set termName=@termName where termId=@termId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@termName",SqlDbType.VarChar),
             new SqlParameter("@termId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = termInfo_.termName;
            parm[1].Value = termInfo_.termId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ����Ϣ*/
        public static bool DelTermInfo_(string p)
        {
            string sql = "delete from TermInfo_ where termId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ����Ϣ*/
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
