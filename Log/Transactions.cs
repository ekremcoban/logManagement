using System;
using System.Collections.Generic;
using System.IO;

namespace Log
{
    public class Transactions
    {
        //C:\Users\ecoban\source\repos\Log\settings\project
        static string path = @"C:\Users\ecoban\source\repos\Log\settings\";
        ProjectSettings settings;
        List<Record> records;

        public Transactions(string projectName)
        {
            settings = new ProjectSettings();
            settings.ProjectName = projectName;
            GetProjectSetting();
            records = new List<Record>();
        }

        public bool NewRecord(Record record)
        {
            bool kayitDurum = false;

            if (settings != null && settings.CheckFile && settings.CheckAuthority)
            {
                string klasorAdi = DateTime.Now.ToString("yyyyMMdd");
                string tamYol = settings.MainPath + klasorAdi;

                if (!Directory.Exists(tamYol))
                {
                    Directory.CreateDirectory(tamYol);
                }

                if (File.Exists(tamYol + @"\Records.json"))
                {
                    string kayitlarJsonText = File.ReadAllText(tamYol + @"\Records.json");
                    records = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Record>>(kayitlarJsonText);
                    records.Add(record);
                }
                else
                {
                    records.Add(record);
                }

                File.WriteAllText(tamYol + @"\Records.json", Newtonsoft.Json.JsonConvert.SerializeObject(records));
                kayitDurum = true;
            }
            else
            {
                kayitDurum = false;
            }


            return kayitDurum;
        }

        #region Settings
        private void GetProjectSetting()
        {
            string fullPath = $"{path}{settings.ProjectName}\\Common.json";
            if(File.Exists(fullPath))
            {
                string projeJson = File.ReadAllText(fullPath);
                settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectSettings>(projeJson);
                settings.CheckFile = true;
                settings.CheckAuthority = NewRecord(settings.MainPath);
            }
            else
            {
                settings.CheckFile = false;
                settings.CheckAuthority = false;
            }
        }

        private bool NewRecord(string url)
        {
            bool kontrol = false;
            int countOfFile = Directory.GetFiles(url).Length;
            if(countOfFile <= 0)
            {
                FileStream fileStream = File.Create(url + "test.txt");
                if(File.Exists(url + "test.txt"))
                {
                    fileStream.Close();
                    File.Delete(url + "test.txt");
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                }
            }
            return kontrol;
        }
        #endregion
    }
}
