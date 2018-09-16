using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    class Account 
    {
        //properties
        public Customer Owner;  // customer class is the type
        public double Balance;
        public List<Transaction> TransactionHistory;  //need a list of transaction history

        //constructor to initialize Owner (as well as balance and TransactionHistory)
        public Account(Customer CustName)
        {
            this.Owner = CustName;
            Balance = 0.0;   // initialize balance to $0
            TransactionHistory = new List<Transaction>(); //initialize transaction list
        }
        
        //method #1: increase the balance by the transaction amount (deposit)
        public virtual TransactionResult Deposit(Transaction tran)
        {
            Balance += tran.Amount;    //add transaction amount to balance
            TransactionHistory.Add(tran); //add deposit to transaction history list

            return TransactionResult.SUCCESS; // for each deposit return success
        }

        //method #2: decrease the balance by the transaction amount (withdrawal)
        public virtual TransactionResult Withdraw(Transaction tran)
        {
            if (tran.Amount <= Balance)   //allow withdraw only if amount doesn't exceed balance
            {
                Balance -= tran.Amount;       //subract transaction amount from balance
                TransactionHistory.Add(tran);    //add withdraw to transaction history 

                return TransactionResult.SUCCESS;
            }

            //if withdrawal exceeds balance return insufficient fund
            else 
            {                
                return TransactionResult.INSUFFICIENT_FUND;
            }            
        }


    }//end of class
}
