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
        string remove = "";
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
            newPerson.Blocked = true;
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
            InputFirstAndLastName();

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
                    Input = CapitalizeFirstLetter(Input);
                    Console.Write("Enter what you want to change it to: ");
                    Input2 = Console.ReadLine();
                    Input2 = CapitalizeFirstLetter(Input2);

                    if (Input.ToUpper() == "BLOCKED")
                    {
                        persons[i].GetType().GetProperty(Input).SetValue(persons[i], Convert.ToBoolean(Input2));
                    }
                    else if (Input.ToUpper() == "GHOSTED")
                    {
                        persons[i].GetType().GetProperty(Input).SetValue(persons[i], Convert.ToBoolean(Input2));

                    }
                    else
                    {
                        persons[i].GetType().GetProperty(Input).SetValue(persons[i], Input2);
                    }
                     






                }
            }



        }

        internal void ShowInfoOfContact()
        {
            Console.Clear();
            PrintContactsFristandLastName();
            InputFirstAndLastName();

            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine();

                if (!persons[i].Name.Contains(Input) && !persons[i].LastName.Contains(Input2))
                {
                    Console.WriteLine("Contact does not exist");
                }
                else if (persons[i].Name.Contains(Input) && persons[i].LastName.Contains(Input2))
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

        private void InputFirstAndLastName()
        {
            Console.Write("Enter firstname: ");
            Input = Console.ReadLine();
            Input = CapitalizeFirstLetter(Input);
            Console.Write("Enter lastname: ");
            Input2 = Console.ReadLine();
            Input2 = CapitalizeFirstLetter(Input2);
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
            Console.Clear();
            Console.WriteLine("Do you want to list everyone or by filter");
            Input = Console.ReadLine();

            if (Input.ToUpper() == "EVERYONE" || Input.ToUpper() == "ALL" || Input.ToUpper() == "EVERYONE")
            {
                PrintContactsFristandLastName();


            }
            else if(Input.ToUpper() == "FILTER")
            {
                
                Console.Write("Write the first letter you want to filter names by: ");
                Input = Console.ReadLine();
                Input = Input.ToUpper();
                for (int i = 0; i < persons.Count; i++)
                {
                    if (persons[i].Name.StartsWith(Input))
                    {
                        count++;
                        Console.WriteLine("Contact: " + count);

                        Console.WriteLine("\t" + persons[i].Name + " " + persons[i].LastName);
                        Console.WriteLine();
                    }



                }
            }
            else
            {
                Console.WriteLine("Du skrev fel");
            }

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

        internal void DeletePerson()
        {
            PrintContactsFristandLastName();
            Console.Write("Do you want to delete a contact? ");
            remove = Console.ReadLine();
            if (remove.ToUpper() == "YES" || remove.ToUpper() == "Y")
            {
                Console.WriteLine();
                InputFirstAndLastName();
                for (int i = 0; i < persons.Count; i++)
                {

                    {
                        if(!(persons[i].Name.Contains(Input) && persons[i].LastName.Contains(Input2)))
                        {
                            Console.WriteLine("Contact does not exist");

                        }
                        else if (persons[i].Name.Contains(Input) && persons[i].LastName.Contains(Input2))
                        {
                            persons.Remove(persons[i]);
                            Console.WriteLine("");
                            Console.WriteLine("Deleted");


                        }
                    }
                }

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
