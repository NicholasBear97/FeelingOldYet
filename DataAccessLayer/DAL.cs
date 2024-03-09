using FeelingOldYet.Models;
using static System.Console;
namespace DataAccessLayer
{
    public sealed class DAL
    {
        private static readonly Lazy<DAL> _instance = new Lazy<DAL>(() => new DAL());
        private DAL() { }

        public static DAL Instance
        {
            get
            {
                return _instance.Value;
            }
            
        }

        //TODO: Connect SPROCs from DAL and use DAL to make calls here
        #region Get SPROCs
        public List<Person> GetPeople()
        {
            return new List<Person>();
        }
        #endregion

        #region Insert SPROCs
        public void InsertPerson(Person person)
        {

        }
        #endregion
    }
}