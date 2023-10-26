using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz__21._10._23
{
    // 8.1
    enum BankType
    {
        Сберегательный,
        Текущий
    }
    internal class BankAccount
    {
        private uint accountID;
        private decimal accountBalance;
        private BankType accountBankType;

        public BankAccount(uint accountID, decimal accountBalance, BankType accountBankType)
        {
            this.accountID = accountID;
            this.accountBalance = accountBalance;
            this.accountBankType = accountBankType;
        }
        public uint GetAccountID()
        {
            return accountID;
        }
        public decimal GetAccountBalance()
        {
            return accountBalance;
        }
        public BankType GetAccountBankType()
        {
            return accountBankType;
        }
        public void TransferMoney(BankAccount otherAccount, decimal amount)
        {
            if (amount > 0)
            {
                if (accountBalance < amount)
                {
                    Console.WriteLine("Недостаточно средств.");
                    return;
                }
                else
                {
                    accountBalance -= amount;
                    otherAccount.accountBalance += amount;
                }
            }
            else
            {
                Console.WriteLine("Невозможно снять со счета отрицательное число");
                return;
            }

            Console.WriteLine($"{amount} transferred from account {accountID} to account {otherAccount.accountID}.");
        }
    }
}
