using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5Solution.Entities;

namespace Lab5Solution
{
    class Bank
    {
        static void Main(string[] args)
        {
            string Name;

            //create a list of customers (their status and 2 accounts)
            List<Customer> customerList = new List<Customer>();

            Console.Write("Welcome to Algonquin Bank!");
            Console.ReadLine();

            // Get customer names
            while (true)
            {
                Console.Write("\nEnter customer name: ");
                Name = Console.ReadLine();

                // break out of loop if user does not enter a name
                if (Name == "")
                {
                    break;
                }

                // prompt user to enter initial deposit amount
                Console.Write("Enter {0}'s Initial Deposit Amount: ", Name);

                // Check for and catch errors
                try
                {
                    double initialDeposit;
                    string input = Console.ReadLine();

                    // To validate number input, I used this method: https://stackoverflow.com/questions/4804968/how-can-i-validate-console-input-as-integers
                    // This method stores the string input as a number in initialDeposit using the 'out' method

                    // If input stored in initialDeposit is NOT a number, inform user 
                    // Or if input stored is converted to a number BUT is <= 0, then inform user
                    // Program continues when initialDeposit returns as number over 0

                    if (!double.TryParse(input, out initialDeposit) || double.TryParse(input, out initialDeposit) && initialDeposit <= 0)
                    {
                        Console.WriteLine("\nInvalid Entry, try again!");
                        continue; // continue once we have number over 0
                    }

                    // create the new customer with given name
                    Customer newCustomer = new Customer(Name);

                    // create a new transaction for each new customer
                    Transaction tran = new Transaction(initialDeposit, TransactionType.DEPOSIT);

                    // update Saving Balance
                    newCustomer.Saving.Deposit(tran);

                    // add each customer to list
                    customerList.Add(newCustomer);
                }
                catch
                {
                    Console.ReadLine(); // Display invalid input message to user
                }

            } // end of while loop for getting names        

            ////////////////////////////////////////////////////////////////////////////////////////////

            // Only run when list count > 0
            while (customerList.Count > 0)
            {
                Console.WriteLine("\nSelect one of the following customers:");
                
                // get customer index
                int i = 0;  //customer number index

                foreach (Customer newCustomer in customerList)
                {
                    Console.WriteLine("{0} - Customer {1}, current status {2}", i, newCustomer.Name, newCustomer.getCustStatus().ToString());
                    i++;
                }

                Console.Write("\nEnter your selection from 0 to {0}: ", i - 1); //subtract 1 to get correct index

                int selection;
                string userInput = Console.ReadLine();
                try
                {
                    if (!int.TryParse(userInput, out selection) || int.TryParse(userInput, out selection) && selection < 0 || selection > i - 1)
                    {
                        Console.WriteLine("\nInvalid Entry, try again!");
                        //Console.Read();
                        continue;
                    }

                    Console.WriteLine("\nWelcome {0}! You are currently our {1} customer.", customerList[selection].Name, customerList[selection].getCustStatus().ToString()); //NEED TO CONVERT STATUS TO A STRING

                    //Assign variable name to the selected customer's checking account
                    CheckingAccount checking = customerList[selection].Checking;

                    //Assign variable name to the selected customer's saving account
                    SavingAccount saving = customerList[selection].Saving;

                    // loop through menu
                    while (true)
                    {
                        Console.WriteLine("\nSelect one of the following activities:");
                        // display menu
                        Console.WriteLine("\n1. Deposit ...");
                        Console.WriteLine("2. Withdraw ...");
                        Console.WriteLine("3. Transfer ...");
                        Console.WriteLine("4. Balance Enquiry ...");
                        Console.WriteLine("5. Account Activity Enquiry ...");
                        Console.WriteLine("6. Exit");

                        Console.Write("\nEnter your selection (1 to 6): ");

                        int activity;
                        string userInput2 = Console.ReadLine();

                        if (!int.TryParse(userInput2, out activity) || int.TryParse(userInput2, out activity) && activity < 1 || activity > 6)
                        {
                            Console.WriteLine("\nInvalid Entry, try again!");                            
                            continue;
                        }

                        //////////////////////////////////////////////////////////////////////////////////////////  

                        if (activity == 1)  //Deposit
                        {
                            Console.Write("\nSelect account (1 - Checking Account; 2 - Saving Account): ");
                            int accOption;
                            string enterAccount = Console.ReadLine();

                            if (!int.TryParse(enterAccount, out accOption) || int.TryParse(enterAccount, out accOption) && accOption < 1 || accOption > 2)
                            {
                                Console.WriteLine("\nInvalid Entry, try again!");
                                continue;
                            }

                            if (accOption == 1) // Checking                      
                            {
                                Console.Write("\nEnter amount: ");
                                double checkingDeposit;
                                string input = Console.ReadLine();

                                if (!double.TryParse(input, out checkingDeposit) || double.TryParse(input, out checkingDeposit) && checkingDeposit <= 0)
                                {
                                    Console.WriteLine("\nInvalid Entry, try again!");
                                    continue; // continue once we have number over 0
                                }

                                //create a new transaction in Checking for the customer and update balance
                                Transaction tran = new Transaction(checkingDeposit, TransactionType.DEPOSIT);
                                checking.Deposit(tran);

                                Console.WriteLine("\n\tDeposit complete, account current balance: $" + checking.Balance);
                            }//end of Checking

                            else  // Saving
                            {
                                Console.Write("\nEnter amount: ");
                                double savingDeposit;
                                string input = Console.ReadLine();

                                if (!double.TryParse(input, out savingDeposit) || double.TryParse(input, out savingDeposit) && savingDeposit <= 0)
                                {
                                    Console.WriteLine("\nInvalid Entry, try again!");
                                    continue; // continue once we have number over 0
                                }

                                //create a new transaction in Checking for the customer
                                Transaction tran = new Transaction(savingDeposit, TransactionType.DEPOSIT);
                                saving.Deposit(tran); 

                                Console.WriteLine("\n\tDeposit complete, account current balance: $" + saving.Balance);
                            } // end of Saving                        

                        }// end of Deposit Option 1

                        ////////////////////////////////////////////////////////////////////////////////////////

                        else if (activity == 2) // Withdraw
                        {
                            Console.Write("\nSelect account (1 - Checking Account; 2 - Saving Account): ");
                            int accOption;
                            string enterAccount = Console.ReadLine();

                            if (!int.TryParse(enterAccount, out accOption) || int.TryParse(enterAccount, out accOption) && accOption < 1 || accOption > 2)
                            {
                                Console.WriteLine("\nInvalid Entry, try again!");                    
                                continue;
                            }

                            if (accOption == 1) // Checking
                            {
                                Console.Write("\nEnter amount: ");
                                double checkingWithdrawal;
                                string input = Console.ReadLine();

                                if (!double.TryParse(input, out checkingWithdrawal) || double.TryParse(input, out checkingWithdrawal) && checkingWithdrawal <= 0)
                                {
                                    Console.WriteLine("\nInvalid Entry, try again!");
                                    continue; // continue once we have number over 0
                                }

                                // withdrawal cannot exceed balance else it return insufficient fund
                                if (checkingWithdrawal <= checking.Balance)
                                {
                                    if (customerList[selection].getCustStatus() == CustomerStatus.REGULAR && checkingWithdrawal > CheckingAccount.MaxWithdrawAmount)
                                    {
                                        Console.WriteLine("\n\tWithdraw cancelled: " + TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT);
                                    }
                                    else
                                    {
                                        Transaction tran = new Transaction(checkingWithdrawal, TransactionType.WITHDRAW);
                                        checking.Withdraw(tran);

                                        Console.WriteLine("\n\tWithdrawal complete, account current balance: $" + checking.Balance);
                                    }
                                }
                                else  
                                {
                                    Console.WriteLine("\n\tWithdraw cancelled: " + TransactionResult.INSUFFICIENT_FUND);
                                }

                            }// end of checking

                            else if (accOption == 2) // Saving
                            {
                                Console.Write("\nEnter amount: ");
                                double savingWithdrawal;
                                string input = Console.ReadLine();

                                if (!double.TryParse(input, out savingWithdrawal) || double.TryParse(input, out savingWithdrawal) && savingWithdrawal <= 0)
                                {
                                    Console.WriteLine("\nInvalid Entry, try again!");
                                    continue; // continue once we have number over 0
                                }

                                // withdrawal cannot exceed balance
                                if (savingWithdrawal <= saving.Balance)
                                {
                                    // Withdrawal Penalty
                                    if (customerList[selection].getCustStatus() == CustomerStatus.REGULAR)
                                    {
                                        Transaction tran = new Transaction(savingWithdrawal, TransactionType.WITHDRAW);
                                        saving.Withdraw(tran);

                                        Console.WriteLine("\n\tWithdrawal complete, account current balance: $" + saving.Balance);
                                    }
                                    else
                                    {
                                        //create a new transaction in Checking for the customer
                                        Transaction tran = new Transaction(savingWithdrawal, TransactionType.WITHDRAW);
                                        saving.Withdraw(tran);
                                      
                                        Console.WriteLine("\n\tWithdrawal complete, account current balance: $" + saving.Balance);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n\tWithdraw cancelled: " + TransactionResult.INSUFFICIENT_FUND);
                                }
                            }// end of Saving

                        } // End of Withdraw Option 2

                        ///////////////////////////////////////////////////////////////  

                        else if (activity == 3) // Transfer
                        {
                            Console.Write("\nSelect account (1 - Checking Account; 2 - Saving Account): ");
                            int accOption;
                            string enterAccount = Console.ReadLine();

                            if (!int.TryParse(enterAccount, out accOption) || int.TryParse(enterAccount, out accOption) && accOption < 1 || accOption > 2)
                            {
                                Console.WriteLine("\nInvalid Entry, try again!");
                                // Console.Read();
                                continue;
                            }

                            if (accOption == 1) // Checking to Saving
                            {
                                Console.Write("\nEnter amount: ");
                                double checkingTransferOut;
                                string input = Console.ReadLine();

                                if (!double.TryParse(input, out checkingTransferOut) || double.TryParse(input, out checkingTransferOut) && checkingTransferOut <= 0)
                                {
                                    Console.WriteLine("\nInvalid Entry, try again!");
                                    continue; // continue once we have number over 0
                                }

                                if (checkingTransferOut <= checking.Balance)
                                {
                                    // create transactions for both transfer out an in amounts
                                    Transaction tran1 = new Transaction(checkingTransferOut, TransactionType.TRANSFER_OUT);
                                    checking.Withdraw(tran1);

                                    Transaction tran2 = new Transaction(checkingTransferOut, TransactionType.TRANSFER_IN);
                                    saving.Deposit(tran2);

                                    Console.WriteLine("\n\tTransfer completed");
                                }
                                else
                                {
                                    Console.WriteLine("\n\tWithdraw cancelled: " + TransactionResult.INSUFFICIENT_FUND);
                                }

                            } // end of checking

                            else if (accOption == 2) // Saving to Checking
                            {
                                Console.Write("\nEnter amount: ");
                                double savingTransferOut;
                                string input = Console.ReadLine();

                                if (!double.TryParse(input, out savingTransferOut) || double.TryParse(input, out savingTransferOut) && savingTransferOut <= 0)
                                {
                                    Console.WriteLine("\nInvalid Entry, try again!");
                                    continue; // continue once we have number over 0
                                }

                                if (savingTransferOut <= saving.Balance)
                                {
                                    Transaction tran2 = new Transaction(savingTransferOut, TransactionType.TRANSFER_OUT);
                                    saving.Withdraw(tran2);

                                    Transaction tran1 = new Transaction(savingTransferOut, TransactionType.TRANSFER_IN);
                                    checking.Deposit(tran1);

                                    Console.WriteLine("\n\tTransfer completed");
                                }
                                else
                                {
                                    Console.WriteLine("\n\tWithdraw cancelled: " + TransactionResult.INSUFFICIENT_FUND);
                                }
                            } // end of saving

                        } // End of Transfer Option 3

                        ///////////////////////////////////////////////////////////////////

                        else if (activity == 4) // Balance Enquiry
                        {
                            Console.WriteLine("\nCurrent Balance:");
                            Console.WriteLine("\tAccount\t\t\t\tBalance");
                            Console.WriteLine("\t--------\t\t\t-------");
                            Console.WriteLine("\tChecking\t\t\t$" + checking.Balance);
                            Console.WriteLine("\tSaving\t\t\t\t$" + saving.Balance);

                        } // End of Balance Enquiry Option 4

                        ///////////////////////////////////////////////////////////////////

                        else if (activity == 5) // Account Activity Enquiry
                        {
                            // Checking Account Transaction History
                            Console.WriteLine("Checking Account");
                            Console.WriteLine("\tAmount\t\t\tDate\t\t\t\t\tActivity");
                            Console.WriteLine("\t------\t\t\t-----\t\t\t\t\t--------");

                            // display each transaction in the list
                            foreach (Transaction tran in checking.TransactionHistory)
                            {
                                Console.WriteLine("\t$" + tran.Amount + "\t\t\t" + tran.TransactionDate + "\t\t\t" + tran.Type);
                            }

                            // Saving Account Transaction History
                            Console.WriteLine("\nSaving Account");
                            Console.WriteLine("\tAmount\t\t\tDate\t\t\t\t\tActivity");
                            Console.WriteLine("\t------\t\t\t-----\t\t\t\t\t--------");

                            foreach (Transaction tran in saving.TransactionHistory)
                            {
                                Console.WriteLine("\t$" + tran.Amount + "\t\t\t" + tran.TransactionDate + "\t\t\t" + tran.Type);
                            }

                        } // End of Activity Enquiry Option 5

                        ///////////////////////////////////////////////////////////////////

                        else  // Exit program
                        {
                            Console.WriteLine("\nThank you for using our banking program! Goodbye.");
                            Console.ReadLine();
                            
                            return;
                        // Needed to exit outer loop as well so I used return. Found this method here (last response on page): 
                        // https://stackoverflow.com/questions/6719630/how-to-escape-a-while-loop-in-c-sharp
                        
                        }
                        
                    } // end of customer activities loop   
                    
                }//end of try
                catch
                {
                    Console.ReadLine(); // display error message to users
                }

            } // end of loop for customer list > 0 

        }// end of Main

    }// end of class
}
