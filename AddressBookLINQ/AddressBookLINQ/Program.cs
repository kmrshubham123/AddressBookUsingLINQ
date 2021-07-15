using System;
using System.Data;

namespace AddressBookLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Using Linq");
            AddressBookService service = new AddressBookService();
            DataTable dataTable = service.AddressBook();
            service.DisplayContacts(dataTable);


        }
    }
}
