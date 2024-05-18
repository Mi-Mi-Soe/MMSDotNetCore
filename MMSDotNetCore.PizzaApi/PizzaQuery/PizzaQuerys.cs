namespace MMSDotNetCore.PizzaApi.PizzaQuery
{
    public class PizzaQuerys
    {
        public static string PizzaOrderQuery { get; } = @"select po.*,p.PizzaName,p.PizzaPrice 
                                                          from Tbl_PizzaOrder po inner join 
                                                          Tbl_Pizza p on p.PizzaId=po.PizzaId 
                                                          where po.PizzaOrderInvoiceNo=@PizzaOrderInvoiceNo";

        public static string PizzaOrderDetailQuery { get; } = @"select pod.*,ex.ExtraName,ex.ExtraPrice 
                                                               from Tbl_Extra ex inner join Tbl_PizzaOrderDetail pod 
                                                               on ex.ExtraId = pod.ExtraId
                                                                where pod.PizzaOrderInvoiceNo=@PizzaOrderInvoiceNo";
    }
}
