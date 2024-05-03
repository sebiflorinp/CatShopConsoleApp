using CatShop.Models;

namespace CatShop.UI;

public class UI
{
    public void Run()
    {
        this.DisplayInstructions();
        
        // needed variables
        bool running = true;
        string? receivedValue;
        int chosenOption = 0;
        bool validInput = false;
        
        // app loop
        while (running)
        {
            // get an option from the user
            Console.WriteLine("Choose an option.");
            receivedValue = Console.ReadLine();
            int.TryParse(receivedValue, out chosenOption);
            if (chosenOption == 0 || Convert.ToInt32(receivedValue) > 6 || Convert.ToInt32(receivedValue) < 1)
            {
                Console.WriteLine("The input option is invalid");
                continue;
            }
            chosenOption = Convert.ToInt32(receivedValue);

            switch (chosenOption)
            {
                // Add a cat
                case 1:
                    // get name
                    
                    // get age
                    
                    // get furColor
                    
                    // get favoriteFood
                    
                    // add the cat
                    break;
                // Find a cat by id
                case 2:
                    // input id
                    
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
                    // get the id
                    
                    // get required data for updating a cat
                    
                    // perform the update
                    break;
                // Delete a cat
                case 5:
                    // get the id
                    
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