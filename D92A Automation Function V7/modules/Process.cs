using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D92A_Automation_Function_V7.modules
{
    internal class Process
    {
        public static bool isModelsExist(string name)
        {
            string sql = "SELECT * FROM models WHERE name = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            List<Models> models = SQliteDataAccess.LoadData<Models>(sql, parameters);
            Console.WriteLine(models.Count);
            if (models.Count > 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
