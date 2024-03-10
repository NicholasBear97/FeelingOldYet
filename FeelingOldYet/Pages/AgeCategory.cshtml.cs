using DataService;
using FeelingOldYet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Processors;

namespace FeelingOldYet.Pages.Shared
{
    public class AgeCategoryModel : PageModel
    {
        public AgeCategoryModel(DbDataService dataService)
        {
            DataService = dataService;
        }

        public List<Person> People { get; set; }

        private readonly DbDataService DataService;

        [BindProperty]
        public Person Person { get; set; }
        public void OnGet()
        {
            People = DataService.People.ToList();
        }

        public IActionResult OnPost()
        {
            if (Person != null) 
            {
                ProcessPerson(Person);
            }

            return RedirectToPage();
        }

        public void ProcessPerson(Person person)
        {
            AlertProcessor.ProcessPerson(person);
            DataService.Add(person);
            DataService.SaveChanges();
        }
    }
}
