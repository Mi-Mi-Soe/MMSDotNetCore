namespace MMSDotNetCore.PizzaApi.Features.Pizza;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly AppDbContext _context;

    public PizzaController()
    {
        _context = new AppDbContext();
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
}
