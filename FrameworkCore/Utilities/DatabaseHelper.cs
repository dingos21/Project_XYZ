using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

namespace FrameworkCore.Utilities
{
    public static class DatabaseHelper
    {
        // set-open DB connection
        public static SqlConnection setOpenConnection(string connectionString)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
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
        public static void closeConnection(this SqlConnection sqlConnection)
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
        public static DataTable ExecuteQuery(string connectionString, string queryString)
        {
            DataSet dataset;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                // Checking state of connection before exequte query
                if (sqlConnection == null || ((sqlConnection != null &&
                   (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)))) ;
                sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;
                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                DataTable Table = dataset.Tables["table"];
                DataRow dataRow = Table.Rows[0];
                //================================================================
                //             print out - log options
                //================================================================
                //Console.WriteLine(dataRow[0].ToString());
                //Console.WriteLine("=========================================1");
                //Console.WriteLine(dataRow[1].ToString());
                //Console.WriteLine("=========================================1");
                //Console.WriteLine(dataRow[2].ToString());
                //Console.WriteLine("=========================================1");
                //Console.WriteLine(Table.Rows.Count.ToString());
                //Console.WriteLine("=========================================2");
                //Console.WriteLine(Table.Rows[0].ItemArray.Length);
                //Console.WriteLine("=========================================3");
                //Console.WriteLine(Table.Rows[0].ItemArray.First());
                //Console.WriteLine("=========================================4");

                foreach (DataRow dataRoww in Table.Rows)
                {
                    foreach (var item in dataRoww.ItemArray)
                    {
                        Console.Write(item.ToString() + " | ");
                    }
                }
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

        public static string getDatabaseTableCellValue(string connectionString, string queryString, int rowNumber, int colNumber)
        {
            DataSet dataset;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                // Checking state of connection before exequte query
                if (sqlConnection == null || ((sqlConnection != null &&
                   (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)))) ;
                sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;
                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                DataTable Table = dataset.Tables["table"];
                try
                {
                    DataRow dataRow = Table.Rows[rowNumber - 1];
                    string cellValue = dataRow[colNumber - 1].ToString();
                    Console.WriteLine("On the query table; row :" + rowNumber + " and column :" + colNumber + " value is : " + cellValue);
                    return cellValue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Row  or(and)  Column  number(s)  is(are)  OUT OF RANGE... ");
                    throw;
                }
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

        public static string getDatabaseTableCellValue(string connectionString, string query, int rowNumber, string colName)
        {
            List<String> columns = getColumnNames_Query(connectionString, query);
            int colNumber = columns.IndexOf(colName);
            DataSet dataset;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                // Checking state of connection before exequte query
                if (sqlConnection == null || ((sqlConnection != null &&
                   (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)))) ;
                sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(query, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;
                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                DataTable Table = dataset.Tables["table"];
                
                try
                {
                    DataRow dataRow = Table.Rows[rowNumber - 1];
                    string cellValue = dataRow[colNumber].ToString();
                    Console.WriteLine("The query table row :" + rowNumber + ",     " + colName + "  is:  " + cellValue);
                    return cellValue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Row  or(and)  Column  number(s)  is(are)  OUT OF RANGE... ");
                    throw;
                }
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

        public static List<string> getDatabaseTableCertainColumnValues(string connectionString, string query, string colName)
        {
            List<String> columns = getColumnNames_Query(connectionString, query);
            List<String> columnValues = new List<string>();
            int colNumber = columns.IndexOf(colName);
            DataSet dataset;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                // Checking state of connection before exequte query
                if (sqlConnection == null || ((sqlConnection != null &&
                   (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)))) ;
                sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(query, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;
                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                DataTable Table = dataset.Tables["table"];
                try
                {
                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        DataRow dataRow = Table.Rows[i];
                        string cellValue = dataRow[colNumber].ToString();
                        Console.WriteLine("The query table row :" + i + ",     " + colName + "  is:  " + cellValue);
                        columnValues.Add(cellValue);
                        
                    }
                    return columnValues;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Row  or(and)  Column  number(s)  is(are)  OUT OF RANGE... ");
                    throw;
                }
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

        public static List<string> getColumnNames_Table(String connectionName, String tableName)
        {
            List<String> columns = new List<string>();
            using (SqlConnection connection = setOpenConnection(connectionName))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("SELECT * FROM {0}", tableName);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable schemaTable = reader.GetSchemaTable();
                foreach (DataRow myField in schemaTable.Rows)
                {
                    columns.Add(myField["ColumnName"].ToString());
                }
            }
            return columns;
        }

        public static List<string> getColumnNames_Query(String connectionName, String queryString)
        {
            List<String> columns = new List<string>();
            using (SqlConnection connection = setOpenConnection(connectionName))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format(queryString);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable schemaTable = reader.GetSchemaTable();
                foreach (DataRow myField in schemaTable.Rows)
                {
                    //Console.WriteLine(myField["ColumnName"].ToString());
                    columns.Add(myField["ColumnName"].ToString());
                }
            }
            return columns;
        }

        public static List<string> getColumns(DataTableReader reader)
        {
            List<String> columns = new List<string>();
            DataTable schemaTable = reader.GetSchemaTable();
            foreach (DataRow myField in schemaTable.Rows)
            {
                columns.Add(myField["ColumnName"].ToString());
            }
            return columns;
        }

        public static void exportDataSetToCsv(String connectionName, String queryString, String fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                SqlConnection connection = setOpenConnection(connectionName);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format(queryString);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable schemaTable = reader.GetSchemaTable();

                foreach (DataRow myField in schemaTable.Rows)
                {
                    file.Write(myField["ColumnName"].ToString() + ", ");
                }
                file.WriteLine();
                while (reader.Read())
                {
                    Object[] objs = new Object[reader.FieldCount];
                    reader.GetValues(objs);
                    foreach (object o in objs)
                    {
                        file.Write(o.ToString() + ", ");
                    }
                    file.WriteLine();
                }
            }
        }


        public static void exportDataSetToCsv(DataTableReader reader, String fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            using (DataTable schemaTable = reader.GetSchemaTable())
            {
                foreach (DataRow myField in schemaTable.Rows)
                {
                    file.Write(myField["ColumnName"].ToString() + ", ");
                }
                file.WriteLine();
                while (reader.Read())
                {
                    Object[] objs = new Object[reader.FieldCount];
                    reader.GetValues(objs);
                    foreach (object o in objs)
                    {
                        file.Write(o.ToString() + ", ");
                    }
                    file.WriteLine();
                }
            }
        }

        //---------------------------------------------------------------------------------------

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
