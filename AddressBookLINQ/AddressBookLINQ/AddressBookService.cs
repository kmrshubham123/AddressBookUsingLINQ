using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookLINQ
{
    /// <summary>
    /// UC1:-Create a Address Book Service
    /// </summary>
    public class AddressBookService
    {
        /// <summary>
        /// Create Data Table
        /// </summary>
        DataTable table = new DataTable();
        /// <summary>
        /// UC2:-Create a address Book Data Table with different Attributes
        /// </summary>
        public DataTable AddressBook()
        {
           
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));

            /// UC3:-Insert New Contact to Address Book

            table.Rows.Add("Kumar", "Shubham", "Nai Sarai", "Bihar Sharif", "Bihar", 813101, "+91-7060731565", "kmrshubham123@gmail.com");
            table.Rows.Add("Aman", "Kumar", "Amber", "Patna", "Bihar", 8000101, "9835434582", "Amankumar@gmail.com");
            table.Rows.Add("stuti", "Raj", "Shastri Park", "North Delhi", "New Delhi", 230215, "9632651259", "StutiRaj@gmail.com");
            table.Rows.Add("Alok", "Babu", "Ramgadhi", "Rampur", "Jharkhand", 306254, "+91-32659865476", "AlokBabu@gmail.com");
            table.Rows.Add("Tom", "Anderson", "Chirst", "Portblair", "Goa", 305854, "+91-2369865476", "Tom12@gmail.com");
            table.Rows.Add("Ram", "Kumar", "Rishra", "vardhman", "Kolkata", 236554, "+91-9859865476", "RamKumar@gmail.com");

            return table;
        }
        /// <summary>
        /// Display Contact
        /// </summary>
        /// <param name="tables"></param>
        public void DisplayContacts(DataTable tables)
        {
            var contacts = table.Rows.Cast<DataRow>(); //that contains the elements to be cast to type TResult.
            foreach (var contact in contacts)
            {
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName")
                    + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City")
                    + " " + "State : " + contact.Field<string>("State") + " " + "Phone Number : " + contact.Field<string>("PhoneNumber")
                    + " " + "Email : " + contact.Field<string>("Email"));
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// UC4:-Edit Existing Contact Person Using Their Name
        /// </summary>
        /// <param name="table"></param>
        public void EditContact(DataTable tables)
        {
            var Editcontacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Ram");
            foreach (var contact in Editcontacts)
            {
                contact.SetField("LastName", "Pandit");
                contact.SetField("Address", "Kushumpur");
                contact.SetField("City", "Siwan");
                contact.SetField("State", "Bihar");
                contact.SetField("Email", "kmrRam156@gmail.com");

            }
            Console.WriteLine("============Update Contact List====== \n");
            DisplayContacts(Editcontacts.CopyToDataTable());      // CopyToDataTable:-returns that contains copies of the System.Data.DataRow objects
        }
        /// <summary>
        /// UC5:-Delete a Person Using Person name
        /// </summary>
        /// <param name="tables"></param>
        public void DeleteContact(DataTable tables)
        {
            var Deletecontacts = table.AsEnumerable().Where(x => x.Field<string>("LastName") == "Anderson");
            foreach (var row in Deletecontacts.ToList())
            {
                row.Delete();
            }
            Console.WriteLine("------------Deleted Contact Person List--------- \n");
            DisplayContacts(table);
        }
        /// <summary>
        /// UC6:-Reterive Person Beloging to a State frrom Address Book
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveContactBelongingToState(DataTable tables)
        {
            var Reterivecontacts = table.AsEnumerable().Where(x => x.Field<string>("State") == "Bihar");
            foreach (var contact in Reterivecontacts)
            {
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName")
                  + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City")
                  + " " + "State : " + contact.Field<string>("State") + " " + "Phone Number : " + contact.Field<string>("PhoneNumber")
                  + " " + "Email : " + contact.Field<string>("Email"));
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// UC7:-Size of addressbook by state
        /// </summary>
        /// <param name="table"></param>
        public void SizeOfAddressBookByState(DataTable tables)
        {
            var Allcontacts = table.Rows.Cast<DataRow>()
                             .GroupBy(x => x["State"].Equals("Bihar")).Count();
            Console.WriteLine("Number of Contact Person Belonging from Particular State is : "+ Allcontacts);
        }
        /// <summary>
        /// UC8:-Reterive Entries sorted alphabetically by Person Name
        /// </summary>
        /// <param name="table"></param>
        public void SortPersonByName(DataTable tables)
        {
            var Sortcontacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"));
            foreach (var contact in Sortcontacts)
            {
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName")
                  + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City")
                  + " " + "State : " + contact.Field<string>("State") + " " + "Phone Number : " + contact.Field<string>("PhoneNumber")
                  + " " + "Email : " + contact.Field<string>("Email"));
                Console.WriteLine("\n");
            }

        }

    }
}
