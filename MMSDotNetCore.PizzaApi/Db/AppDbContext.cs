namespace MMSDotNetCore.PizzaApi.Db;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<PizzaModel> Pizzas { get; set; }   
    public DbSet<ExtraModel> Extras { get; set; }
    public DbSet<PizzaOrderModel> PizzaOrder { get; set; }
    public DbSet<PizzaOrderDetailModel> PizzaOrderDetail { get; set; }

}


