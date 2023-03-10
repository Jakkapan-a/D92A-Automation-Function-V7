using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class _ItemsList
    {
        public int id { get; set; }
        public string name { get; set; }
        public int model_id { get; set; }
        public int _type { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public void Save()
        {
            if (this.model_id == -1)
            {
                throw new Exception("Model ID is required");
            }
            string sql = "INSERT INTO itemslist (name, model_id,description , _type, created_at, updated_at) VALUES (@name, @model_id,@description, @_type, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", this.name);
            parameters.Add("@model_id", this.model_id);
            parameters.Add("@_type", this._type);
            parameters.Add("@description", this.description);
            parameters.Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update()
        {
            if (this.model_id == -1)
            {
                throw new Exception("Model ID is required");
            }
            string sql = "UPDATE itemslist SET name = @name, model_id = @model_id, description = @description, _type = @_type, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", this.name);
            parameters.Add("@model_id", this.model_id);
            parameters.Add("@_type", this._type);
            parameters.Add("@description", this.description);
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            parameters.Add("@id", this.id);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public static void Delete(int id) 
        {
            var actions = modules.Actions.LoadActionsID(id);
            foreach (var action in actions)
            {
                Actions.ToTemp(action.id);
            }
            string sql = "DELETE FROM itemslist WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }

        public static List<_ItemsList> LoadItems(int model_id)
        {
            string sql = "SELECT * FROM itemslist WHERE model_id = @model_id ORDER BY id ASC";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@model_id", model_id);
            return SQliteDataAccess.LoadData<_ItemsList>(sql, parameters);
        }

        public static _ItemsList LoadItemById(int id)
        {
            string sql = "SELECT * FROM itemslist WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return SQliteDataAccess.LoadData<_ItemsList>(sql, parameters).FirstOrDefault();
        }
    }
}
