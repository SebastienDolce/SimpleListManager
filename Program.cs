using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        MyListManager<string> listManager = new MyListManager<string>();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Create List");
            Console.WriteLine("2. Add Item");
            Console.WriteLine("3. Read List");
            Console.WriteLine("4. Update Item");
            Console.WriteLine("5. Delete Item");
            Console.WriteLine("6. Delete List");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    listManager.CreateList();
                    break;
                case 2:
                    listManager.AddItem();
                    break;
                case 3:
                    listManager.ReadList();
                    break;
                case 4:
                    listManager.UpdateItem();
                    break;
                case 5:
                    listManager.DeleteItem();
                    break;
                case 6:
                    listManager.DeleteList();
                    break;
                case 7:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Are you sure you're a human?");
                    break;
            }

            Console.WriteLine();
        }
    }
}

class MyListManager<T>
{
    // implementing this with null safety. null values not allowed
    private List<T>? myList;

    public void CreateList()
    {
        myList = new List<T>();
        Console.WriteLine("List created successfully. the Sky is the Limit");
    }

    public void AddItem()
    {
        if (myList == null)
        {
            Console.WriteLine("I can't read minds (yet!).  Please create a list first.");
            return;
        }

        Console.Write("Enter a value to add: ");
        string? inputValue = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValue))
        {
            Console.WriteLine("Invalid value. Blank values are not allowed.");
            return;
        }

        T value = ParseInputValue(inputValue)!;
        myList.Add(value);
        Console.WriteLine("Value added successfully.");
    }

    public void ReadList()
    {
        if (myList == null)
        {
            Console.WriteLine("I can't read minds (yet!).  Please create a list first.");
            return;
        }

        Console.WriteLine("List Values:");
        foreach (T value in myList)
        {
            Console.WriteLine(value);
        }
    }

    public void UpdateItem()
    {
        if (myList == null)
        {
            Console.WriteLine("I can't read minds (yet!).  Please create a list first.");
            return;
        }

        Console.Write("Enter the index of the value to update: ");
        int index = int.Parse(Console.ReadLine() ?? "-1");

        if (index >= 0 && index < myList.Count)
        {
            Console.Write("Enter the new value: ");
            string? inputValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                Console.WriteLine("Invalid value. Blank values are not allowed.");
                return;
            }

            T value = ParseInputValue(inputValue)!;
            myList[index] = value;
            Console.WriteLine("Value updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    public void DeleteItem()
    {
        if (myList == null)
        {
            Console.WriteLine("I can't read minds (yet!).  Please create a list first.");
            return;
        }

        Console.Write("Enter the index of the value to delete: ");
        int index = int.Parse(Console.ReadLine() ?? "-1");

        if (index >= 0 && index < myList.Count)
        {
            myList.RemoveAt(index);
            Console.WriteLine("Value deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    public void DeleteList()
    {
        myList = null;
        Console.WriteLine("List deleted successfully. Another one bytes the dust");
    }

// helper fuction to convert the string input values from console to their generic types
// can use this to add support for custom types
    private T? ParseInputValue(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return default;
        }

        if (typeof(T) == typeof(int))
        {
            return (T)(object)int.Parse(input);
        }
        else if (typeof(T) == typeof(double))
        {
            return (T)(object)double.Parse(input);
        }
        else if (typeof(T) == typeof(string))
        {
            return (T)(object)input;
        }
        else
        {
            throw new NotSupportedException($"Type '{typeof(T)}' is not supported.");
        }
    }
}
