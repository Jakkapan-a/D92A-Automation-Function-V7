using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class Items
    {
        public int id { get; set; }
        public string name { get; set; }
        public int model_id { get; set; }
        public int _index { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        
        public Items(int model_id) {
            this.model_id = model_id;
        }

        #region Save Item
        public void Save()
        {
            string sql = "INSERT INTO items (name, model_id, _index, created_at, updated_at) VALUES (@name, @model_id, @_index, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@model_id", model_id);
            parameters.Add("@_index", _index);
            parameters.Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Update Item
        public void Update()
        {
            string sql = "UPDATE items SET name = @name, model_id = @model_id, _index = @_index, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@name", name);
            parameters.Add("@model_id", model_id);
            parameters.Add("@_index", _index);
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Delete Item
        public void Delete()
        {
            string sql = "DELETE FROM items WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
    }
}
