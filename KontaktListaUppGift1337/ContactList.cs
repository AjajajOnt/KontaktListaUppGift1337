using System;
using System.Collections.Generic;
using System.Reflection;
namespace KontaktListaUppGift1337
{
    internal class ContactList
    {
        int Age = 0;
        private string Input = "";
        private string Input2 = "";
        private string remove = "";
        bool SomethingHappened = false;
        private int count = 0;
        private readonly List<Person> persons = new List<Person>();
        private readonly PropertyInfo[] Properties = typeof(Person).GetProperties();
        private readonly Person newPerson = new Person();

        internal void ExistingContacts2()
        {
            Person newPerson = new Person
            {
                Name = "Kim",
                LastName = "Ned",
                Alias = "KN",
                Email = "KimNed1994@hotmail.com",
                BirthDay = Convert.ToDateTime("1992-09-01"),
                Ghosted = true
            };
            persons.Add(newPerson);
        }

        internal void ExistingContacts()
        {
        Person newPerson = new Person
        {
            Name = "Emergency",
            LastName = "Number",
            Alias = "SOS",
            Email = "kundsupport112@sosalarm.se",
            Blocked = true
            };
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
            Console.Clear();
            Person newPerson = new Person();
            PropertyInfo[] Properties = typeof(Person).GetProperties();
            MenyDesign("Do you want to add basic information or everything? (Enter basic or everything as your answer)");
            Input = Console.ReadLine();

            if (Input.ToUpper() == "BASIC")
            {
               
                Console.Clear();
                if (Input.ToUpper() == "BASIC")
                {
                    Console.Write("Enter Firstname: ");
                    newPerson.Name = Console.ReadLine();
                    newPerson.Name = CapitalizeFirstLetter(newPerson.Name);
                    Console.Write("Enter Lastname: ");
                    newPerson.LastName = Console.ReadLine();
                    newPerson.LastName = CapitalizeFirstLetter(newPerson.LastName);
                    Console.Write("Enter Alias: ");
                    newPerson.Alias = Console.ReadLine();
                    newPerson.Alias = CapitalizeFirstLetter(newPerson.Alias);
                    Console.WriteLine("Please enter your date of birth in the format of YYYY-MM-DD.");
                    newPerson.BirthDay = Convert.ToDateTime(Console.ReadLine());

                }
                else if (Input.ToUpper() == "EVERYTHING")
                {
                    for (int i = 0; i < Properties.Length; i++)
                    {

                        Console.Write("Enter " + Properties[i].Name + ": ");
                        Input = Console.ReadLine();
                        Input = CapitalizeFirstLetter(Input);
                        if (Properties[i].Name == "Blocked" || Properties[i].Name == "Ghosted")
                        {
                            Properties[i].SetValue(newPerson, Convert.ToBoolean(Input));
                        }
                        else
                        {
                            Properties[i].SetValue(newPerson, Input);
                        }


                    }

                }
                else
                {
                    Console.WriteLine("Fel");
                }

            }
            else
            {
                Console.WriteLine("WRONG INPUT");

            }


            persons.Add(newPerson);
            PressAnything();
        }

        internal void UpdateExistingPerson()

        {
            Console.Clear();
            PrintContactsFristandLastName();
            InputFirstAndLastName();

            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine();

                if (persons[i].Name.Equals(Input) && persons[i].LastName.Equals(Input2))
                {
                    foreach (PropertyInfo prop in Properties)
                    {
                        persons[i].Age = DateTime.Today.Year - persons[i].BirthDay.Year;
                        Console.WriteLine(prop.Name + ": " + prop.GetValue(persons[i]));

                    }
                    Console.WriteLine();
                    Console.Write("Enter what you want to change (Case sensitive) : ");
                    InputCapitalLetter();

                    if (Input.ToUpper() == "BIRTHDAY")
                    {
                        Input = "BirthDay";
                        Console.WriteLine("Please enter your date of birth in the format of YYYY-MM-DD.");
                        Input2CapitalLetter();
                        persons[i].GetType().GetProperty(Input).SetValue(persons[i], Convert.ToDateTime(Input2));
                        SomethingHappened = true;

                    }
                    else
                    {
                        Console.Write("Enter what you want to change it to: ");
                        Input2CapitalLetter();
                    }


                        if (Input.ToUpper() == "BLOCKED")
                        {
                        SomethingHappened = true;
                        try
                        {
                            persons[i].GetType().GetProperty(Input).SetValue(persons[i], Convert.ToBoolean(Input2));
                        }

                        

                        catch (SystemException)
                        {
                            Input2 = "false";
                            SomethingHappened = false;

                        }
                            
                        }



                        else if (Input.ToUpper() == "GHOSTED")
                        {
                        SomethingHappened = true;
                        try
                        {
                            persons[i].GetType().GetProperty(Input).SetValue(persons[i], Convert.ToBoolean(Input2));
                        }



                        catch (SystemException)
                        {
                            Input2 = "false";
                            SomethingHappened = false;

                        }

                        }




                    else if (persons[i].GetType().GetProperty(Input) == null)
                    {

                            
                            
                                Input = "Steam";



                            
                            persons[i].GetType().GetProperty(Input).SetValue(persons[i], Input2);


                        Console.WriteLine("");
                        Console.WriteLine(Input + " Updated to " + Input2);
                        SomethingHappened = true;

                    }
                        else
                    {
                        persons[i].GetType().GetProperty(Input).SetValue(persons[i], Input2);
                        SomethingHappened = true;
                    }
                }
            }
            WrongInput();
            PressAnything();
        }



        internal void ShowInfoOfContact()
        {

            Console.Clear();
            PrintContactsFristandLastName();
            Console.Write("Enter firstname: ");
            Input = Console.ReadLine();
            Input = CapitalizeFirstLetter(Input);
            Console.Write("Enter lastname: ");
            Input2 = Console.ReadLine();
            Input2 = CapitalizeFirstLetter(Input2);

            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine();


                if (persons[i].Name.Contains(Input) && persons[i].LastName.Contains(Input2))
                {
                    foreach (PropertyInfo prop in Properties)
                    {
                        if (prop.GetValue(persons[i]) != null)
                        {
                            persons[i].Age = DateTime.Today.Year - persons[i].BirthDay.Year;
                            Console.WriteLine(prop.Name + ": " + prop.GetValue(persons[i]));
                        }

                    }
                    SomethingHappened = true;

                }


            }
            WrongInput();
            PressAnything();

        }
        internal void PrintPerson()
        {
            Console.Clear();
            Console.WriteLine("Do you want to list everyone or with a filter");
            Input = Console.ReadLine();

            if (Input.ToUpper() == "EVERYONE" || Input.ToUpper() == "ALL" || Input.ToUpper() == "EVERYONE")
            {
                PrintContactsFristandLastName();
                
                SomethingHappened = true;

            }
            else if (Input.ToUpper() == "FILTER")
            {
                Console.WriteLine("Do you want to filter by the first letter or do you want to filter blocked or ghosted users?");
                Console.WriteLine("");
                Console.WriteLine("Enter firstletter or blocked or ghosted to choose the filter you want.");
                InputCapitalLetter();
                if (Input.ToUpper() == "FIRSTLETTER")
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
                            persons[i].Age = DateTime.Today.Year - persons[i].BirthDay.Year;
                            Console.WriteLine("\t" + persons[i].Name + " " + persons[i].LastName);
                            Console.WriteLine();

                        }



                        SomethingHappened = true;

                    }
                }
                else if(Input.ToUpper() == "GHOSTED")
                {
                    for (int i = 0; i < persons.Count; i++)
                    {
                        
                        
                            if(persons[i].Ghosted.ToString() == "True" )
                            {
                            Console.Clear();
                                Console.WriteLine("These people are ghosted.");
                            Console.WriteLine("");
                            MenyDesign("Firstname: " + persons[i].Name + " " + "Lastname: " + persons[i].LastName);
                            SomethingHappened = true;


                        }

                        

                    }

                    
                }
                else if(Input.ToUpper() == "BLOCKED")
                {
                    for (int i = 0; i < persons.Count; i++)
                    {


                        if (persons[i].Blocked.ToString() == "True")
                        {
                            Console.Clear();
                            Console.WriteLine("These people are blocked.");
                            Console.WriteLine("");
                            MenyDesign("Firstname: " + persons[i].Name + " " + "Lastname: " + persons[i].LastName);
                            SomethingHappened = true;


                        }



                    }

                }


            }

            WrongInput();
            PressAnything();

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
                            if (persons[i].Name.Equals(Input) && persons[i].LastName.Equals(Input2))
                            {

                                persons.Remove(persons[i]);
                                Console.WriteLine("");
                                Console.WriteLine("Deleted");
                                SomethingHappened = true;

                            }
                        }
                    }
                if (SomethingHappened == false && remove.ToUpper() == "YES" || remove.ToUpper() == "Y")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong input");
                }
                SomethingHappened = false;


            }
            else if (remove.ToUpper() == "NO" || remove.ToUpper() == "N")
            {
                Console.WriteLine();
                Console.WriteLine("Did you enter the wrong menu?");
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            PressAnything();
        }
        private void PrintContactsAvailableProperties()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                count++;
                Console.WriteLine("Contact: " + count);
                foreach (PropertyInfo prop in Properties)
                {

                    if (prop.GetValue(persons[i]) != null)
                    {
                        Console.WriteLine("\t" + prop.Name + ": " + prop.GetValue(persons[i]));

                    }




                }

            }
        }
        private static void PressAnything()
        {
            Console.WriteLine();
            Console.WriteLine("Press something to continue");
            Console.ReadKey();
            Console.Clear();
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
                persons[i].Age = DateTime.Today.Year - persons[i].BirthDay.Year;
                Console.WriteLine("\t" + persons[i].Name + " " + persons[i].LastName);
                
                

                Console.WriteLine();



            }
            count = 0;

        }

        internal void Menu()
        {
            MenyDesign("To Add a new contact to your list enter 1 ");
            MenyDesign("To Access information about a contact enter 2");
            MenyDesign("To update a certain contact enter 3");
            MenyDesign("To delete a contact enter 4");
            MenyDesign("To list everyone in your contacts enter 5");


        }
        public string CapitalizeFirstLetter(string str)
        {


            if (str == null)
            {
                return null;
            }

            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }

            return str.ToUpper();



        }
        private static void MenyDesign(string Text)
        {

            Console.WriteLine("____________________________________________________________________________________________________");

            Console.WriteLine("");
            Console.WriteLine("          " + Text);
            Console.WriteLine("____________________________________________________________________________________________________");
        }
        private void Input2CapitalLetter()
        {
            Input2 = Console.ReadLine();
            Input2 = CapitalizeFirstLetter(Input2);
        }
        private void WrongInput()
        {
            if (SomethingHappened == false)
            {
                Console.WriteLine("Wrong input");

            }
            SomethingHappened = false;
        }

        private void InputCapitalLetter()
        {
            Input = Console.ReadLine();
            Input = CapitalizeFirstLetter(Input);
        }

    }






}

