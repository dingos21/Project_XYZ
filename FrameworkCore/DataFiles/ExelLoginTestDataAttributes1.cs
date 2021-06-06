using FrameworkCore.Utilities;
using System.Collections;
using System.Collections.Generic;

namespace FrameworkCore.DataFiles
{
    public class ExelLoginTestDataAttributes1 : IEnumerable
    {
        string fileLocation = FileDirectory.FileLoc1;
        string sheetName = "Sheet1";
        int rowsToRun = 3;
        //--------------------------------------------------------------------------------------

        List<object[]> Credentials = new List<object[]>();
        public ExelLoginTestDataAttributes1()
        {
            InitializeElements(fileLocation, sheetName, rowsToRun);
        }
        public IEnumerator GetEnumerator()
        {
            return Credentials.GetEnumerator();
        }

        private void InitializeElements(string fileSource, string sheetName, int rowsToRun)
        {
            ExcelOperations2.PopulateInColection(fileSource, sheetName);
            List<string> userNames = ExcelOperations2.getColumnData(rowsToRun, "userName");
            List<string> passwords = ExcelOperations2.getColumnData(rowsToRun, "password");

            for (int i = 0; i < rowsToRun; i++)
            {
                Credentials.Add(new object[] { userNames[i], passwords[i] });

            }

        }
    }
}

