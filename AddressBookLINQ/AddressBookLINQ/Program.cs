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
            //UC4:-Edit Contact
            service.EditContact(dataTable);
            //UC5:-Delete Contact
            service.DeleteContact(dataTable);
            //UC6:-Reterive Person Beloging to a State frrom Address Book
            Console.WriteLine("------------Particular person Belonging to their State--------- ");
            service.RetrieveContactBelongingToState(dataTable);
            //UC7:-Size of addressbook by state
            Console.WriteLine("==========================================");
            service.SizeOfAddressBookByState(dataTable);
            //UC8:-Reterive Entries sorted alphabetically by Person Name
            Console.WriteLine("==========================================");
            service.SortPersonByName(dataTable);

        }
    }
}
