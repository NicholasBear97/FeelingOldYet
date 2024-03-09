using System.ComponentModel.DataAnnotations.Schema;

namespace FeelingOldYet.Models
{
    public class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public int ID { get; set; }

        public Person() { }

        public Person(string? name, int age)
        {
            Name = name;
            Age = age;
        }

        public void UpdateId(int id)
        {
            ID = id;
        }
    }
}
