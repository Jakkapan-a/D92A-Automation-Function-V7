using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class _IO
    {
        public int id { get; set; }
        public int action_id { get; set; }
        public string name { get; set; }  // Key
        public string _type { get; set; }
        public int dealy { get; set; }
        public int auto_dealy { get; set; }

        public _IO(int action_id) 
        {
            this.action_id = action_id;
            this._type = "AOTO";
            this.dealy = 1000;
            this.auto_dealy = 100;
        }

        #region Save IO
        public void Save()
        {
            string sql = "INSERT INTO io (action_id, name, _type, dealy, auto_dealy) VALUES (@action_id, @name, @_type, @dealy, @auto_dealy)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@action_id", action_id);
            parameters.Add("@name", name);
            parameters.Add("@_type", _type);
            parameters.Add("@dealy", dealy);
            parameters.Add("@auto_dealy", auto_dealy);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Update IO
        public void Update()
        {
            string sql = "UPDATE io SET action_id = @action_id, name = @name, _type = @_type, dealy = @dealy, auto_dealy = @auto_dealy WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@action_id", action_id);
            parameters.Add("@name", name);
            parameters.Add("@_type", _type);
            parameters.Add("@dealy", dealy);
            parameters.Add("@auto_dealy", auto_dealy);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Delete IO
        public void Delete()
        {
            string sql = "DELETE FROM io WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Load IO
        public static List<_IO> Load(int action_id)
        {
            string sql = "SELECT * FROM io WHERE action_id = @action_id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@action_id", action_id);
            return SQliteDataAccess.LoadData<_IO>(sql, parameters);
        }
        #endregion
    }
}
