using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class Images
    {
        public int id { get; set; }
        public int action_id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public int status { get; set; }
        
        public Images(int action_id) {
            this.action_id = action_id;
            this.status = 1;
        }
        #region Save Image
        public void Save()
        {
            string sql = "INSERT INTO images (action_id, name, path, status) VALUES (@action_id, @name, @path, @status)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@action_id", action_id);
            parameters.Add("@name", name);
            parameters.Add("@path", path);
            parameters.Add("@status", status);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Update Image
        public void Update()
        {
            string sql = "UPDATE images SET action_id = @action_id, name = @name, path = @path, status = @status WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@action_id", action_id);
            parameters.Add("@name", name);
            parameters.Add("@path", path);
            parameters.Add("@status", status);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Delete Image
        public void Delete()
        {
            string sql = "DELETE FROM images WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion

        #region Load Images
        public static List<Images> LoadImages(int action_id)
        {
            string sql = "SELECT * FROM images WHERE action_id = @action_id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@action_id", action_id);
            return SQliteDataAccess.LoadData<Images>(sql, parameters);
        }
        #endregion
    }
}
