namespace BookShop_MVC.Application.DTOs
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImgUrl { get; set; }

    }
}
