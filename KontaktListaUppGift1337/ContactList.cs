using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            newPerson.Name = Console.ReadLine();
            //MenyDesign("Enter Lastname");
            //newPerson.LastName = Console.ReadLine();
            String Input = "";
            String Input2 = "";
            PropertyInfo[] Properties = typeof(Person).GetProperties();
            MenyDesign("Do you want to add more information? (Y/N)" );
            Input = Console.ReadLine();
            if (Input.ToUpper() == "YES" || Input.ToUpper() == "Y" || Input.ToUpper() == "ye")
            {
                MenyDesign("Do you want to add something specific or everything? Enter specific or everything as your answer.");
                Input = Console.ReadLine();
                Console.Clear();
                if (Input.ToUpper() == "SPECIFIC")
                {
                    Console.Clear();
                    MenyDesign("Choose and write what you want to add from the list. (Name and case sensitive)");
                    for (int i = 0; i < Properties.Length; i++)
                    {

                        Console.Write(Properties[i].Name + "  ||  ");


                    }
                    Input = Console.ReadLine();
                    MenyDesign("Enter: " + Input);
                    Input2 = Console.ReadLine();

                    newPerson.GetType().GetProperty(Input).SetValue(newPerson, Input2);

                    

                }
                else if(Input.ToUpper() == "EVERYTHING")
                {
                    for (int i = 0; i < Properties.Length; i++)
                    {
                        
                        Console.Write("Enter " + Properties[i].Name + ": ");
                        Input = Console.ReadLine();
                        Properties[i].SetValue(newPerson, Input);
                        

                    }

                }
                else
                {
                    Console.WriteLine("Fel");
                }

            }

            
            persons.Add(newPerson);
        }

        internal void PrintPerson()
        {
            foreach (var person in persons)
            {
                MenyDesign("Firstname: " + person.Name + " Lastname: " + person.LastName + "Alias: " + person.Alias);

            }
        }

        internal void PrintPersonDelete()
        {
            foreach (var person in persons)
            {
                MenyDesign("Name: " + person.Name + " " + person.LastName);
                
                

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
