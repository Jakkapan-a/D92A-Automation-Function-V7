using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace D92A_Automation_Function_V7.modules
{
    internal class SQliteDataAccess
    {
        public static List<T> GetRow<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<T> output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }
        // GetAllNolimit
        public static List<T> GetAllNolimit<T>(string table_name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<T>("select * from " + table_name + " order by id desc", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<T> LoadData<T>(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<T> output = cnn.Query<T>(sql, parameters);
                Console.WriteLine(output);
                return output.ToList();
            }
        }
        // Insert Update Delete
        public static void Execute(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Execute(sql, parameters);
            }
        }
        public static void Delete(string table_name,int id)
        {
            Execute("DELETE FROM " + table_name + " WHERE id = @id", new Dictionary<string, object> { { "@id", id } });
        }
        private static string LoadConnectionString(string id = "Default")=> "Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\" + ConfigurationManager.ConnectionStrings[id];

        internal static int GetScalar(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.ExecuteScalar<int>(sql, parameters);
            }
        }
    }
}
