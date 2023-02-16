using D92A_Automation_Function_V7.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class Actions
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public string name { get; set; }
        public int _type { get; set; }          // 0 = IO, 1 = Image
        public string image_path { get; set; }
        public int image_percent { get; set; }
        public int image_status { get; set; }
        public string io_port { get; set; }
        public string io_name { get; set; }
        public int io_type { get; set; }        // 0 = Manual, 1 = Auto, 2 = Wait judment
        public int io_state { get; set; }       // Active in io_type = 0;
        public int io_timeout { get; set; }     // Second
        public int delay { get; set; }          // Active after end process = 0;
        public int auto_delay { get; set; }     // Active in Auto = 0;
        public string created_at { get; set; }
        public string updated_at { get; set; }

        #region Save Action
        public void Save()
        {
            string sql = "INSERT INTO actions (item_id, name, _type, image_path, image_percent, image_status, io_port, io_name, io_type, io_state,io_timeout, delay, auto_delay,created_at,updated_at) VALUES (@item_id, @name, @_type, @image_path, @image_percent, @image_status, @io_port, @io_name, @io_type, @io_state,@io_timeout, @delay, @auto_delay,@created_at,@updated_at)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@item_id", item_id);
            parameters.Add("@name", name);
            parameters.Add("@_type", _type);
            parameters.Add("@image_path", image_path);
            parameters.Add("@image_percent", image_percent);
            parameters.Add("@image_status", image_status);
            parameters.Add("@io_port", io_port);
            parameters.Add("@io_name", io_name);
            parameters.Add("@io_type", io_type);
            parameters.Add("@io_state", io_state);
            parameters.Add("@io_timeout", io_timeout);
            parameters.Add("@delay", delay);
            parameters.Add("@auto_delay", auto_delay);
            parameters.Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
        #region Update Action
        public void Update()
        {
            string sql = "UPDATE actions SET item_id = @item_id, name = @name, _type = @_type, image_path = @image_path, image_percent = @image_percent, image_status = @image_status, io_port = @io_port, io_name = @io_name, io_type = @io_type, io_state = @io_state, delay = @delay, auto_delay = @auto_delay, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@item_id", item_id);
            parameters.Add("@name", name);
            parameters.Add("@_type", _type);
            parameters.Add("@image_path", image_path);
            parameters.Add("@image_percent", image_percent);
            parameters.Add("@image_status", image_status);
            parameters.Add("@io_port", io_port);
            parameters.Add("@io_name", io_name);
            parameters.Add("@io_type", io_type);
            parameters.Add("@io_state", io_state);
            parameters.Add("@delay", delay);
            parameters.Add("@auto_delay", auto_delay);
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
        #region Update ToTemp
        public static void ToTemp(int id)
        {
            string sql = "UPDATE actions SET image_status = @image_status, updated_at = @updated_at WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@image_status", 0);
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SQliteDataAccess.Execute(sql, parameters);
        }
        #endregion
        #region Update DeleteTemp
        public static void DeleteTemp()
        {
            var actionListTemp = modules.Actions.GetTemp();
            LogWriter log = new LogWriter(Properties.Resources.path_log);
            foreach (var item in actionListTemp)
            {
                try
                {
                    if (item._type == 1)
                    {
                        if (File.Exists(item.image_path))
                            File.Delete(item.image_path);

                    }
                    item.Delete();
                }catch (Exception ex) {
                    log.SaveLog("Error " + ex.Message);
                }
                item.Delete();
            }
        }
        public static List<modules.Actions> GetTemp()
        {
            string sql = "SELECT * FROM actions WHERE image_status = @image_status";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@image_status", 0);
            return SQliteDataAccess.LoadData<modules.Actions>(sql, parameters);
        }
        #endregion
        #region byItemToTemp
        public static void byItemToTemp(int item_id)
        {
            string sql = "UPDATE actions SET image_status = @image_status, updated_at = @updated_at WHERE item_id = @item_id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@item_id", item_id);
            parameters.Add("@image_status", 0);
            parameters.Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        #region Get Action
        public static List<Actions> LoadActionsID(int item_id)
        {
            string sql = "SELECT * FROM actions WHERE item_id = @item_id AND image_status = 1";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@item_id", item_id);
            return SQliteDataAccess.LoadData<modules.Actions>(sql, parameters);
        }
        #endregion
        //Get Action ID
        public static List<Actions> LoadActionsByID(int action_id)
        {
            string sql = "SELECT * FROM actions WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", action_id);
            return SQliteDataAccess.LoadData<modules.Actions>(sql, parameters);
        }

    }
}
