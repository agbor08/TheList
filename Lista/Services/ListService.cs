using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Lista.Services
{
    public class ListService : IListService
    {
        private string path;

        public ListService()
        {
            path = ConfigurationManager.AppSettings.Get("ServerFilePath");
        }

        public void AddToFile (string listItem)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(listItem);
            }
        }

        public IEnumerable<string> ReadListFromFile()
        {
            IEnumerable<string> listFromFile = new List<string>();

            listFromFile = File.ReadAllLines(path);
            return listFromFile;
        }

        public void ClearListFile()
        {
            File.WriteAllText(path, String.Empty);
        }
    }
}