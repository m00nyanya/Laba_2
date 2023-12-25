using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    public sealed class NoteBook
    {
        private static List<Contact> contacts = new List<Contact>();
        private static List<Contact> c;

        public NoteBook()
        {
            Instruction();
            /*Contact k = new Contact();
            k.Name = "pou";
            k.Surname = "Konn";
            k.Phone = "555";
            k.Email = "pou";
            Contact p = new Contact();
            p.Name = "pou";
            p.Surname = "Konn";
            p.Phone = "555";
            p.Email = "pou";
            contacts.Add(k);
            contacts.Add(p);*/
            while (true) { GetInformation(); }
        }

        public static void Instruction()
        {
            Console.WriteLine("Enter the number of action and press [Enter]. Then follow instructions.");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all contacts");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. New contact");
            Console.WriteLine("4. Exit");
        }

        private static void GetInformation()
        {
            Console.Write(">");
            string menu = Console.ReadLine();

            if (menu.Length > 1)
            {
                Console.WriteLine("Try again.");
            }
            else
            {
                try
                {
                    switch (menu)
                    {
                        case "1":
                            PrintAll();
                            break;
                        case "2":
                            SearchMethod();
                            break;
                        case "3":
                            ConstructContact();
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default: throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Impossible!");
                }
            }
            Instruction();
        }

        public static void Add(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();
            contacts.Add(contact);
            if (contacts.Contains(contact))
            {
                Console.WriteLine("Contact added.");
            }
            else
            {
                Console.WriteLine("Problem occured");
            }

        }
        public static void PrintAll()
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i] == null) { contacts.RemoveAt(i); continue; }
                Console.WriteLine(contacts[i].ToString() + Environment.NewLine);
            }
            Console.WriteLine("All contacts are printed");
        }

        public static void SearchMethod()
        {
            Console.WriteLine("Search: ");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Name and Surname");
            Console.WriteLine("4. Phone");
            Console.WriteLine("5. E-mail");

            Console.Write(">");
            string menu = Console.ReadLine();

            if (menu.Length > 1)
            {
                Console.WriteLine("Try again.");
            }
            else
            {
                try
                {
                    string str = InsertSearch();
                    switch (menu)
                    {
                        case "1":
                            c = contacts.FindAll(s => s.Name.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
                            Print(c);
                            break;
                        case "2":
                            c = contacts.FindAll(s => s.Surname.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
                            Print(c);
                            break;
                        case "3":
                            c = contacts.FindAll(s => s.Name.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0 || s.Surname.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
                            Print(c);
                            break;
                        case "4":
                            c = contacts.FindAll(s => s.Phone.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
                            Print(c);
                            break;
                        case "5":
                            c = contacts.FindAll(s => s.Email.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
                            Print(c);
                            break;
                        default: throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Imposiible");
                }
            }
        }

        private static void Print(List<Contact> c)
        {
            int k = c.Count;
            Console.WriteLine("Searching..." + Environment.NewLine + "Results " + "(" + k + ")");
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("#" + (i + 1) + " " + c[i].ToString());
                Console.WriteLine();
            }
            c.Clear();
        }
        private static string InsertSearch()
        {
            Console.Write(">");
            string str = Console.ReadLine();
            Console.WriteLine("Request: " + str);
            return str;
        }

        private static void InsertInfo(Contact c)
        {
            Console.WriteLine("Nickname:");
            c.Nickname = Console.ReadLine();
            Console.WriteLine("Name:");
            c.Name = Console.ReadLine();
            Console.WriteLine("Surname:");
            c.Surname = Console.ReadLine();
            Console.WriteLine("Phone:");
            c.Phone = Console.ReadLine();
            Console.WriteLine("Email:");
            c.Email = Console.ReadLine();
            Console.WriteLine("Birth date in US style:");
            c.Birthday = DateTime.Parse(Console.ReadLine());
        }

        private static void ConstructContact()
        {
            Contact c = new Contact();
            InsertInfo(c);
            Add(c);
        }
    }
}
