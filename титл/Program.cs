// Вариант 26 средний уровень. Вывод товаров с истекающим сроком годности через двое суток.
try
{
    Console.Write("Введите количество товаров: ");
    int n = int.Parse(Console.ReadLine());
    Product[] products = new Product[n];
    
    for (int i = 0; i < products.Length; i++)
    {
        Console.WriteLine($"Введите данные о {i + 1} товаре:");
        Console.Write("Наименование: ");
        products[i].name = Console.ReadLine();
        Console.Write("Цена: ");
        products[i].price = decimal.Parse(Console.ReadLine());
        Console.Write("Дата производства (дд.мм.гггг): ");
        products[i].productionDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Срок годности (дней): ");
        products[i].shelfLife = int.Parse(Console.ReadLine());
        Console.Write("Количество: ");
        products[i].count = int.Parse(Console.ReadLine());
        Console.Write("Производитель: ");
        products[i].manufacturer = Console.ReadLine();
    }
    
    DateTime currentDate = DateTime.Today;
    DateTime expirationDate = currentDate.AddDays(2);
    
    Console.WriteLine("\nТовары, срок годности которых истекает через двое суток:");
    bool found = false;
    
    foreach (Product product in products)
    {
        DateTime productExpiration = product.productionDate.AddDays(product.shelfLife);
        
        if (productExpiration.Date == expirationDate.Date)
        {
            product.Print();
            found = true;
        }
    }
    
    if (!found)
    {
        Console.WriteLine("Таких товаров нет.");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

struct Product
{
    public string name;
    public decimal price;
    public DateTime productionDate;
    public int shelfLife;
    public int count;
    public string manufacturer;
    
    public void Print()
    {
        DateTime expirationDate = productionDate.AddDays(shelfLife);
        Console.WriteLine($"{name}, Цена: {price}, Дата производства: {productionDate:dd.MM.yyyy}, " +
                         $"Срок годности: {shelfLife} дней, Количество: {count}, Производитель: {manufacturer}, " +
                         $"Дата истечения: {expirationDate:dd.MM.yyyy}");
    }
}
