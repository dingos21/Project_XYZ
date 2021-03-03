using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.DataFiles
{
    public class DataManager : IEnumerable
    {
        List<object[]> Credentials = new List<object[]>();
        public DataManager()
        {
            Credentials.Add(new object[] { "oturkakin", "ho17%#AK" });
            Credentials.Add(new object[] { "oturkakin", "ho17%#AK" });
            Credentials.Add(new object[] { "oturkakin", "ho17%#AK" });
            Credentials.Add(new object[] { "oturkakin", "ho17%#AK" });
        }
        public IEnumerator GetEnumerator()
        {
            return Credentials.GetEnumerator();
        }




        //public static object[] Credentialss =
        //{
        //    new object[] { "oturkakin", "ho17%#AK" },
        //    new object[] { "oturkakin", "ho17%#AK" },
        //    //new object[] { "oturkakin", "ho17%#AK" },
        //    //new object[] { "oturkakin", "ho17%#AK" },
        //};
    }
}

