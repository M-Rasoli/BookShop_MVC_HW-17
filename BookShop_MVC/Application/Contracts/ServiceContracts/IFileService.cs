namespace BookShop_MVC.Application.Contracts.ServiceContracts
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
    }
}
