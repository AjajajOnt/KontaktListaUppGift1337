using System;
using System.Collections.Generic;

namespace KontaktListaUppGift1337
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ContactList ccl = new ContactList();
            int MenuChoice = 0;

            do
            {
                MenuChoice = Menu();

                if (MenuChoice == 1)
                {
                    ccl.start();
                }


            } while (MenuChoice > 0 || MenuChoice <= 5  );












        }

        private static int Menu()
        {
            int MenuChoice;
            MenyDesign("To Add a new contact to your list enter 1 ");
            MenyDesign("To Acces information about a contact enter 2");
            MenyDesign("To update a certain contact enter 3");
            MenyDesign("To delete a contact enter 4");
            MenyDesign("To list everyone in your contacts enter 5");
            MenuChoice = int.Parse(Console.ReadLine());
            return MenuChoice;
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
