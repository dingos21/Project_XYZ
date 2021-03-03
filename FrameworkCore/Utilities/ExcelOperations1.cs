using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Utilities

{
    public class ExcelOperations1
    {
        static FileStream stream;

        private static DataTable ExcelToDataTable(string fileURL, string SheetName)
        {
            stream = File.Open(fileURL, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);


            // to not get first row as data set
            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table[SheetName];               // Sheet Name
            //stream.Flush();
            stream.Close();
            return resultTable;
        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static int totalRorCout = 0;
        public static int GetTotalRowcount()
        {
            return totalRorCout;
        }

        static List<Datacollection> dataCol = new List<Datacollection>();
        public static void PopulateInColection(string fileURL, string SheetName = "Sheet1")
        {
            DataTable table = ExcelToDataTable(fileURL, SheetName);
            totalRorCout = table.Rows.Count;
            for (int rov = 1; rov < table.Rows.Count; rov++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = rov,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[rov - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                return null;
            }
            finally
            {
                //stream.Flush();
                //stream.Close();
            }

        }


    }
}

