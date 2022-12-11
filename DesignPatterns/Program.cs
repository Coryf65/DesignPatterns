// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.IO;

Console.WriteLine("Single Responsibility Demo");
Console.WriteLine("__________________________\n");

var j = new Journal();

j.AddEntry("I ate a doughnut today.");
j.AddEntry("Drank one soda.");

Console.WriteLine(j);

var p = new Persistence();
var filename = @"c:\temp\journal.txt";
p.SaveToFile(j, filename, true);

Process process = new();
process.StartInfo.FileName = "notepad.exe";
process.StartInfo.Arguments = filename;

// opens our journal in notepad!
process.Start();



public class Journal
{
	private readonly List<string> entries = new();
	private static int count = 0;

	public int AddEntry(string text)
	{
		entries.Add($"{count++}: {text}");
		return count; // example of the memento pattern
	}

	public void RemoveEntry(int index)
	{
		entries.RemoveAt(index);
	}

	public override string ToString()
	{
		return string.Join(Environment.NewLine, entries);
	}


	// So all of the saving and loading is too much for one class
	// We should take the data persistence part out and make a new class
	//public void Save(string filename)
	//{
	//	File.WriteAllText(filename, ToString());
	//}

	//public string Load(string filename)
	//{
	//	return File.ReadAllText(filename);
	//}
}

/// <summary>
/// Now we have a seperation of concerns HERE we are saving and loading journal files
/// And the Journal class is focused on keeping enteries and maintaining the Journal
/// </summary>
public class Persistence
{
	public void SaveToFile(Journal j, string filename, bool overwrite = false)
	{
		if (overwrite || !File.Exists(filename))
		{
			File.WriteAllText(filename, j.ToString());
		}
	}

	public string Load(string filename)
	{
		return File.ReadAllText(filename);
	}
}
