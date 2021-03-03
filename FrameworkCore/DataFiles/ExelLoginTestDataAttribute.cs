using System.Collections;
using System.Collections.Generic;

namespace FrameworkCore.DataFiles
{
    public class ExelLoginTestDataAttribute : IEnumerable
    {
        List<object[]> Credentials = new List<object[]>();
        public ExelLoginTestDataAttribute()
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
    }
}

