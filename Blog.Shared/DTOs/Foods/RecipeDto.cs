namespace Blog.Shared.DTOs.Foods
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<string> Category { get; set; } = new List<string>();
        public string? Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public string? Instructions { get; set; }
    }
}
