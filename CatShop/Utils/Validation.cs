using System.Text.RegularExpressions;

namespace CatShop.Utils;

public class Validation
{
    public bool ValidateOption(string? option)
    {
        return option is not null && Regex.IsMatch(option, @"^[1-6]{1,1}$");
    }
    
    public bool ValidateId(string? id)
    {
        return id is not null && Regex.IsMatch(id, @"^[0-9]{1,}$");
    }
    
    public bool ValidateName(string? name)
    {
        return name is not null && name.Length >= 4 && Regex.IsMatch(name, @"^[a-zA-Z]{1,}$");
    }

    public bool ValidateAge(string? age)
    {
        return age is not null && Regex.IsMatch(age, @"^[0-9]{1,}$");
    }

    public bool ValidateFurColor(string? furColor)
    {
        return furColor is not null && Regex.IsMatch(furColor, @"Black|White|Brown|Gray|Cream");
    }

    public bool ValidateFavoriteFood(string? favoriteFood)
    {
        return favoriteFood is null || Regex.IsMatch(favoriteFood, @"Meat|Milk|Cheese");
    }
}