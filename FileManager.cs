using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BaseProject.Tools
{
    public class FileManager
    {
        public void WriteToFile(string fileName, IEnumerable<string> values, string seperate=null)
        {
            using (var fileStream = new StreamWriter(fileName,false,Encoding.UTF8))
            {
                var writingText = String.Join(seperate ??" ", values);
                fileStream.Write(writingText);

            }
        }

        public void WriteToTemp(IEnumerable<string> values,string fileName, string seperate = null)
        {
            var filePath = Path.Combine(Path.GetTempPath(),fileName);
            WriteToFile(filePath, values, seperate);
        }

        public string GetfolderNamesFromTempFile(string fileName)
        {
            var path = Path.Combine(Path.GetTempPath(), fileName);
            string values = "";
            if (!File.Exists(path))
            {
                return null ;
            }

            using (var fileStream = new StreamReader(path))
            {
                values =fileStream.ReadToEnd();
            }
            return values;
        }
        public string GetFileName(string path)
        {
            var values = path.Replace("\\","/").Split("/");
            return values[values.Length - 1];
        }
    }
}
