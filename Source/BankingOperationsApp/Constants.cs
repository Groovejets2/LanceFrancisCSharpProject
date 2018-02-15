namespace BankingOperationsApp
{
    public class Constants
    {
        public const string msgPressOkButtonToContinue = "Press OK Button to exit";
        public const string msgLeapYearMessageHeader = "Leap Years and Zodiac Signs\n\n";

        public const string msgLeapYearCustomerDetails = "ID:\t\t{0}\n" +
                                                         "Name:\t\t{1}\n" +
                                                         "Birth Date:\t\t{2}\n" +
                                                         "Balance:\t\t${3}\n" +
                                                         "Zodiac:\t\t{4}\n\n";

        public const string errSourceDataFileNotFound = "The source customer data file could not be found";
        public const string errPleaseSelectAnAccount = "Please select a customer account in order to perform a transaction";
        public const string errCannotWithdrawNegativeAmount = "You cannot withdraw a negative or zero dollar amount.";
        public const string errCannotDepositNegativeAmount = "You cannot deposit a zero or negative balance amount.";
        public const string errInsufficientFunds = "You do not have enough funds to perform this transaction.";

        public const string msgPleaseEnterTheDollarAmount = "Please enter the decimal dollar amount:";
        public const string msgTransactionSuccessful = "Transcaction successful. Your account balance is now [ ${0} ].";
        public const string wrnPleaseSelectCustomer = "Please select a customer in the list before selecting a transaction.";
        public const string wrnAmountEnteredIsNotDeciumal = "The value you entered was not a decimal value. Transaction cancelled.";

        public const string titleTransactionCancelled = "Transaction Cancelled";
        public const string titleTransactionSuccess = "Transaction Success";
        public const string titleTransactionAmount = "Transaction Amount";

        public const string csvFileName = "input_assignment_1.csv";
        public const string csvColumnSeperator = ",";
        public const string customerTableName = "CustomerData";
        public const string fieldNameAccountNumber = "AccountNumber";
        public const string fieldNameAccountBalance = "Balance";
        public const string vipCode = "VIP";

        public const decimal transactionFee = 3.00m;
    }
}
