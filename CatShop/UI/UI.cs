using CatShop.Models;
using CatShop.Utils;

namespace CatShop.UI;

public class UI
{
    public Validation validation;

    public UI()
    {
        validation = new Validation();
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
                    
                    // add the cat
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

                    int? id = Convert.ToInt32(receivedValue);
                    
                    // get the cat
                    
                    // display the response
                    break;
                // Display all cats
                case 3:
                    // get all cats
                    
                    // display them
                    break;
                // Update a cat
                case 4:
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
                    
                    // perform the update
                    break;
                // Delete a cat
                case 5:
                    // Get the id
                    Console.WriteLine("Please input the id of the cat that will be deleted.");
                    receivedValue = Console.ReadLine();
                    while (!validation.ValidateId(receivedValue))
                    {
                        Console.WriteLine("The input id is invalid, please input a valid one.");
                        receivedValue = Console.ReadLine();
                    }

                    id = Convert.ToInt32(receivedValue);
                    
                    // delete the cat
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