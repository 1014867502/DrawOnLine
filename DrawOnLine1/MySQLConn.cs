using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawOnLine1
{
    class MySQLConn
    {
        private static string MySqlCon = "Database=test;Data Source=127.0.0.1;User Id=root;" +
     "Password=123;pooling=false;CharSet=utf8;port=3306";//配置数据库
        public DataTable ExecuteQuery(string sqlstr)//连接数据库，并执行查询语句
        {
            MySqlConnection con = new MySqlConnection(MySqlCon);//创建数据库连接类
            con.Open();//开启数据库
            MySqlCommand cmd = new MySqlCommand(sqlstr, con);//执行命令
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();//创建一个表的类
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);//MySQL适配器
            msda.Fill(dt);//
            con.Close();
            return dt;
        }

        public int ExecuteUpdate(string sqlStr)//执行更新方法，返回值int
        {
            MySqlCommand cmd;
            MySqlConnection con;
            con = new MySqlConnection(MySqlCon);
            con.Open();
            cmd = new MySqlCommand(sqlStr, con);
            cmd.CommandType = CommandType.Text;
            int iud = 0;
            iud = cmd.ExecuteNonQuery();
            con.Close();
            return iud;
        }

        public float[] GetResult(string sqlstr, string Lname)//将数据库中的数据提取出来组成数组，Lname代表的是数据表中的列名
        {
            var List = new List<float>();//创建一个float的list类型
            MySqlConnection con = new MySqlConnection(MySqlCon);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlstr, con);
            MySqlDataReader reader = cmd.ExecuteReader();//执行完命令的reader流
            float[] c = new float[1];
            try
            {
                while (reader.Read())//循环读取数据
                {
                    if (reader.HasRows)//判断是否行为空
                    {
                        //Console.WriteLine(reader.GetString(reader.GetOrdinal(Lname)));
                        List.Add(reader.GetFloat(reader.GetOrdinal(Lname)));//取出与Lname名字相同的列中的数据，添加到list中
                    }
                }
                float[] b = List.ToArray();//将list转化为数组类型
                return b;//返回
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("查询失败!" + ex.Message);
                return c;
            }
            finally
            {
                reader.Close();
            }

        }

        public DateTime[] GetResult2(string sqlstr, string Lname)//将数据库中的数据提取出来组成数组，Lname代表的是数据表中的列名
        {
            var List = new List<DateTime>();//创建一个float的list类型
            MySqlConnection con = new MySqlConnection(MySqlCon);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlstr, con);
            MySqlDataReader reader = cmd.ExecuteReader();//执行完命令的reader流
            DateTime[] c = new DateTime[1];
            try
            {
                while (reader.Read())//循环读取数据
                {
                    if (reader.HasRows)//判断是否行为空
                    {
                        //Console.WriteLine(reader.GetString(reader.GetOrdinal(Lname)));
                        List.Add(reader.GetDateTime(reader.GetOrdinal(Lname)));//取出与Lname名字相同的列中的数据，添加到list中
                    }
                }
                DateTime[] b = List.ToArray();//将list转化为数组类型
                return b;//返回
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("查询失败!" + ex.Message);
                return c;
            }
            finally
            {
                reader.Close();
            }

        }
    }
}
