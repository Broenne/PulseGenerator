using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseGenerator.InitData
{
    using System.IO;
    using System.Reflection;

    public class FileHelper : IFileHelper
    {


        public string GetPath()
        {
            var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var path = $@"{directoryPath}\init.conf";
            return path;
        }

    }
}
