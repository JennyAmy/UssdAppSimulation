using System;
using System.Linq;

namespace UssdAppSimulation
{
    class Program
    {
        static Random random = new Random();
        static int accountBal = random.Next(500, 1000000);

        static void Main(string[] args)
        {
            DisplayUSSDs();
            AskAndCheckUSSD();
            FirstMenu();


            Console.ReadLine();
        }


        static void DisplayUSSDs()
        {
            Console.WriteLine("Here are the available banks' ussd codes!");
            Console.WriteLine("");
            var listOfBanks = BankData.GetBankList();
            foreach (var bank in listOfBanks)
            {
                Console.WriteLine(bank.BankName + ": *" + bank.BankUSSDCode + "#");
            }
        }

        static void AskAndCheckUSSD()
        {
            Console.WriteLine("");
            Console.WriteLine("Please type in your bank's ussd code: ");
            int ussdValue = Convert.ToInt32(Console.ReadLine());

            // check if inserted ussd exists in the list of banks ussd
            var bank = BankData.GetBankList().Where(b => b.BankUSSDCode == ussdValue).FirstOrDefault();

            Console.WriteLine("");

            // check if the bank that was gotten based on the ussd that the user provided exists
            if (bank != null)
            {
                Console.WriteLine("Welcome to " + bank.BankName + "! Please select an option.");

            }
            else
            {
                Console.WriteLine("You have entered an invalid USSD code, please try again.");
                AskAndCheckUSSD();
            }
        }

        static void FirstMenu()
        {
            Console.WriteLine("1. Check your balance");
            Console.WriteLine("2. Transfer money");
            Console.WriteLine("3. Airtime purchase");
            Console.WriteLine("4. Transaction history");

            Console.WriteLine("");
            int menuValue = Convert.ToInt32(Console.ReadLine());

            if (menuValue == 1)
            {
                AccountBalance();
            }
            else if (menuValue == 2)
            {
                MakeTransfer();
            }
            else if (menuValue == 3)
            {
                PurchaseAirtime();
            }
            else if (menuValue == 4)
            {
                TransactionHistory();
            }
            else
            {
                Console.WriteLine("Invalid code!");
            }
        }



        static void AccountBalance()
        {
            Console.WriteLine("");
            CheckPin();
            Console.WriteLine("Your account balance is " + accountBal.ToString() + " naira.");
            AnotherTransaction();
        }


        static void MakeTransfer()
        {
            Console.WriteLine("");
            var accountNo = RequestAccountNoTOSend();
            //var customer = CustomerInformation.GetCustomer().Where(c => c.accountNumber.ToString() == accountNo).FirstOrDefault();

            Console.WriteLine("");
            Console.WriteLine("Enter amount: ");
            long amount = Convert.ToInt64(Console.ReadLine());

            if (amount > accountBal)
            {
                Console.WriteLine("INSUFFICIENT FUNDS!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Do you want to transfer " + amount.ToString() + " naira to " + accountNo.ToString() + "?");
                //Console.WriteLine("Do you want to transfer " + amount.ToString() + " naira to " + customer.customerName + "?");
                Console.WriteLine("1. YES");
                Console.WriteLine("2. NO");
                Console.WriteLine("");
                int result = Convert.ToInt32(Console.ReadLine());

                if (result == 1)
                {
                    CheckPin();
                    Console.WriteLine("Transaction Successful");
                    AnotherTransaction();
                }
                else if (result == 2)
                {
                    Console.WriteLine("Transaction Terminated");
                    AnotherTransaction();
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                }
            }
        }
        


        static void PurchaseAirtime()
        {
            Console.WriteLine("1. For Self");
            Console.WriteLine("2. For Others");
            int result = Convert.ToInt32(Console.ReadLine());
            if (result == 1)
            {
                Console.WriteLine("Enter amount: ");
                long airtimeAmount = Convert.ToInt64(Console.ReadLine());
                if (airtimeAmount > accountBal)
                {
                    Console.WriteLine("You have insufficient funds");
                }
                else
                {
                    Console.WriteLine("Do you want to purchase " + airtimeAmount.ToString() + " naira worth of airtime for yourself?");
                    Console.WriteLine("1. YES");
                    Console.WriteLine("2. NO");

                    Console.WriteLine("");
                    int reply = Convert.ToInt32(Console.ReadLine());

                    if (reply == 1)
                    {
                        Console.WriteLine("Transaction Successful");
                        AnotherTransaction();
                    }
                    else if (reply == 2)
                    {
                        Console.WriteLine("Transaction Terminated");
                    }
                    else
                    {
                        Console.WriteLine("INVALID CODE!");
                    }
                }
            }
            else if (result == 2)
            {
                Console.WriteLine("Enter amount: ");
                long amountAirtime = Convert.ToInt64(Console.ReadLine());
                if (amountAirtime > accountBal)
                {
                    Console.WriteLine("You have insufficient funds");
                }
                else
                {
                    var phoneNumber = RequestPhoneNoTOSend();
                    Console.WriteLine("Do you want to purchase " + amountAirtime.ToString() + " naira worth of airtime for " + phoneNumber.ToString() + "?");
                    Console.WriteLine("1. YES");
                    Console.WriteLine("2. NO");

                    Console.WriteLine("");
                    int reply = Convert.ToInt32(Console.ReadLine());

                    if (reply == 1)
                    {
                        CheckPin();
                        Console.WriteLine("Transaction Successful");
                        AnotherTransaction();
                    }
                    else
                    {
                        Console.WriteLine("Transaction Terminated");
                    }
                }
            }
            else
            {
                Console.WriteLine("INVALID CODE!");
            }
        }


        static void TransactionHistory()
        {
            CheckPin();
            Console.WriteLine("");
            Console.WriteLine("An SMS and Email detailing your transaction history would be sent to you shortly.");
            AnotherTransaction();
        }



        //The methods below are all the sub-methods used in some of the methods above
        static void CheckPin()
        {
            Console.WriteLine("Enter your 4-digit pin: ");
            var pin = Console.ReadLine();

            if (pin.Length != 4)
            {
                Console.WriteLine("");
                Console.WriteLine("You have entered a wrong pin");
                CheckPin();
            }
        }

        static string RequestAccountNoTOSend()
        {
            Console.WriteLine("Please enter the account number you want to transfer money to: ");
            Console.WriteLine("");
            var accountNumber = Console.ReadLine();
            if (accountNumber.Length != 10)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid 10-digit number: ");
                RequestAccountNoTOSend();
            }

            return accountNumber;
        }

        static string RequestPhoneNoTOSend()
        {
            Console.WriteLine("Enter the phone number you want to purchase airtime for: ");
            Console.WriteLine("");
            var phoneNo = Console.ReadLine();
            if (phoneNo.Length != 11)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid phone number");
                Console.WriteLine("");
                RequestPhoneNoTOSend();
            }

            return phoneNo;
        }

        static void AnotherTransaction()
        {
            Console.WriteLine("");
            Console.WriteLine("Do you wish to perform another transaction?");
            Console.WriteLine("1. YES");
            Console.WriteLine("2. NO");
            var reply = Convert.ToInt32(Console.ReadLine());
            if (reply == 1)
            {
                FirstMenu();
            }
            else
            {
                Console.WriteLine("SESSION ENDED!");
            }
        }


    }
}

