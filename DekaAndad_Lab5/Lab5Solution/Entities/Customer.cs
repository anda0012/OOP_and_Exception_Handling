using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    class Customer
    {
        //properties

        public string Name;
        public CustomerStatus Status; //refers to enum
        public CheckingAccount Checking; //its type is the class CheckingAccount
        public SavingAccount Saving; //its type is the class SavingAccount
              
        //constructor for customer name. Also initiate status, checking and saving account
        public Customer(string CustName)
        {
            this.Name = CustName;            
            Checking = new CheckingAccount(this);
            Saving = new SavingAccount(this);         
        }

        //create a method to determine customer status depending on Saving Balance
        public CustomerStatus getCustStatus()   
        {
            if (Saving.Balance >= SavingAccount.PremierAmount)
            {
                Status = CustomerStatus.PREMIER;
            }
            else
            {
                Status = CustomerStatus.REGULAR;
            }
            return Status;
        }
      
    }
}
