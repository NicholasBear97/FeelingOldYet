using AgeProcessors;
using FeelingOldYet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FeelingOldYet.Pages.Shared
{
    public class AgeLeaderboardModel : PageModel
    {
        IProcessor generalProcessor = new GeneralProcessor();
        [BindProperty]
        [Required]
        public Person Person { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            ProcessPerson(Person);
            return RedirectToPage("AgeStatistics");
        }

        public void ProcessPerson(Person person)
        {
            generalProcessor.Process(person);
        }
    }
}
