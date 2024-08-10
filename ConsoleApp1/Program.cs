using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IAccount
    {
         void PrintDetails();
    }

    public class CurrentAccount : IAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("details of currentaccount");
        }
    }

    public class SavingAccount : IAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("details of savingaccount");
        }
    }


    public class Account
    {
        private IAccount account;
        public Account(IAccount account)
        {
            this.account = account;
             
        }

        public void printAccounts()
        {
            account.PrintDetails();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccount sa = new SavingAccount();
            Account a = new Account(sa);
            a.printAccounts();
            Console.ReadKey();
        }
    }
}
