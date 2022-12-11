// See https://aka.ms/new-console-template for more information
Console.WriteLine("Open Closed");
Console.WriteLine("___________\n");

var apple = new Product("Apple", Color.Red, Size.Small);
var spaling = new Product("Banana Sapling", Color.Green, Size.Medium);
var tShirt = new Product("T-Shirt", Color.Blue, Size.Small);
var mountainDew = new Product("Mountain Dew", Color.Green, Size.Small);
var hat = new Product("Hat", Color.Blue, Size.Small);

Product[] products = { apple, spaling, tShirt, mountainDew, hat };

var filter = new ProductFilter();
Console.WriteLine("Green products filter (old / ineffecient way):");
foreach (var product in filter.FilterByColor(products, Color.Green))
{
	Console.WriteLine($"- {product.Name} is green");
}

Console.WriteLine("\n");

var betterFilter = new BetterFilter();
Console.WriteLine("Green Products filter (better way):");
foreach (var item in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
{
	Console.WriteLine($"- {item.Name} is green");
}

Console.WriteLine("\n");

Console.WriteLine("Small Products filter (better way):");
foreach (var item in betterFilter.Filter(products, new SizeSpecification(Size.Small)))
{
	Console.WriteLine($"- {item.Name} is Small");
}

Console.WriteLine();

// If we wanted to filter by both color and size
// we will use a "Combinator"
Console.WriteLine("using a combinator to apply both filters, finding Blue color and Small sized items...");
foreach (var smallBlue in betterFilter.Filter(
	products,
	new AndSpecification<Product>(
		new ColorSpecification(Color.Blue),
		new SizeSpecification(Size.Small)
		)))
{
	Console.WriteLine($"- {smallBlue.Name} is Small and Blue");
}

/// <summary>
/// The product we sell on our site
/// </summary>
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

// filtering a collection, Old Way not a great way to do so
[Obsolete]
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

// kinda of like a predicate, we could filter on anything
public interface ISpecification<T>
{
	bool IsSatisfied(T t);
}

// these operate on any type, <T>
public interface IFilter<T>
{
	/// <summary>
	/// feed a bunch of items, and get a bunch of filtered items back
	/// </summary>
	/// <param name="items">a collection of items</param>
	/// <param name="spec">what the specification should be and how to filter</param>
	/// <returns></returns>
	IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}

/// <summary>
/// The Color Spec, Using our new interfaces re-doing the get it done approach and
/// using the Open Close Principle
/// </summary>
public class ColorSpecification : ISpecification<Product>
{
	Color color;

	public ColorSpecification(Color color)
	{
		this.color = color;
	}

	public bool IsSatisfied(Product t)
	{
		return t.Color == color;
	}
}

/// <summary>
/// Filtering by Size in the new way
/// </summary>
public class SizeSpecification : ISpecification<Product>
{
	Size size;

	public SizeSpecification(Size size)
	{
		this.size = size;
	}

	public bool IsSatisfied(Product t)
	{
		return t.Size == size;
	}
}

// The Combinator to use both our filters
/// <summary>
/// We will take 2 filters then "And" them together in our IsSatisfied spec
/// </summary>
/// <typeparam name="T"></typeparam>
public class AndSpecification<T> : ISpecification<T>
{
	ISpecification<T> first, second;

	public AndSpecification(ISpecification<T> first, ISpecification<T> second)
	{
		this.first = first;
		this.second = second;
	}

	/// <summary>
	/// Apply bith conditions onto our filter
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	public bool IsSatisfied(T t)
	{
		return first.IsSatisfied(t) && second.IsSatisfied(t);
	}
}


/// <summary>
/// Creating a better filter utilizing the Specification Principle
/// </summary>
public class BetterFilter : IFilter<Product>
{
	public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
	{
		foreach (var item in items)
		{
			if (spec.IsSatisfied(item))
			{
				yield return item;
			}
		}
	}
}

/// <summary>
/// Colors for our products
/// </summary>
public enum Color
{
	Red,
	Green,
	Blue,
	Yellow
}

/// <summary>
/// Sizes of our products
/// </summary>
public enum Size
{
	Small,
	Medium,
	Large
}