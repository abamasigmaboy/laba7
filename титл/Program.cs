// вариант 26 базовый вывести сведения о товарах у которых истекает срок годности через 2 дня
Console.Write("Введите количество товаров: ");
int n = int.Parse(Console.ReadLine());
Product[] products = new Product[n];
for (int i = 0; i < products.Length; i++)
{
    Console.WriteLine($"\nТовар №{i + 1}:");

    Console.Write("Наименование: ");
    products[i].Name = Console.ReadLine();

    Console.Write("Цена: ");
    products[i].Price = decimal.Parse(Console.ReadLine());

    Console.Write("Дата производства (дд.ММ.гггг): ");
    products[i].ProdDate = DateTime.Parse(Console.ReadLine());

    Console.Write("Срок годности (в днях): ");
    products[i].ShelfLifeDays = int.Parse(Console.ReadLine());

    Console.Write("Количество: ");
    products[i].Quantity = int.Parse(Console.ReadLine());

    Console.Write("Производитель: ");
    products[i].Manufacturer = Console.ReadLine();
}
DateTime targetDate = DateTime.Today.AddDays(2);
Console.WriteLine("\nТовары, срок годности которых истекает через двое суток:");
foreach (var p in products)
{
    if (p.ExpireDate.Date == targetDate)
        p.Print();
}
Console.WriteLine("\nНажмите Enter для выхода...");
Console.ReadLine();
struct Product
{
    public string Name;       
    public decimal Price;        
    public DateTime ProdDate; 
    public int ShelfLifeDays;   
    public int Quantity;        
    public string Manufacturer;  
    public DateTime ExpireDate => ProdDate.AddDays(ShelfLifeDays);
    public void Print()
    {
        Console.WriteLine($"{Name}, {Price}, {ProdDate:d}, " +
                          $"{ShelfLifeDays} дн., {Quantity}, {Manufacturer}");
    }
}
