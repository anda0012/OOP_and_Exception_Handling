using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    class SavingAccount : Account   //inherits Account class
    {
        //static properties
        static public double PremierAmount = 2000.0;
        static public double WithdrawPenaltyAmount = 10.0;
        public string Name;  //wiil use below for creating a new customer object

        //constructor take one Customer type parameter to pass to its base class’ constructor
        //used this web page (3rd and 4th examples) for base format: 
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
        public SavingAccount(Customer name) : base(name)
        { }

        // override deposit from account class to change customer status to Premier when balance >= PremierAmount
        public override TransactionResult Deposit(Transaction tran)
        {
            base.Deposit(tran);

            if (Balance >= PremierAmount)
            {
                Owner.Status = CustomerStatus.PREMIER;
            }
            return TransactionResult.SUCCESS;
        }
        
        // overrride withdraw method to apply withdraw penalty
        public override TransactionResult Withdraw(Transaction tran)
        {                  
            base.Withdraw(tran);

            if (Owner.Status == CustomerStatus.REGULAR && Balance < PremierAmount)
            {
                // Apply withdraw penalty for regular customers
                Balance -= WithdrawPenaltyAmount;

                // create a new transaction for penalty
                Transaction tranPenalty = new Transaction(WithdrawPenaltyAmount, TransactionType.PENALTY);

                TransactionHistory.Add(tranPenalty); // add transaction penalty to history separately
            }            
                return TransactionResult.SUCCESS;
        }    
        

    }
}
