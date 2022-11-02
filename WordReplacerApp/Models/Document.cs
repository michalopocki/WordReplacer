using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReplacerApp.Models
{
    public class Document
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public Document(string fileName, string fullPath)
        {
            FileName = fileName;
            FullPath = fullPath;
        }
    }
}
