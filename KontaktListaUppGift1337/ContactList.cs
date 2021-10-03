using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KontaktListaUppGift1337
{
    internal class ContactList
    {

   
    List<Person> persons = new List<Person>();


        
        
        
        
        internal void start()
        {

            Person newPerson = new Person();
            newPerson.name = Console.ReadLine();
            newPerson.lastname = Console.ReadLine();
            newPerson.favoritAnimal = Console.ReadLine();
            persons.Add(newPerson);



        }

        private void PrintPerson()
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.name + "  " + person.lastname + "  " + person.favoritAnimal);

            }
        }

    }
}
