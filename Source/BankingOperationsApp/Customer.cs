using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankingOperationsApp
{
    public class Customer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int TransCounter { get; set; }
        public bool IsVip { get; set; }

        public virtual void AccountDeposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
            {
                MessageBox.Show(Constants.errCannotDepositNegativeAmount,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            //TASK: Perform the transaction
            Balance = (Balance + depositAmount) - Constants.transactionFee;
            TransCounter++;
            MessageBox.Show(String.Format(Constants.msgTransactionSuccessful,
                                          Balance.ToString()),
                            Constants.titleTransactionSuccess,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public virtual void AccountWithdrawl(decimal withdrawlAmount)
        {
            if (withdrawlAmount <= 0)
            {
                MessageBox.Show(Constants.errCannotWithdrawNegativeAmount,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (Balance < (Constants.transactionFee + withdrawlAmount))
            {
                MessageBox.Show(Constants.errInsufficientFunds,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //TASK: Perform the transaction
            Balance = Balance - (Constants.transactionFee + withdrawlAmount);
            TransCounter++;
            MessageBox.Show(String.Format(Constants.msgTransactionSuccessful,
                                          Balance.ToString()),
                            Constants.titleTransactionSuccess,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


        }
    }

    class VIPCustomer : Customer
    {
        public override void AccountDeposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
            {
                MessageBox.Show(Constants.errCannotDepositNegativeAmount,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //TASK: Perform the transaction
            Balance = (Balance + depositAmount);
            TransCounter++;
            MessageBox.Show(String.Format(Constants.msgTransactionSuccessful,
                                            Balance.ToString()),
                            Constants.titleTransactionSuccess,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public override void AccountWithdrawl(decimal withdrawlAmount)
        {
            if (withdrawlAmount <= 0)
            {
                MessageBox.Show(Constants.errCannotWithdrawNegativeAmount,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (Balance < withdrawlAmount)
            {
                MessageBox.Show(Constants.errInsufficientFunds,
                                Constants.titleTransactionCancelled,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //TASK: Perform the transaction
            Balance = Balance - withdrawlAmount;
            TransCounter++;
            MessageBox.Show(String.Format(Constants.msgTransactionSuccessful,
                                            Balance.ToString()),
                            Constants.titleTransactionSuccess,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }

    public class Customers : IEnumerable<Customer>
    {
        private List<Customer> _CustomerList = new List<Customer>();

        //public Customer SelectedItem(int index)
        //{

        //}

        public void Add(Customer customer)
        {
            _CustomerList.Add(customer);
        }

        public bool Remove(Customer customer)
        {
            return _CustomerList.Remove(customer);
        }

        public void Clear()
        {
            _CustomerList.Clear();
        }

        public Customer this[int i]
        {
            get
            {
                return _CustomerList[i];
            }
            set
            {
                _CustomerList[i] = value;
            }
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _CustomerList.GetEnumerator();
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return _CustomerList.GetEnumerator();
        }
    }

    public class ZodiacSign
    {
        public int StartDay { get; set; }
        public int StartMonth { get; set; }
        public int EndDay { get; set; }
        public int EndMonth{ get; set; }
        public string Sign { get; set; }
    }
}