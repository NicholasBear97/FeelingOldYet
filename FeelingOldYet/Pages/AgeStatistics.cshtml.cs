using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FeelingOldYet.Pages
{
    public class AgeStatisticsModel : PageModel
    {
        DAL _DAL = DAL.Instance;
        public void OnGet()
        {
            _DAL.GetPeople();
        }
    }
}
