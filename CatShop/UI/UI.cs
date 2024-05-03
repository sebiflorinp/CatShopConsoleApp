using CatShop.Models;
using CatShop.Services;
using CatShop.Utils;
using ConsoleTables;

namespace CatShop.UI;

public class UI
{
    public Validation validation;
    public CatService catService;

    public UI()
    {
        validation = new Validation();
        catService = new CatService();
    }
    public void Run()
    {
        this.DisplayInstructions();
        
        // needed variables
        bool running = true;
        string? receivedValue;
        int chosenOption = 0;
        
        // app loop
        while (running)
        {
            // get an option from the user
            Console.WriteLine("Choose an option.");
            receivedValue = Console.ReadLine();
            while (!validation.ValidateOption(receivedValue))
            {
                Console.WriteLine("The input option is invalid, please input a valid option.");
                receivedValue = Console.ReadLine();
            }
            chosenOption = Convert.ToInt32(receivedValue);

            switch (chosenOption)
            {
                // Add a cat
                case 1:
                    // Get the name
                    Console.WriteLine("Please input the name of the cat.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateName(receivedValue))
                    {
                        Console.WriteLine("The input name is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    string? name = receivedValue;
                    
                    // Get the age
                    Console.WriteLine("Please input the age of the cat.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateAge(receivedValue))
                    {
                        Console.WriteLine("The input age is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    int age = Convert.ToInt32(receivedValue);
                    
                    // Get the furColor
                    Console.WriteLine("Please input the fur color of the cat. It can have one of the following colors: Black, White, Brown, Gray, Cream");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateFurColor(receivedValue))
                    {
                        Console.WriteLine("The input fur color is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    string? furColor = receivedValue;                    
                    
                    // Get the favoriteFood
                    Console.WriteLine("Please input the favorite food of the cat. It can have one of the following colors: Meat, Milk, Cheese.\n" +
                                      "If the cat doesn't have a favorite food don't input anything. (leave the space blank)");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateFavoriteFood(receivedValue))
                    {
                        Console.WriteLine("The input favorite food is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    string? favoriteFood = receivedValue;
                    Cat newCat = new Cat() { Age = age, FavoriteFood = favoriteFood, FurColor = furColor, Name = name };
                    catService.Add(newCat);
                    break;
                // Find a cat by id
                case 2:
                    // Get the id
                    Console.WriteLine("Please input the id of the cat.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateId(receivedValue))
                    {
                        Console.WriteLine("The input id is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    int id = Convert.ToInt32(receivedValue);
                    
                    // Get the cat
                    Cat foundCat = null;
                    try
                    {
                        foundCat = catService.FindById(id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    // Display the cat
                    List<Cat> toDisplay = new List<Cat>() { foundCat };
                    this.DisplayData(toDisplay);
                    break;
                // Display all cats
                case 3:
                    // Get all cats
                    List<Cat> catsToDisplay = catService.GetAll();
                    // Display them
                    if (catsToDisplay.Count == 0)
                    {
                        Console.WriteLine("There are no cats to display.");
                    }
                    else
                    {
                        DisplayData(catsToDisplay);
                    }
                    break;
                // Update a cat
                case 4:
                    List<Cat> cats = catService.GetAll();
                    DisplayData(cats);
                    
                    // Get the id
                    Console.WriteLine("Please input the id of the cat that will be updated.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateId(receivedValue))
                    {
                        Console.WriteLine("The input id is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    id = Convert.ToInt32(receivedValue);
                    
                    // Get the updated name
                    Console.WriteLine("Please input the new name of the cat.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateName(receivedValue))
                    {
                        Console.WriteLine("The input name is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    string? updatedName = receivedValue;
                    
                    // Get the updated age
                    Console.WriteLine("Please input the new age of the cat.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateAge(receivedValue))
                    {
                        Console.WriteLine("The input age is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    int updatedAge = Convert.ToInt32(receivedValue);
                    
                    // Get the furColor
                    Console.WriteLine("Please input the new fur color of the cat. It can have one of the following colors: Black, White, Brown, Gray, Cream");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateFurColor(receivedValue))
                    {
                        Console.WriteLine("The input fur color is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    string? updatedFurColor = receivedValue;                    
                    
                    // Get the favoriteFood
                    Console.WriteLine("Please input the new favorite food of the cat. It can have one of the following colors: Meat, Milk, Cheese.\n" +
                                      "If the cat doesn't have a favorite food don't input anything. (leave the space blank)");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateFavoriteFood(receivedValue))
                    {
                        Console.WriteLine("The input favorite food is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    string? updatedFavoriteFood = receivedValue;
                    Cat updatedCat = new Cat()
                    {
                        Age = updatedAge, FavoriteFood = updatedFavoriteFood, FurColor = updatedFurColor,
                        Name = updatedName
                    };

                    try
                    {
                        catService.UpdateById(id, updatedCat);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                // Delete a cat
                case 5:
                    cats = catService.GetAll();
                    DisplayData(cats); 
                    
                    // Get the id
                    Console.WriteLine("Please input the id of the cat that will be deleted.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateId(receivedValue))
                    {
                        Console.WriteLine("The input id is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    id = Convert.ToInt32(receivedValue);

                    try
                    {
                        catService.Delete(id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                // close the application
                case 6:
                    running = false;
                    break;
            }
        }
        Console.WriteLine("Thank you for using this application!!!");
    }

    public void DisplayData(List<Cat> catsToDisplay)
    {
        var table = new ConsoleTable("Id", "Name", "Age", "FurColor", "FavoriteFood");
        foreach (Cat cat in catsToDisplay)
        {
            table.AddRow(cat.Id, cat.Name, cat.Age, cat.FurColor, cat.FavoriteFood);
        }
        ConsoleTable.From(catsToDisplay).Write(Format.MarkDown);
    }

    public void DisplayInstructions()
    {
        Console.WriteLine("CatShop Test Application with Entity Framework for persistence.");
        Console.WriteLine("You can interact with this app by choosing one of the following options:\n" +
                          "  1. Add a cat.\n" +
                          "  2. Find a cat by id.\n" +
                          "  3. Display all cats.\n" +
                          "  4. Update a cat.\n" +
                          "  5. Delete a cat.\n" +
                          "  6. Exit the application.");        
    }
}