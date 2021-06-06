using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace FrameworkCore.DataFiles
{
    public static class DatabaseConnection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet executeQuery(String connectionString, String query, List<SqlParameter> parameters)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection connection = setConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 600;
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters.ToArray<SqlParameter>());
                }
                adapter.Fill(dataset);
                return dataset;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet executeQuery(String connectionName, String query)
        {
            return executeQuery(connectionName, query, null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static SqlConnection setConnection(String connectionString)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fileName"></param>
        public static void exportDataSetToCsv(DataTableReader reader, String fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        public static List<string> getColumns(String connectionName, String tableName)
        {
            List<String> columns = new List<string>();
            using (SqlConnection connection = setConnection(connectionName))
            {
                connection.Open();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
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
    }
}
