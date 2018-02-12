using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�γ���Ϣҵ���߼���ʵ��*/
    public class dalCourse_
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӿγ���Ϣʵ��*/
        public static bool AddCourse_(ENTITY.Course_ course_)
        {
            string sql = "insert into Course_(courseNo,courseName,teacherName,courseCount,courseScore) values(@courseNo,@courseName,@teacherName,@courseCount,@courseScore)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@courseCount",SqlDbType.Int),
             new SqlParameter("@courseScore",SqlDbType.Float)
            };
            /*��������ֵ*/
            parm[0].Value = course_.courseNo; //�γ̱��
            parm[1].Value = course_.courseName; //�γ�����
            parm[2].Value = course_.teacherName; //�ο���ʦ
            parm[3].Value = course_.courseCount; //�ܿ�ʱ
            parm[4].Value = course_.courseScore; //�γ�ѧ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����courseNo��ȡĳ���γ���Ϣ��¼*/
        public static ENTITY.Course_ getSomeCourse_(string courseNo)
        {
            /*������ѯsql*/
            string sql = "select * from Course_ where courseNo='" + courseNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Course_ course_ = new ENTITY.Course_();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���¿γ���Ϣʵ��*/
        public static bool EditCourse_(ENTITY.Course_ course_)
        {
            string sql = "update Course_ set courseName=@courseName,teacherName=@teacherName,courseCount=@courseCount,courseScore=@courseScore where courseNo=@courseNo";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@courseCount",SqlDbType.Int),
             new SqlParameter("@courseScore",SqlDbType.Float),
             new SqlParameter("@courseNo",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = course_.courseName;
            parm[1].Value = course_.teacherName;
            parm[2].Value = course_.courseCount;
            parm[3].Value = course_.courseScore;
            parm[4].Value = course_.courseNo;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���γ���Ϣ*/
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


        /*��ѯ�γ���Ϣ*/
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
