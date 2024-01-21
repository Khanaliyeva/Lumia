namespace Lumia.Areas.Manage.ViewModels
{
    public class UpdateTeamVm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
