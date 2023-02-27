namespace LogWriter
{
    public class LogWriter
    {
        public string path { get; set; }
        public LogWriter(string path)
        {
            this.path = path;
            RemoveFile();
        }
        // Save the log to a file
        public void SaveLog(string log)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                // Create a new file
                string file = Path.Combine(path, DateTime.Now.ToString("dd-MM-yyyy-hh") + "-log.txt");
                if (!File.Exists(file))
                {
                    File.Create(file);
                }
                // Write the log to the file
                using (StreamWriter writer = File.AppendText(file))
                {
                    writer.WriteLine("[" + DateTime.Now.ToString("dd-MM-yy hh:mm:ss") + "] --> " + log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Save(string log)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                // Create a new file
                string file = Path.Combine(path, DateTime.Now.ToString("dd-MM-yyyy-hh") + "-log.txt");
                if (!File.Exists(file))
                {
                    File.Create(file);
                }
                // Write the log to the file
                using (StreamWriter writer = File.AppendText(file))
                {
                    writer.WriteLine("[" + DateTime.Now.ToString("dd-MM-yy hh:mm:ss") + "] --> " + log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void RemoveFile()
        {
            try
            {
                // File all
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    // Remove file 30 day
                    if (File.GetCreationTime(file) < DateTime.Now.AddDays(-30))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}