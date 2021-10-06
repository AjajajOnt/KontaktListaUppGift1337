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
        String Input = "";
        String Input2 = "";
        int count = 0;



        List<Person> persons = new List<Person>();
        PropertyInfo[] Properties = typeof(Person).GetProperties();
        Person newPerson = new Person();

        internal void ExistingContacts2()
        {
            Person newPerson = new Person();
            newPerson.Name = "Kim";
            newPerson.LastName = "Ned";
            newPerson.Alias = "KN";
            newPerson.Email = "KimNed1994@hotmail.com";
            persons.Add(newPerson);
        }

        internal void ExistingContacts()
        {
            Person newPerson = new Person();

            newPerson.Name = "Emergency";
            newPerson.LastName = "Number";
            newPerson.Alias = "SOS";
            newPerson.Email = "kundsupport112@sosalarm.se";
            persons.Add(newPerson);
            //newPerson.Name = "SOS";
            //newPerson.Name = "SOS";
            //newPerson.Name = "SOS";
            //newPerson.Name = "SOS";
            //newPerson.Name = "SOS";
            //newPerson.Name = "SOS";

        }




        internal void AddNewPerson()
        {

            MenyDesign("Enter name");
            Person newPerson = new Person();
            newPerson.Name = Console.ReadLine();
            newPerson.Name = CapitalizeFirstLetter(newPerson.Name);
            //MenyDesign("Enter Lastname");
            //newPerson.LastName = Console.ReadLine();
            newPerson.LastName = CapitalizeFirstLetter(newPerson.LastName);
            String Input = "";
            String Input2 = "";
            PropertyInfo[] Properties = typeof(Person).GetProperties();
            MenyDesign("Do you want to add more information? (Y/N)" );
            Input = Console.ReadLine();
            
            if (Input.ToUpper() == "YES" || Input.ToUpper() == "Y" || Input.ToUpper() == "YE")
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
                    Input = CapitalizeFirstLetter(Input);
                    MenyDesign("Enter: " + Input);
                    Input2 = Console.ReadLine();
                    Input2 = CapitalizeFirstLetter(Input2);

                    newPerson.GetType().GetProperty(Input).SetValue(newPerson, Input2);

                    

                }
                else if(Input.ToUpper() == "EVERYTHING")
                {
                    for (int i = 0; i < Properties.Length; i++)
                    {
                        
                        Console.Write("Enter " + Properties[i].Name + ": ");
                        Input = Console.ReadLine();
                        Input = CapitalizeFirstLetter(Input);
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

        internal void UpdateExistingPerson()

        {
            Console.Clear();
            PrintContactsFristandLastName();
            Console.WriteLine("Enter the firstname of the person you want to update");
            Input = Console.ReadLine();
            Input = CapitalizeFirstLetter(Input);
            Console.WriteLine("Enter the lastname of the person you want to update");
            Input2 = Console.ReadLine();
            Input2 = CapitalizeFirstLetter(Input2);

            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine();

                if (persons[i].Name.Contains(Input) && persons[i].LastName.Contains(Input2))
                {
                    foreach (var prop in Properties)
                    {
                        Console.WriteLine(prop.Name + ": " + prop.GetValue(persons[i]));

                    }
                    Console.WriteLine();
                    Console.Write("Enter what you want to change (Case sensitive) : ");
                    Input = Console.ReadLine();
                    Console.Write("Enter what you want to change it to: ");
                    Input2 = Console.ReadLine();

                    persons[i].GetType().GetProperty(Input).SetValue(persons[i], Input2);






                }
            }



        }

        internal void ShowInfoOfContact()
        {
            Console.Clear();
            PrintContactsFristandLastName();
            Console.Write("Enter the firstname of the person you want to see details about: ");
            Input = Console.ReadLine();
            Input = CapitalizeFirstLetter(Input);
            Console.Write("Enter the lastname of the person you want to see details about: ");
            Input2 = Console.ReadLine();
            Input2 = CapitalizeFirstLetter(Input2);

            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine();

                if (persons[i].Name.Contains(Input) && persons[i].LastName.Contains(Input2))
                {
                    foreach (var prop in Properties)
                    {
                        if (prop.GetValue(persons[i]) != null)
                        {
                            Console.WriteLine(prop.Name + ": " + prop.GetValue(persons[i]));
                        }

                    }

                }
                


            }


        }

        private void PrintContactsFristandLastName()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                count++;
                Console.WriteLine("Contact: " + count);

                Console.WriteLine("\t" + persons[i].Name + " " + persons[i].LastName);
                Console.WriteLine();



            }

        }

        internal void PrintPerson()
        {

            PrintContactsAvailableProperties();

        }

        private void PrintContactsAvailableProperties()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                count++;
                Console.WriteLine("Contact: " + count);
                foreach (var prop in Properties)
                {

                        if (prop.GetValue(persons[i]) != null)
                        {
                            Console.WriteLine("\t" + prop.Name + ": " + prop.GetValue(persons[i]));

                        }
                        

                    

                }

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

            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("|  " + text + "  |");
            Console.WriteLine("_____________________________________________________________________");
        }
        public string CapitalizeFirstLetter(string str)
        {


            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();



        }

    }



}
