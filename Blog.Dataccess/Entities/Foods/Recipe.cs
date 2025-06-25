using Blog.Dataccess.Enums.Foods;

namespace Blog.Dataccess.Entities.Foods
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodCategories Category { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }

    }
}
