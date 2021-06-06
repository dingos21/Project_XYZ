using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace FrameworkCore.Utilities
{
    public static class DataHelperExtensions
    {
        // open DB connection
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to connect to DB \"" + connectionString + "\"");
            }
            return null;
        }

        // close DB connection
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to close to DB ");

            }
        }

        // Execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;
            try
            {
                // Checking state of connection before exequte query
                if (sqlConnection == null || ((sqlConnection != null && 
                   (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken) )));
                sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                DataTable Table = dataset.Tables["table"];
                Console.WriteLine(Table.Rows.Count.ToString());
                Console.WriteLine("=========================================1");
                Console.WriteLine(Table.Rows[0].ItemArray.Length);

                Console.WriteLine("=========================================2");
                Console.WriteLine(Table.Rows[0].ItemArray.First());
                Console.WriteLine("=========================================3");
                List<string> s = new List<string>();
                string[] a = new string[3];
                    
                //Table.Rows[0].ItemArray.CopyTo(a, 0);
                //Console.WriteLine(a[0]);
                //Console.WriteLine("=========================================4");
                //Console.WriteLine(Table.Rows[0].ItemArray.ToString());
                //Console.WriteLine("=========================================5");
                //Console.WriteLine(Table.Rows[0].ToString());
                //Console.WriteLine("=========================================6");
                //Console.WriteLine(Table.Rows.ToString());
                foreach (DataRow dataRow in Table.Rows)
                {
                    Console.WriteLine(dataRow[0].ToString());
                    Console.WriteLine("=========================================");
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.Write(item.ToString() + " | ");
                    }
                }

                //Console.WriteLine("=========================================");
                //foreach (DataColumn dataColumn in Table.Columns)
                //{
                //    //dataRow
                //    foreach (var item in dataColumn.ColumnName)
                //    {
                //        Console.Write(item.ToString() );
                //    }
                //}

                return Table;

            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                Console.WriteLine("Not able to exequte query");
                return null;
            }
            finally
            {
                dataset = null;
                sqlConnection.Close();

            }

        }




    }
}
