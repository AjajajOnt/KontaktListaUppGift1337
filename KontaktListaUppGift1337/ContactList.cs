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

            MenyDesign("Enter name");
            Person newPerson = new Person();
            newPerson.name = Console.ReadLine();
            MenyDesign("Enter Lastname");
            newPerson.lastname = Console.ReadLine();
            
            persons.Add(newPerson);
        }

        private void PrintPerson()
        {
            foreach (var person in persons)
            {
                MenyDesign(person.name + "  " + person.lastname + "  " + person.favoritAnimal);

            }
        }

        internal void MenyDesign(string text)
        {

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("(" + text + ")");
            Console.WriteLine("--------------------------------------");
        }


    }

}
