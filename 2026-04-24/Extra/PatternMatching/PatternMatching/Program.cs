Console.WriteLine("Hello, World!");

int? maybe = 12;

if (maybe is int number)
{
    Console.WriteLine($"The nullable int 'maybe' has the value {number}");
}
else
{
    Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
}

public class Order
{
    public int Items { get; set; }
    public decimal Cost { get; set; }
}

public static class OrderManager
{
    public static decimal CalculateDiscount(Order order) =>
        order switch
        {
            { Items: > 10, Cost: > 1000.00m } => 0.10m,
            { Items: > 5, Cost: > 500.00m } => 0.05m,
            { Cost: > 250.00m } => 0.02m,
            null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
            var someObject => 0m,
        };
}