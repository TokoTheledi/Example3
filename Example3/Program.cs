using System;

// Custom exception class for representing invalid product ID
public class InvalidProductIDException : Exception
{
    public InvalidProductIDException(string message) : base(message)
    {
    }
}

// Custom exception class for representing discontinued products
public class ProductDiscontinuedException : Exception
{
    public ProductDiscontinuedException(string message) : base(message)
    {
    }
}

public class ProductManager
{
    // Simulated product data
    private static string[] availableProducts = { "Apple", "Banana", "Orange" };
    private static bool[] productStatus = { true, true, false }; // Indicates whether the product is discontinued

    public void PurchaseProduct(int productId, int quantity)
    {
        if (productId < 0 || productId >= availableProducts.Length)
        {
            throw new InvalidProductIDException("Invalid product ID");
        }
        else if (!productStatus[productId])
        {
            throw new ProductDiscontinuedException("This product is discontinued");
        }
        else
        {
            Console.WriteLine($"Purchase successful. You bought {quantity} {availableProducts[productId]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductManager manager = new ProductManager();

        // Example usage
        try
        {
            manager.PurchaseProduct(0, 5); // Purchase 5 apples
            manager.PurchaseProduct(2, 8); // Attempt to purchase 8 oranges, which is discontinued
            manager.PurchaseProduct(3, 2); // Invalid product ID
        }
        catch (InvalidProductIDException ex)
        {
            Console.WriteLine($"Invalid product ID: {ex.Message}");
        }
        catch (ProductDiscontinuedException ex)
        {
            Console.WriteLine($"Product discontinued: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
