using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using task5.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace task5.Models
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public List<SelectListItem> Users { get; set; }


        public IndexModel(IUserService userService)
        {
            _userService = userService;
            OnGet();
        }

        public void OnGet()
        {
            Users = _userService.GetUsers().ToList()
                .Select(a => new SelectListItem { Text = a.Name, Value = a.Name })
                .OrderBy(s => s.Text).ToList();
        }
    }
}