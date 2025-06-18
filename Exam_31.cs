using System;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public static int ProductCount = 0;

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        ProductCount++;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price:C}");
    }

    public static void PrintProductCount()
    {
        Console.WriteLine($"Total products created: {ProductCount}");
    }
}

public class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; } // у місяцях

    public ElectronicProduct(string name, decimal price, int warrantyPeriod)
        : base(name, price)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Electronic: {Name}, Price: {Price:C}, Warranty: {WarrantyPeriod} months");
    }
}

public class ClothingProduct : Product
{
    public string Size { get; set; }

    public ClothingProduct(string name, decimal price, string size)
        : base(name, price)
    {
        Size = size;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Clothing: {Name}, Price: {Price:C}, Size: {Size}");
    }
}

public class Program
{
    public static void Main()
    {
        Product p1 = new ElectronicProduct("Laptop", 25000m, 24);
        Product p2 = new ClothingProduct("T-Shirt", 499.99m, "L");
        Product p3 = new ElectronicProduct("Smartphone", 18000m, 12);

        p1.PrintInfo();
        p2.PrintInfo();
        p3.PrintInfo();

        Product.PrintProductCount();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
