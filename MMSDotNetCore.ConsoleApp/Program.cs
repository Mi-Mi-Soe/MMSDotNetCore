using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";
stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";
stringBuilder.TrustServerCertificate = true;
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("Connection open successful");

string query = "select * from Tbl_Blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection close successful");

//dataset => datatable
//datatable => datarow
//datarow => datacolumn

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("BlogId => " + dr["BlogId"]);
    Console.WriteLine("BlogTitle => " + dr["BlogTitle"]);
    Console.WriteLine("BlogAuthor => " + dr["BlogAuthor"]);
    Console.WriteLine("BlogContent => " + dr["BlogContent"]);
    Console.WriteLine("---------------------------------------");
}

//Ado .Net Read
Console.ReadKey();




