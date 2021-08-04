using System;
using System.Collections.Generic;
using System.Text;

namespace UssdAppSimulation
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int BankUSSDCode { get; set; }
    }

    public class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int accountNumber { get; set; }

    }
   
    public static class BankData
    {
        public static List<Bank> GetBankList()
        {
            var bank1 = new Bank() { BankId = 1, BankName = "Access", BankUSSDCode = 901 };
            var bank2 = new Bank() { BankId = 2, BankName = "UBA", BankUSSDCode = 919 };
            var bank3 = new Bank() { BankId = 3, BankName = "FCMB", BankUSSDCode = 329 };
            var bank4 = new Bank() { BankId = 4, BankName = "GTBank", BankUSSDCode = 737 };
            var bank5 = new Bank() { BankId = 5, BankName = "Zenith", BankUSSDCode = 966 };
            var bank6 = new Bank() { BankId = 6, BankName = "EcoBank", BankUSSDCode = 326 };
            var bank7 = new Bank() { BankId = 7, BankName = "First Bank", BankUSSDCode = 894 };
            var bank8 = new Bank() { BankId = 8, BankName = "Stanbic IBTC", BankUSSDCode = 989 };
            var bank9 = new Bank() { BankId = 9, BankName = "Diamond Bank", BankUSSDCode = 426 };
            var bank10 = new Bank() { BankId = 10, BankName = "Fidelity Bank", BankUSSDCode = 770 };
            var bank11 = new Bank() { BankId = 11, BankName = "Sterling Bank", BankUSSDCode = 822 };
            var bank12 = new Bank() { BankId = 12, BankName = "Unity Bank", BankUSSDCode = 7799 };



            var listOfBanks = new List<Bank>();
            listOfBanks.Add(bank1);
            listOfBanks.Add(bank2);
            listOfBanks.Add(bank3);
            listOfBanks.Add(bank4);
            listOfBanks.Add(bank5);
            listOfBanks.Add(bank6);
            listOfBanks.Add(bank7);
            listOfBanks.Add(bank8);
            listOfBanks.Add(bank9);
            listOfBanks.Add(bank10);
            listOfBanks.Add(bank11);
            listOfBanks.Add(bank12);

            //var listOfBanks = new List<Bank>();
            //foreach (var banks in listOfBanks)
            //{
            //    listOfBanks.Add(banks);
            //}

            return listOfBanks;
        }

    }


    public static class CustomerInformation
    {
        public static List<Customer> GetCustomer()
        {
            var customer1 = new Customer() { customerId = 1, customerName = "Jennifer Olise", accountNumber = 1234567890 };
            var customer2 = new Customer() { customerId = 2, customerName = "Amaka Steve", accountNumber = 1234567891 };
            var customer3 = new Customer() { customerId = 3, customerName = "Jonathan Kay", accountNumber = 1234567892 };


            var customerList = new List<Customer>();
            customerList.Add(customer1);
            customerList.Add(customer2);
            customerList.Add(customer3);


            return customerList;
        }
    }
}
