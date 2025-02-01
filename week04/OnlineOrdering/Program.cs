using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInNigeria()
    {
        return country.Equals("Nigeria", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInNigeria()
    {
        return address.IsInNigeria();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInNigeria() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing List:\n";
        foreach (var product in products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping To:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

class Program
{
    static void Main()
    {
        Customer customer1 = new Customer("Becky Ekemezie", new Address("17 Ahamefune St", "Asaba", "Delta", "Nigeria"));
        Customer customer2 = new Customer("Anthony Nwokedi", new Address("76 Core Area", "Asaba", "Delta", "Nigeria"));

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A123", 1200.00m, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.00m, 2));
        order1.AddProduct(new Product("Headset", "H789", 75.00m, 1));
        
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "C789", 45.00m, 1));
        order2.AddProduct(new Product("Monitor", "D012", 300.00m, 1));
        order2.AddProduct(new Product("Webcam", "W345", 100.00m, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
            Console.WriteLine("--------------------------");
        }
    }
}
