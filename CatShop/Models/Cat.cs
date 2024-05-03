using System.ComponentModel.DataAnnotations;

namespace CatShop.Models;

public class Cat
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string FurColor { get; set; } = null!;
    public string? FavoriteFood { get; set; }
}