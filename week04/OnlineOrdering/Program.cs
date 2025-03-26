internal class Address
{
    private string _street;S
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}


internal class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}


internal class Product
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

    public string GetPackingLabel()
    {
        return $"{_name} ({_productId})";
    }
}

internal class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = _products.Sum(product => product.GetTotalCost());
        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(product => product.GetPackingLabel()));
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // First order
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Product product1 = new Product("Laptop", "A101", 1000, 1);
        Product product2 = new Product("Mouse", "B202", 25, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nTotal Price:");
        Console.WriteLine($"${order1.GetTotalPrice():F2}");

        // Second order
        Address address2 = new Address("456 Maple St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        Product product3 = new Product("Keyboard", "C303", 50, 1);
        Product product4 = new Product("Monitor", "D404", 200, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\nTotal Price:");
        Console.WriteLine($"${order2.GetTotalPrice():F2}");
    }
}
