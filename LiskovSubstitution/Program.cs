// See https://aka.ms/new-console-template for more information
Console.WriteLine("Liskov Substitution");
Console.WriteLine("___________________\n");
static int Area(Rectangle r) => r.Width * r.Height;

Rectangle rectangle = new(2, 3);
Console.WriteLine($"a rectangle {rectangle} has an Area of '{Area(rectangle)}'");

Square square = new();
square.Width = 4;
Console.WriteLine($"a square {square} has an Area of '{Area(square)}'");

// So we should be able to change the Square to a Rectangle class
Rectangle rs = new();
rs.Width = 4;
Console.WriteLine($"a square {rs} has an Area of '{Area(rs)}'");
Console.WriteLine("And we can see this is not working as expected....");

/// <summary>
/// this way is the wrong way to handle this
/// </summary>
[Obsolete]
public class Square : Rectangle
{
	// a bad example do not do it this way
	public new int Width
	{
		set { base.Width = base.Height = value; }
	}

	public new int Height
	{
		set { base.Width = base.Height = value; }
	}
}


/// <summary>
/// 
/// </summary>
public class Rectangle
{
	public int Width { get; set; }
	public int Height { get; set; }

	public Rectangle()
	{

	}

	public Rectangle(int width, int height)
	{
		Width = width;
		Height = height;
	}

	public override string ToString()
	{
		return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
	}
}
