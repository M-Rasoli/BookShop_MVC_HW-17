namespace BookShop_MVC.Application.DTOs
{
    public class GetBooksDto
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
    }
}
