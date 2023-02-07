using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class History
    {
        public int id { get; set; }
        public string employee_id { get; set; }
        public string serial_no { get; set; }
        public string result { get; set; }
        public string created_at { get; set; }        
        public string updated_at { get; set;}

        public void Save()
        {
            string sql = "INSERT INTO history (employee_id, serial_no, result, created_at, updated_at) VALUES (@employee_id, @serial_no, @result, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@employee_id", employee_id);
            parameters.Add("@serial_no", serial_no);
            parameters.Add("@result", result);
            parameters.Add("@created_at", SQliteDataAccess.getDateTimeNow);
            parameters.Add("@updated_at", SQliteDataAccess.getDateTimeNow);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update()
        {
            string sql = "UPDATE history SET employee_id = @employee_id, serial_no = @serial_no, result = @result, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@employee_id", employee_id);
            parameters.Add("@serial_no", serial_no);
            parameters.Add("@result", result);
            parameters.Add("@updated_at", SQliteDataAccess.getDateTimeNow);
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Delete()
        {
            string sql = "DELETE FROM history WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public static List<History> Load()
        {
            string sql = "SELECT * FROM history";
            return SQliteDataAccess.GetRow<History>(sql);
        }
    }
}
