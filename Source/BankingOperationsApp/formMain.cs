using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace BankingOperationsApp
{
    public partial class fMain : Form
    { 
        public fMain()
        {
            InitializeComponent();

            //TASK: Initialise our Zodiac signs class
            SetupZodiacSigns();

            //TASK: Initialise the form menu items state
            UpdateFormMenuItems();
        }

        #region Private Methods - Non-Banking Operations

        private void btnQuit_Click(object sender, EventArgs e)
        {
            ExitTheApplication();
        }

        private void lockDataGridAndApplyStyle()
        {
            dgCustomerData.MultiSelect = false;
            dgCustomerData.AllowUserToAddRows = false;
            dgCustomerData.AllowUserToDeleteRows = false;
            dgCustomerData.ReadOnly = true;
            dgCustomerData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
        }

        private void UpdateFormMenuItems()
        {
            //CHECK: Do we have customer data?
            if (Variables.Customers.Count() == 0)
            {
                //TASK: No customer data, disable banking operations
                bankingOperationsToolStripMenuItem.Enabled = false;
            }
            else
            {
                //TASK: We have customer data, enable banking operations
                bankingOperationsToolStripMenuItem.Enabled = true;
            }
        }

        private void ExitTheApplication()
        {
            dgCustomerData.Dispose();
            Variables.Customers.Clear();
            this.Close();
            this.Dispose();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitTheApplication();
        }

        private bool CheckHasUserSelectedACustomer()
        {
            bool ResturnStatus = true;

            if (dgCustomerData.SelectedCells.Count == 0)
            {
                ResturnStatus = false;
                MessageBox.Show(Constants.wrnPleaseSelectCustomer,
                Constants.titleTransactionCancelled,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            return ResturnStatus;
        }

        private void SetupZodiacSigns()
        {
            Variables.ZodiacSigns.Add( new ZodiacSign
            {
                StartDay = 21,
                StartMonth = 3,
                EndDay = 19,
                EndMonth = 4,
                Sign = "Aries"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 20,
                StartMonth = 4,
                EndDay = 20,
                EndMonth = 5,
                Sign = "Taurus"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 21,
                StartMonth = 5,
                EndDay = 20,
                EndMonth = 6,
                Sign = "Gemini"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 21,
                StartMonth = 6,
                EndDay = 22,
                EndMonth = 7,
                Sign = "Cancer"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 23,
                StartMonth = 7,
                EndDay = 22,
                EndMonth = 8,
                Sign = "Leo"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 23,
                StartMonth = 8,
                EndDay = 22,
                EndMonth = 9,
                Sign = "Virgo"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 23,
                StartMonth = 9,
                EndDay = 22,
                EndMonth = 10,
                Sign = "Libra"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 23,
                StartMonth = 10,
                EndDay = 21,
                EndMonth = 11,
                Sign = "Scorpio"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 22,
                StartMonth = 11,
                EndDay = 21,
                EndMonth = 12,
                Sign = "Sagittarious"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 22,
                StartMonth = 12,
                EndDay = 19,
                EndMonth = 1,
                Sign = "Capricorn"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 20,
                StartMonth = 1,
                EndDay = 18,
                EndMonth = 2,
                Sign = "Aquarious"
            });

            Variables.ZodiacSigns.Add(new ZodiacSign
            {
                StartDay = 19,
                StartMonth = 2,
                EndDay = 20,
                EndMonth = 3,
                Sign = "Pisces"
            });

        }

        private string ReturnZodiacSign(int BirthDay, int BirthMonth)
        {
            string ZodiacSign = string.Empty;

            foreach (var z in Variables.ZodiacSigns)
            {
                //CHEK: Are we in the start month range?
                if (BirthMonth == z.StartMonth)
                {
                    if (BirthDay >= z.StartDay)
                    {
                        ZodiacSign = z.Sign;
                        break;
                    }
                }
                //CHEK: Are we in the end month range?
                if (BirthMonth == z.EndMonth)
                {
                    if (BirthDay <= z.EndDay)
                    {
                        ZodiacSign = z.Sign;
                        break;
                    }
                }
            }
            return ZodiacSign;
        }

        #endregion

        #region Private Methods - Banking Data Operations

        private void importCustomerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load the CSV file from the applications current executing folder folder.
            var sourceCsvDataFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).TrimEnd('\\') + "\\" +
                                    Constants.csvFileName;
            var lineCounter = 0;

            prepareCustomerDataSet();

            if (!File.Exists(sourceCsvDataFile))
            {
                MessageBox.Show(Constants.errSourceDataFileNotFound);
                return;
            }
            using (var sourceFileHandle = File.OpenRead(sourceCsvDataFile))
            using (var sourceFileReader = new StreamReader(sourceFileHandle))
            {
                while (!sourceFileReader.EndOfStream)
                {
                    var sourceFileLine = sourceFileReader.ReadLine();
                    string[] customerRecordList = sourceFileLine.Split(',');
                    importCustomerData(customerRecordList, lineCounter);
                    lineCounter++;
                }
            }
            //TASK: Make the data set the source of the data grid data
            dgCustomerData.DataSource = Variables.customerDataset.Tables[0].DefaultView;
            //TASK: Lock down the data grid so rows cannot be added, edited or deleted
            lockDataGridAndApplyStyle();

            //TASK: Update the form menu options
            UpdateFormMenuItems();
        }

        private void prepareCustomerDataSet()
        {
            //CHECK: Does the table exist already in our dataset?
            if (Variables.customerDataset.Tables.Count == 0)
            {
                //TASK: Add a table to our data set
                Variables.customerDataset.Tables.Add(Constants.customerTableName);
            }
            else
            {
                //TASK: The table already exists. Clear all its data
                Variables.customerDataset.Tables[0].Clear();
            }
        }

        private void importCustomerData(string[] customerRecordList, int lineCount)
        {
            //TASK: Check for non-VIP short array
            if (customerRecordList.Length == 5)
            {
                Array.Resize(ref customerRecordList, customerRecordList.Length + 1);
                customerRecordList[5] = string.Empty;
            }

            //CHECK: Is this the first line in the CSV file?
            if (lineCount == 0)
            {
                #region Add Data Grid Column Names

                //Loop through each CSV header line column name in the list
                foreach (var column in customerRecordList)
                {
                    //TASK: Get a list of existing column names
                    DataColumnCollection columns = Variables.customerDataset.Tables[Constants.customerTableName].Columns;
                    //CHECK: Does this column name exist in the list already?
                    if (!columns.Contains(column))
                    {
                        // Label each data grid column header using each of the the first CSV row column names
                        Variables.customerDataset.Tables[Constants.customerTableName].Columns.Add(column);
                    }
                }

                #endregion
            }
            else
            {
                Variables.customerDataset.Tables[Constants.customerTableName].Rows.Add(customerRecordList);

                //TASK: Add the record to our customer class object
                addCustomerToCustomersClass(customerRecordList[0],
                                            customerRecordList[1],
                                            customerRecordList[2],
                                            customerRecordList[3],
                                            customerRecordList[4],
                                            customerRecordList[5]);
            }
        }

        private void addCustomerToCustomersClass(string firstName, 
                                                 string lastName, 
                                                 string dateOfBirth, 
                                                 string bankAccountId, 
                                                 string bankBalance,
                                                 string isVip)
        {
            bool _isVip = false;
            if(isVip != null && isVip != string.Empty)
                _isVip = true;

            if (_isVip == false)
            {
                //TASK: Add non VIP customer to our collection class
                Variables.Customers.Add(new Customer
                {
                    Firstname = firstName,
                    Lastname = lastName,
                    DateOfBirth = Convert.ToDateTime(dateOfBirth),
                    AccountNumber = Convert.ToInt32(bankAccountId),
                    Balance = Convert.ToDecimal(bankBalance),
                    IsVip = _isVip,
                    TransCounter = 0
                });
            }
            else
            {
                //TASK: Add a VIP customer to our collection class
                //TASK: Add non VIP customer to our collection class
                Variables.Customers.Add(new VIPCustomer
                {
                    Firstname = firstName,
                    Lastname = lastName,
                    DateOfBirth = Convert.ToDateTime(dateOfBirth),
                    AccountNumber = Convert.ToInt32(bankAccountId),
                    Balance = Convert.ToDecimal(bankBalance),
                    IsVip = _isVip,
                    TransCounter = 0
                });
            }
        }

        #endregion

        #region Private Methods - Banking Account Operations

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckHasUserSelectedACustomer()) return;

            //TASK: Get the transaction decimal amount from the user
            string dollarAmountString = Interaction.InputBox(Constants.msgPleaseEnterTheDollarAmount, 
                                                             Constants.titleTransactionAmount, 
                                                             String.Empty);
            decimal dollarAmount;

            //CHECK: Is the input value a decimal
            if (Decimal.TryParse(dollarAmountString, out dollarAmount))
            {
                int selectedRowIndex = dgCustomerData.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgCustomerData.Rows[selectedRowIndex];
                int accountNumberSelected = Convert.ToInt32(selectedRow.Cells[Constants.fieldNameAccountNumber].Value);
                Customer selectedCustomer = Variables.Customers.FirstOrDefault(c => c.AccountNumber == accountNumberSelected);
                selectedCustomer.AccountDeposit(dollarAmount);
                //TASK: Update the data grid view
                selectedRow.Cells[Constants.fieldNameAccountBalance].Value = selectedCustomer.Balance.ToString();
            }
            else
            {
                MessageBox.Show(Constants.wrnAmountEnteredIsNotDeciumal,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void withdrawlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckHasUserSelectedACustomer()) return;

            //TASK: Get the transaction decimal amount from the user
            string dollarAmountString = Interaction.InputBox(Constants.msgPleaseEnterTheDollarAmount,
                                                             Constants.titleTransactionAmount, 
                                                             String.Empty);
            decimal dollarAmount;

            //CHECK: Is the input value a decimal
            if (Decimal.TryParse(dollarAmountString, out dollarAmount))
            {
                int selectedrowindex = dgCustomerData.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgCustomerData.Rows[selectedrowindex];
                int accountNumberSelected = Convert.ToInt32(selectedRow.Cells[Constants.fieldNameAccountNumber].Value);
                Customer selectedCustomer = Variables.Customers.FirstOrDefault(c => c.AccountNumber == accountNumberSelected);

                selectedCustomer.AccountWithdrawl(dollarAmount);
                //TASK: Update the data grid view
                selectedRow.Cells[Constants.fieldNameAccountBalance].Value = selectedCustomer.Balance.ToString();
            }
            else
            {
                MessageBox.Show(Constants.wrnAmountEnteredIsNotDeciumal,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void maxBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maxBalanceCustomer = (from c in Variables.Customers
                                      orderby c.Balance descending
                                      select c).FirstOrDefault();
            if (maxBalanceCustomer != null)
            {
                string maxBalanceMessage = String.Format("The customer with the huighest bank balance is {0} with an account balance of[ ${1} ]",
                                              maxBalanceCustomer.Firstname + " " + maxBalanceCustomer.Lastname,
                                              maxBalanceCustomer.Balance.ToString());

                //CHECK: Is it the customers birthday today?
                if (maxBalanceCustomer.DateOfBirth.Day == DateTime.Now.Day &&
                    maxBalanceCustomer.DateOfBirth.Month == DateTime.Now.Month)
                {
                    maxBalanceMessage = maxBalanceMessage + "\nHappy Birthday!";
                }

                MessageBox.Show(maxBalanceMessage, 
                                "Maximum Balance", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("No customers have positive or nonzero account balances.",
                                "No Maximum Balance Accounts",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void mostActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var activeCustomer = (from c in Variables.Customers
                                    where c.TransCounter > 0
                                    orderby c.TransCounter descending
                                    select c).FirstOrDefault();
            if (activeCustomer != null)
            {
                MessageBox.Show(string.Format("The most active customer is {0} with [ {1} ] transactions",
                                              activeCustomer.Firstname + " " + activeCustomer.Lastname,
                                              activeCustomer.TransCounter.ToString()));
            }
            else
            {
                MessageBox.Show("No customer transactions have been performed. All customers have zero activity.",
                                "No Account Activity",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
        }

        private void youngestCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var youngestCustomer = (from c in Variables.Customers
                                    orderby c.DateOfBirth descending
                                    select c).FirstOrDefault();
            MessageBox.Show(String.Format("The youngest customer is {0} with a birth date of [ {1} ]", 
                                          youngestCustomer.Firstname + " " + youngestCustomer.Lastname,
                                          youngestCustomer.DateOfBirth.ToString("dd MMMM yyyy")));
        }

        private void leapYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string leapMessage = Constants.msgLeapYearMessageHeader;
            bool doWeHaveLeapYearCustomers = false;
            foreach (Customer c in Variables.Customers)
            {
                if(DateTime.IsLeapYear(c.DateOfBirth.Year))
                {
                    doWeHaveLeapYearCustomers = true;
                    if(c.IsVip)
                        leapMessage = leapMessage + "VIP Customer\n";
                    leapMessage = leapMessage + String.Format(Constants.msgLeapYearCustomerDetails,
                                                              c.AccountNumber.ToString(),
                                                              c.Firstname + " " + c.Lastname,
                                                              c.DateOfBirth.ToString("dd/MM/yyyy"),
                                                              c.Balance.ToString(),
                                                              ReturnZodiacSign(c.DateOfBirth.Day, c.DateOfBirth.Month));
                }
            }

            if (doWeHaveLeapYearCustomers)
            {
                MessageBox.Show(leapMessage,
                                "Leap Year Customers",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("None of the customers were born in a leap year.",
                                "No Leap Year Customers",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
