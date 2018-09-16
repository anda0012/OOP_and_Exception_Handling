using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    class CheckingAccount : Account  //inherits Account class
    {
        //MaxWithdrawAmount – static double type, initialize to 300.0
        static public double MaxWithdrawAmount = 300.0;      
        public string Name; //wiil use below for creating a new customer object

        //constructor takes one Customer type parameter to pass to its base class’ constructor
        //used this web page (3rd and 4th examples) for base format: 
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
        public CheckingAccount(Customer name) : base(name)    
        { }

        // override base class' Withdraw method to check for regular customers and apply max withdraw amount
        public override TransactionResult Withdraw(Transaction tran)
        {
            base.Withdraw(tran);
            
            if (Owner.Status == CustomerStatus.REGULAR && tran.Amount > MaxWithdrawAmount)
            {                
                return TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;                         
            }
         
            return TransactionResult.SUCCESS;
        }

     
    }
}
