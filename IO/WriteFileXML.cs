using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap.IO
{
    /// <summary>
    /// Class implements the logic to write a file.</summary>
    /// <remarks>
    /// </remarks>
    public class WriteFileXML : IWriteFileXML
    {
        /// <summary>
        /// Write the XML file on disk
        /// </summary>
        /// <param name="file">File to be recorded</param>
        /// <param name="path">Path where it is saved.</param>
        public void WriteFile(XDocument file, string path)
        {
            file.Save(path);
        }
    }
}
