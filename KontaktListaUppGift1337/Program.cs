using System;

namespace KontaktListaUppGift1337
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ContactList ccl = new ContactList();
            int MenuChoice = 0;
            ccl.ExistingContacts();
            ccl.ExistingContacts2();
            do
            {

                MenuChoice = Menu();
                if (MenuChoice == 1)
                {
                    ccl.AddNewPerson();
                }
                else if (MenuChoice == 2)
                {
                    ccl.ShowInfoOfContact();

                }
                else if (MenuChoice == 3)
                {
                    ccl.UpdateExistingPerson();

                }
                else if (MenuChoice == 4)
                {
                    ccl.DeletePerson();


                }
                else if (MenuChoice == 5)
                {
                    ccl.PrintPerson();

                }



            } while (MenuChoice > 0 || MenuChoice <= 5);












        }

        private static int Menu()
        {
            int MenuChoice;
            MenyDesign("To Add a new contact to your list enter 1 ");
            MenyDesign("To Access information about a contact enter 2");
            MenyDesign("To update a certain contact enter 3");
            MenyDesign("To delete a contact enter 4");
            MenyDesign("To list everyone in your contacts enter 5");
            try
            {


                MenuChoice = int.Parse(Console.ReadLine());
                return MenuChoice;
            }
            catch (Exception)
            {
                MenuChoice = 0;
                return MenuChoice;

            }



        }

        private static void MenyDesign(string Text)
        {

            Console.WriteLine("_______________________________________________________________");

            Console.WriteLine("");
            Console.WriteLine("          " + Text);
            Console.WriteLine("_______________________________________________________________");
        }
    }
}
