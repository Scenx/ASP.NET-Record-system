using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�༶��Ϣҵ���߼���ʵ��*/
    public class dalClass_
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӱ༶��Ϣʵ��*/
        public static bool AddClass_(ENTITY.Class_ class_)
        {
            string sql = "insert into Class_(classNo,className,banzhuren,beginTime) values(@classNo,@className,@banzhuren,@beginTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classNo",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@banzhuren",SqlDbType.VarChar),
             new SqlParameter("@beginTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = class_.classNo; //�༶���
            parm[1].Value = class_.className; //�༶����
            parm[2].Value = class_.banzhuren; //����������
            parm[3].Value = class_.beginTime; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����classNo��ȡĳ���༶��Ϣ��¼*/
        public static ENTITY.Class_ getSomeClass_(string classNo)
        {
            /*������ѯsql*/
            string sql = "select * from Class_ where classNo='" + classNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Class_ class_ = new ENTITY.Class_();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                class_.classNo = DataRead["classNo"].ToString();
                class_.className = DataRead["className"].ToString();
                class_.banzhuren = DataRead["banzhuren"].ToString();
                class_.beginTime = Convert.ToDateTime(DataRead["beginTime"].ToString());
            }
            return class_;
        }

        /*���°༶��Ϣʵ��*/
        public static bool EditClass_(ENTITY.Class_ class_)
        {
            string sql = "update Class_ set className=@className,banzhuren=@banzhuren,beginTime=@beginTime where classNo=@classNo";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@banzhuren",SqlDbType.VarChar),
             new SqlParameter("@beginTime",SqlDbType.DateTime),
             new SqlParameter("@classNo",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = class_.className;
            parm[1].Value = class_.banzhuren;
            parm[2].Value = class_.beginTime;
            parm[3].Value = class_.classNo;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���༶��Ϣ*/
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


        /*��ѯ�༶��Ϣ*/
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
