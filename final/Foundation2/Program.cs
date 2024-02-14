//Address class stores address info.Two functions IsInUSA(), GetAddressInfo() will be encapsulated in Customer class;
//Customer class stores customer name and address. Two functions IsInUSA() will be encapsulated to calculate totalCost and GetShippingLabel() will be encapsulated into GetShippingLabel() in Order class;
//Product stores product info. GetTotalCost() will be encapsulated to calculate totalCost. GetName() and GetProductId() will be encapsulted in the Odder class to GetPackingLabel();
//Order class stores a list<Product> and customer. The constructor: public Order(Customer customer) and method:AddProduct(Product product) will be encapsulated in program.cs.
using System;
using System.Collections.Generic;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince= stateProvince;
        _country= country;
    }

    public bool IsInUSA()//prepare for  public bool IsInUSA() in class Customer
    {
        return _country.Equals("USA");
    }

    public string GetAddressInfo()//prepare for  public bool IsInUSA() in class Customer
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}, {_country}";
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name= name;
        _address = address;
    }

    public bool IsInUSA()//prepare for public double GetTotalCost() in Order class which needs the attribute of customer
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetShippingLabel()//prepare for public string GetShippingLabel() in Order Class
    {
        return $"{_name}\n{_address.GetAddressInfo()}";
    }
}

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        if (_customer.IsInUSA())
            totalCost += 5; // Shipping cost for USA
        else
            totalCost += 35; // Shipping cost for non-USA

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()} - {product.GetProductId()}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create Address1, Customer1, and Order1 instance
        Address customerAddress1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Customer customer1 = new Customer("John Doe", customerAddress1);

        // Create Order 1 and add products to it
        Order order1 = new Order(customer1);   
        order1.AddProduct(new Product("Widget", "W123", 10.99, 2));
        order1.AddProduct(new Product("Gadget", "G456", 19.99, 1));

        // Create Address1, Customer1, and Order2 instance
        Address customerAddress2 = new Address("456 Elm St", "Othertown", "CA", "Canada");
        Customer customer2 = new Customer("Jane Smith", customerAddress2);

        // Create Order 2 and add products to it
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Thingamajig", "T789", 15.99, 3));
        order2.AddProduct(new Product("Doodad", "D567", 7.99, 2));

        // Display information for Order 1
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Cost: $" + order1.GetTotalCost());

        // Display information for Order 2
        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Cost: $" + order2.GetTotalCost());
    }
}