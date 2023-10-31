using AuthTEst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthTEst.Pages
{
    public class RegisterModel : PageModel
    {
        public Register Model { get; set; }

        public void OnGet()
        {
        }
    }
}
