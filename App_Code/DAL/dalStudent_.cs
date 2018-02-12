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
    public class dalStudent_
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ����Ϣʵ��*/
        public static bool AddStudent_(ENTITY.Student_ student_)
        {
            string sql = "insert into Student_(studentNumber,studentName,sex,classInfo,birthday,zhengzhimianmao,telephone,address) values(@studentNumber,@studentName,@sex,@classInfo,@birthday,@zhengzhimianmao,@telephone,@address)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = student_.studentNumber; //ѧ��
            parm[1].Value = student_.studentName; //ѧ������
            parm[2].Value = student_.sex; //�Ա�
            parm[3].Value = student_.classInfo; //���ڰ༶
            parm[4].Value = student_.birthday; //��������
            parm[5].Value = student_.zhengzhimianmao; //������ò
            parm[6].Value = student_.telephone; //��ϵ�绰
            parm[7].Value = student_.address; //��ͥ��ַ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����studentNumber��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.Student_ getSomeStudent_(string studentNumber)
        {
            /*������ѯsql*/
            string sql = "select * from Student_ where studentNumber='" + studentNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student_ student_ = new ENTITY.Student_();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����ѧ����Ϣʵ��*/
        public static bool EditStudent_(ENTITY.Student_ student_)
        {
            string sql = "update Student_ set studentName=@studentName,sex=@sex,classInfo=@classInfo,birthday=@birthday,zhengzhimianmao=@zhengzhimianmao,telephone=@telephone,address=@address where studentNumber=@studentNumber";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = student_.studentName;
            parm[1].Value = student_.sex;
            parm[2].Value = student_.classInfo;
            parm[3].Value = student_.birthday;
            parm[4].Value = student_.zhengzhimianmao;
            parm[5].Value = student_.telephone;
            parm[6].Value = student_.address;
            parm[7].Value = student_.studentNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ����Ϣ*/
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


        /*��ѯѧ����Ϣ*/
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
