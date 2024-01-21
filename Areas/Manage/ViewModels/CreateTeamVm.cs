namespace Lumia.Areas.Manage.ViewModels
{
    public class CreateTeamVm
    {
        public string FullName { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
