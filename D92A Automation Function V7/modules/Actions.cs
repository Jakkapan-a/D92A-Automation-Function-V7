using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class Actions
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public int _type { get; set; }
        public string name { get; set; }
        public int _index { get; set; }
        public string comment { get; set; }
        public Actions(int item_id) 
        {
            this.item_id = item_id;
        }

        #region Save Action
        public void Save()
        {
            string sql = "INSERT INTO actions (item_id, _type,name, _index, comment) VALUES (@item_id, @_type,@name, @_index, @comment)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@item_id", item_id);
            parameters.Add("@_type", _type);
            parameters.Add("@name", name);
            parameters.Add("@_index", _index);
            parameters.Add("@comment", comment);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Update Action
        public void Update()
        {
            string sql = "UPDATE actions SET item_id = @item_id, _type = @_type, name = @name, _index = @_index, comment = @comment WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@item_id", item_id);
            parameters.Add("@_type", _type);
            parameters.Add("@name", name);
            parameters.Add("@_index", _index);
            parameters.Add("@comment", comment);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Delete Action
        public void Delete()
        {
            string sql = "DELETE FROM actions WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Get Actions
        public static List<Actions> GetActions(int item_id)
        {
            string sql = "SELECT * FROM actions WHERE item_id = @item_id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@item_id", item_id);
            return SQliteDataAccess.LoadData<Actions>(sql, parameters);
        }
        #endregion
    }
}
