using MMSDotNetCore.PizzaApi.PizzaQuery;
using MMSDotNetCore.Shared;

namespace MMSDotNetCore.PizzaApi.Features.Pizza;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly DapperService _dapperService;

    public PizzaController()
    {
        _context = new AppDbContext();
        _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    [HttpGet]
    public async Task<IActionResult> GetPizzaList()
    {
        var lst = await _context.Pizzas.ToListAsync();
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPizza(int id)
    {
        var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == id);
        if (pizza == null)
        {
            return NotFound("You cann't get this order");
        }
        return Ok(pizza);
    }

    [HttpGet]
    [Route("ExtraList")]
    public async Task<IActionResult> GetExtraList()
    {
        var lst = await _context.Extras.ToListAsync();
        return Ok(lst);
    }

    [HttpPost]
    [Route("PizzaOrder")]
    public async Task<IActionResult> CreatePizzaOrder(PizzaOrderRequestModel reqModel)
    {
        decimal totalPrice = 0;
        var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == reqModel.PizzaId);
        totalPrice += pizza.PizzaPrice;
        if (pizza == null)
        {
            return NotFound("You cann't get this pizza order .");
        }

        if (reqModel.ExtraList.Length > 0)
        {
            var extraList = await _context.Extras.Where(x => reqModel.ExtraList.Contains(x.ExtraId)).ToListAsync();
            totalPrice += extraList.Sum(x => x.ExtraPrice);
        }
        var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
        PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
        {
            PizzaId = reqModel.PizzaId,
            PizzaOrderInvoiceNo = invoiceNo,
            TotalPrice = totalPrice
        };

        List<PizzaOrderDetailModel> pizzaOrderDetails = reqModel.ExtraList.Select(x => new PizzaOrderDetailModel
        {
            PizzaOrderInvoiceNo = invoiceNo,
            ExtraId = x
        }).ToList();

        await _context.PizzaOrder.AddAsync(pizzaOrderModel);
        await _context.PizzaOrderDetail.AddRangeAsync(pizzaOrderDetails);
        await _context.SaveChangesAsync();
        PizzaOrderResponseModel model = new PizzaOrderResponseModel()
        {
            PizzaInvoiceNo = invoiceNo,
            TotalPirce = totalPrice,
            Message = "Thank you for your order.",
        };
        return Ok(model);
    }

    //[HttpGet("Order/{invoiceNo}")]
    //public async Task<IActionResult> GetOrderByInvoiceNode(string invoiceNo)
    //{
    //    var item = await _context.PizzaOrder.FirstOrDefaultAsync(x=>x.PizzaOrderInvoiceNo == invoiceNo);
    //    var lst = await _context.PizzaOrderDetail.Where(x=>x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
    //    return Ok(new
    //    {
    //        Order = item,
    //        OrderDetail = lst
    //    });
    //} 

    [HttpGet("Order/{invoiceNo}")]
    public async Task<IActionResult> GetOrderByInvoiceNode(string invoiceNo)
    {
        var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceModel>
            (
            PizzaQuerys.PizzaOrderQuery,
            new { PizzaOrderInvoiceNo = invoiceNo }
            );
        var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
            (
            PizzaQuerys.PizzaOrderDetailQuery,
            new { PizzaOrderInvoiceNo = invoiceNo }
            );

        var model = new PizzaOrderInvoiceResponseModel
        {
            PizzaOrderInvoice = item,
            PizzaOrderInvoiceDetails = lst
        };
        return Ok(model);
    }
}
