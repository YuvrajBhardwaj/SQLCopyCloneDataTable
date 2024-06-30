using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLCopyCloneDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from employee";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable employee = new DataTable();
                sda.Fill(employee);
                Console.WriteLine("Original DataTable");
                foreach (DataRow row in employee.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["FirstName"] + " " + row["MName"]+" "+row["LastName"]);
                    Console.ReadKey();
                }
                DataTable CopyDataTable = employee.Copy();
                Console.WriteLine("Original DataTable");
                foreach (DataRow row in CopyDataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["FirstName"] + " " + row["MName"] + " " + row["LastName"]);
                    
                }
                
                DataTable CloneDataTable = employee.Clone();
                Console.WriteLine("Clone DataTable");
                if (CloneDataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in CloneDataTable.Rows)
                    {
                        Console.WriteLine(row["id"] + " " + row["FirstName"] + " " + row["MName"] + " " + row["LastName"]);
                        
                    }
                }
                else
                {
                    //Console.WriteLine("Rows not Found!!");
                    CloneDataTable.Rows.Add(1, "Dakshita", "", "Verma");
                    CloneDataTable.Rows.Add(2, "Yuvraj", "", "Bhardwaj");
                }
                foreach (DataRow row in CloneDataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["FirstName"] + " " + row["MName"] + " " + row["LastName"]);

                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
