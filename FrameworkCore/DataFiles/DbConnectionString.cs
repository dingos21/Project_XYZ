using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.DataFiles
{
    public class DbConnectionString
    {

        public static readonly string DbConnectionStr1 = "Data Source=DS-SQLTEST-14.RD.as.local;User ID = svcPIMSTest; Password=b5!6V^G;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static readonly string DbConnectionStr2 = "";
        public static readonly string DbConnectionStr3 = "";

        public string DbConnectionStr { get; private set; }
        private DbConnectionString(string ConnectionStr)
        {
            DbConnectionStr = ConnectionStr;
        }
        public string GetDbConnectionStr() { return DbConnectionStr; }

    }
}
