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
            Credentials.Add(new object[] { "userName1", "password1" });
            Credentials.Add(new object[] { "userName2", "password2" });
            Credentials.Add(new object[] { "userName3", "password3" });
            Credentials.Add(new object[] { "userName4", "password4" });

        }
        public IEnumerator GetEnumerator()
        {
            return Credentials.GetEnumerator();
        }


    }
}

