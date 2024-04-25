using Microsoft.Data.SqlClient;

namespace MMSDotNetCore.ConsoleApp;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true
    };
}
