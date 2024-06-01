using System.Data.SqlClient;

namespace WinFormsAppSqlInjection;

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
