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

        //get SPROCs

        //insert SPROCs
    }
}