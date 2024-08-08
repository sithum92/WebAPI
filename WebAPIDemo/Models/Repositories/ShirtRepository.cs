using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebAPIDemo.Models.Repositories
{
    public static class ShirtRepository
    {
        public static List<Shirt> shirts = new List<Shirt>
        {
      
        };

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
                (string.IsNullOrEmpty(brand) || (!string.IsNullOrEmpty(x.Brand) && x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(gender) || (!string.IsNullOrEmpty(x.Gender) && x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(color) || (!string.IsNullOrEmpty(x.Color) && x.Color.Equals(color, StringComparison.OrdinalIgnoreCase))) &&
                (!size.HasValue || (x.Size == size.Value)));
        }



        public static void AddShirt(Shirt shirt)
        {
            int newId = shirts.Max(x => x.ShirtId) + 1;
            shirt.ShirtId = newId+1;
            shirts.Add(shirt);
        }

        [HttpPut("{id}")]
        public static void UpdateShirt(int id, Shirt shirt)
        {


            Shirt? existingShirt = shirts.FirstOrDefault(x => x.ShirtId == id);
            if (existingShirt != null)
            {
                existingShirt.Brand = shirt.Brand;
                existingShirt.Color = shirt.Color;
                existingShirt.Price = shirt.Price;
                existingShirt.Gender = shirt.Gender;

        }

            }



            public static void DeleteShirt(int id)
            {
                var shirt = ShirtRepository.GetShirtById(id);
                if (shirt != null)
                {
                    shirts.Remove(shirt);
                }
      
            }

        }
}
