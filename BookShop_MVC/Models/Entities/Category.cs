namespace BookShop_MVC.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
