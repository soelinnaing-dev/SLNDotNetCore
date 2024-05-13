using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace SLNDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private string _connectionString;
        public AdoDotNetService(string connectionString)
        {       
            _connectionString = connectionString;          
        }
        public List<T> Query<T>(string query, AdoDotNetParameter[] parameter = null!)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (parameter != null && parameter.Length>0)
            {
                //foreach( var param in parameter )
                //{
                //   cmd.Parameters.AddWithValue(param.Name,param.Value);
                //}
                cmd.Parameters.AddRange(parameter.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());
            }          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<T>lst = JsonConvert.DeserializeObject<List<T>>(json)!;
            return lst;
        }
        public T QueryFirstOrDefault<T>(string query, AdoDotNetParameter[] parameter = null!)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (parameter != null && parameter.Length > 0)
            {
                //foreach( var param in parameter )
                //{
                //   cmd.Parameters.AddWithValue(param.Name,param.Value);
                //}
                cmd.Parameters.AddRange(parameter.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count>0)
            {
                string json = JsonConvert.SerializeObject(dt);
                List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!;
                return lst[0];
            }
            else
            {
                return default;
            }
        }
        public int Execute(string query, params AdoDotNetParameter[] parameter)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (parameter != null && parameter.Length > 0)
            {
                //foreach( var param in parameter )
                //{
                //   cmd.Parameters.AddWithValue(param.Name,param.Value);
                //}
                cmd.Parameters.AddRange(parameter.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            return result;
            
        }
    }

    public class AdoDotNetParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public AdoDotNetParameter() { }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
