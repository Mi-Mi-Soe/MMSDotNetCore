using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMSDotNetCore.PizzaApi.Models
{
    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
        [NotMapped]
        public string Pirce { get { return "$" + PizzaPrice; } }
    }

    [Table("Tbl_Extra")]
    public class ExtraModel
    {
        [Key]
        public int ExtraId { get; set; }
        public string ExtraName { get; set; }
        public decimal ExtraPrice { get; set; }
    }

    public class PizzaOrderRequestModel
    {
        public int PizzaId { get; set; }
        public int[] ExtraList { get; set; }
    }

    [Table("Tbl_PizzaOrder")]
    public class PizzaOrderModel
    {
        [Key]
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalPrice { get; set; }
    }

    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int ExtraId { get; set; }
    }

    public class PizzaOrderResponseModel
    {
        public string PizzaInvoiceNo { get; set; }
        public decimal TotalPirce { get; set; }
        public string Message { get; set; }
    }
}
