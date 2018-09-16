using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    class Transaction
    {
        //properties

        //Amount – double type, withdraw or deposit amount
        public double Amount;

        //Type – TransactionType type, the type of the transaction
        public TransactionType Type;

        //TransactionDate – DateTime type, the date and the time of the transaction.
        public DateTime TransactionDate;

        //constructor to initialize its Amount property, Type property
        //and initialize TransactionDate to current date and time: DateTime.Now
        public Transaction(double customerAmount, TransactionType theType)
        {
            Amount = customerAmount;
            Type = theType;
            this.TransactionDate = DateTime.Now;
        }

        
    }
}
