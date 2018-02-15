using System.Data;
using System.Collections.Generic;

namespace BankingOperationsApp
{
    public static class Variables
    {
        //TASK: Create a customer data set to bind to our onscreen data grid
        public static DataSet customerDataset = new DataSet();

        //TASK: Create the customer class to hold our customer data 
        //NOTE: This class object will demonstrate polymorphism & inheritance
        public static Customers Customers = new Customers();

        public static List<ZodiacSign> ZodiacSigns = new List<ZodiacSign>();
    }
}
