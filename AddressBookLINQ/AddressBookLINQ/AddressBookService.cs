using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookLINQ
{
    /// <summary>
    /// UC1:-Create a Address Book Service
    /// </summary>
    public class AddressBookService
    {
        DataTable table = new DataTable("AddressBook");
        /// <summary>
        /// UC2:-Create a address Book Data Table with different Attributes
        /// </summary>
        public void AddressBook()
        {
           
            table.Columns.Add("FirstName");
            table.Columns.Add("LastName");
            table.Columns.Add("Address");
            table.Columns.Add("City");
            table.Columns.Add("State");
            table.Columns.Add("Zip");
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("Email");
        }
    }
}
