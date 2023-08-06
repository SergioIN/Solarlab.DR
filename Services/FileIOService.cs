using Newtonsoft.Json;
using Solarlab.DR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarlab.DR.Services
{
    internal class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<Models1> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Models1>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Models1>>(fileText);

            }    
        }
        public void SaveData(object dataDr)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(dataDr);
                writer.Write(output); 
            }
        }

    }
}
