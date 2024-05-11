using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string jsonStr = await File.ReadAllTextAsync("IncompatibleFood.json");
MainDto data = JsonConvert.DeserializeObject<MainDto>(jsonStr);
Console.WriteLine(jsonStr);
foreach (var item in data.Tbl_IncompatibleFood)
{
    Console.WriteLine(item.FoodA + " + " + item.FoodB + "=>" + item.Description);
}
Console.ReadKey();


public class MainDto
{
    public Tbl_Incompatiblefood[] Tbl_IncompatibleFood { get; set; }
}

public class Tbl_Incompatiblefood
{
    public int Id { get; set; }
    public string FoodA { get; set; }
    public string FoodB { get; set; }
    public string Description { get; set; }
}
