using DataService;
using FeelingOldYet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Processors;

namespace FeelingOldYet.Pages.Shared
{
    public class AgeEventLogModel : PageModel
    {
        #region Constructors
        public AgeEventLogModel(DbDataService dataService, IProcessorStrategy processorStrategy)
        {
            DataService = dataService;
            ProcessorStrategy = processorStrategy;
        }
        #endregion

        #region Properties
        public List<Person> People { get; set; }
        private readonly DbDataService DataService;
        private readonly IProcessorStrategy ProcessorStrategy;
        [BindProperty]
        public Person Person { get; set; }
        #endregion

        #region ActionMethods
        public void OnGet()
        {
            People = DataService.People.OrderByDescending(x => x.Id).ToList();
        }

        public IActionResult OnPostConvert()
        {
            if (Person != null) 
            {
                Process(Person);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostClear()
        {
            if (DataService.People != null && DataService.People.Count() > 0)
            {
                DataService.ClearPeople();
            }
            return RedirectToPage();
        }
        #endregion

        #region ProcessingMethods
        /// <summary>
        /// Process a person object to the appropriate processors and data service.
        /// </summary>
        /// <param name="person"></param>
        public void Process(Person person)
        {
            ProcessorStrategy.ProcessPerson(person);
            DataService.ProccessData(person);
        }
        #endregion
    }
}
