// See https://aka.ms/new-console-template for more information
Console.WriteLine("Open Closed");
Console.WriteLine("___________");

var apple = new Product("Apple", Color.Red, Size.Small);
var spaling = new Product("Banana Sapling", Color.Green, Size.Medium);
var tShirt = new Product("T-Shirt", Color.Blue, Size.Small);

Product[] products = {apple, spaling, tShirt};

var filter = new ProductFilter();
Console.WriteLine("Green products (old)");
foreach (var product in filter.FilterByColor(products, Color.Green))
{
	Console.WriteLine($"- {product.Name} is green");
}


public class Product
{
	public string Name;
	public Color Color;
	public Size Size;

	public Product(string name, Color color, Size size)
	{
		Name = name;
		Color = color;
		Size = size;
	}
}

// filtering a collection
public class ProductFilter
{
	public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
	{
		foreach (var item in products)
		{
			if (item.Size == size)
			{
				// found product with the same size
				yield return item;
			}
		}
	}

	public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
	{
		foreach (var item in products)
		{
			if (item.Color == color)
			{
				// found product with the same color
				yield return item;
			}
		}
	}
}

public enum Color
{
	Red,
	Green,
	Blue,
	Yellow
}

public enum Size
{
	Small,
	Medium,
	Large
}