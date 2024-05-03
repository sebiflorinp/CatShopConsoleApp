using CatShop.DbContexts;
using CatShop.Models;

namespace CatShop.Services;

public class CatService
{
    public void Add(Cat newCat)
    {
        using (var db = new CatDbContext())
        {
            db.Add(newCat);
            db.SaveChanges();
        }
    }

    public Cat FindById(int id)
    {
        using (var db = new CatDbContext())
        {
            var cats = (from cat in db.Cats where cat.Id == id select cat).ToList();
            if (cats.Count == 1)
            {
                return cats[0];
            }
            else
            {
                throw new Exception("There is no cat with the input id.");
            }
        }
    }

    public List<Cat> GetAll()
    {
        using (var db = new CatDbContext())
        {
            return (from cat in db.Cats select cat).ToList();
        }
    }

    public void Delete(int idToDelete)
    {
        using (var db = new CatDbContext())
        {
            var catToDelete = (from cat in db.Cats where cat.Id == idToDelete select cat).ToList();
            if (catToDelete.Count != 0)
            {
                db.Cats.Remove(catToDelete[0]);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("There is no cat with the input id.");
            }
        }
    }

    public void UpdateById(int idToUpdate, Cat updatedCat)
    {
        using (var db = new CatDbContext())
        {
            // Find the cat with the input id
            var catsToUpdate = (from cat in db.Cats where cat.Id == idToUpdate select cat).ToList();

            if (catsToUpdate.Count == 1)
            { 
                catsToUpdate[0].Age = updatedCat.Age; 
                catsToUpdate[0].Name = updatedCat.Name; 
                catsToUpdate[0].FavoriteFood = updatedCat.FavoriteFood; 
                catsToUpdate[0].FurColor = updatedCat.FurColor; 
                db.SaveChanges();                
            }
            else
            {
                throw new Exception("There is no cat with the input id.");
            }

        }
    }
}