using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.DataFiles
{
    public class FileDirectory
    {

        public static readonly string FileLoc1 = @"C:\Users\OTurkakin\.......\CredentialsTest1.xlsx";
        public static readonly string FileLoc2 = @"C:\Users\OTurkakin\........\CredentialsTest2.xlsx";
        public static readonly string FileLoc3 = @"C:\DataDriven\CredentialsTest.xlsx";

        public string FileLocation { get; private set; }
        private FileDirectory(string fileLoc)
        {
            FileLocation = fileLoc;
        }
        public string GetFileLocation() { return FileLocation; }

    }
}
