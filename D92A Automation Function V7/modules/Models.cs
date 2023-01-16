using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class Models
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        #region Save Model
        public void Save()
        {
            string sql = "INSERT INTO models (name, description, created_at, updated_at) VALUES (@name, @description, @created_at, @updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@description", description);
            parameters.Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
        
        #region Update Model
        public void Update()
        {
            string sql = "UPDATE models SET name = @name, description = @description, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@name", name);
            parameters.Add("@description", description);
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
        
        #region Delete Model
        public void Delete()
        {
            List<_ItemsList> items = _ItemsList.LoadItems(this.id);
            foreach (var item in items)
            {
                _ItemsList.Delete(item.id);
            }
            string sql = "DELETE FROM models WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
        #region Delete Model
        public static void Delete(int id)
        {
            List<_ItemsList> items = _ItemsList.LoadItems(id);
            foreach (var item in items)
            {
                _ItemsList.Delete(item.id);
            }
            string sql = "DELETE FROM models WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Get Model
        public static List<Models> GetModelsAll() => SQliteDataAccess.GetAllNolimit<Models>("models");
        #endregion

        #region Get Model by ID
        public static Models GetModelById(int id)
        {
            string sql = "SELECT * FROM models WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return SQliteDataAccess.LoadData<Models>(sql, parameters).FirstOrDefault();
        }
        #endregion
    }
}
