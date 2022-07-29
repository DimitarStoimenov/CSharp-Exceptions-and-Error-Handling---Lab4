using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, double> acounts = new Dictionary<int, double>();

            string[] input = Console.ReadLine().Split(",");

            for (int i = 0; i < input.Length; i++)
            {
                string[] acountInfo = input[i].Split("-");
                int accountNumber = int.Parse(acountInfo[0]);
                double accountBallance = double.Parse(acountInfo[1]);

                if (!acounts.ContainsKey(accountNumber))
                {
                    acounts.Add(accountNumber, accountBallance);
                }
            }


            string command = Console.ReadLine();
            
            while (command != "End")
            {
                string[] commandInfo = command.Split();
                string commandType = commandInfo[0];
                int contoNumber = int.Parse(commandInfo[1]);
                double contoMoney  = double.Parse(commandInfo[2]);

                try
                {
                    if (commandType == "Deposit")
                    {
                        if (!acounts.ContainsKey(contoNumber))
                        {
                            IsAcountValid();
                        }
                        acounts[contoNumber] += contoMoney;
                        Console.WriteLine($"Account {contoNumber} has new balance: {acounts[contoNumber]:F2}");
                    }
                    else if (commandType == "Withdraw")
                    {
                        if (!acounts.ContainsKey(contoNumber))
                        {
                            IsAcountValid();
                        }
                        if (acounts[contoNumber] < contoMoney )
                        {
                            IsInsufficientBalance();
                        }
                        acounts[contoNumber] -= contoMoney; Console.WriteLine($"Account {contoNumber} has new balance: {acounts[contoNumber]:F2}");
                    }
                    else
                    {
                        IsCommandValid();
                    }

                }
                catch (InvalidCommand ic)
                {
                    Console.WriteLine(ic.Message);
                   
                }

                catch(InvalidAcount ia)
                {
                    Console.WriteLine(ia.Message);
                }
                catch(InsufficientBalance ib)
                {
                    Console.WriteLine(ib.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                command = Console.ReadLine();
            }
            
        }
        public static void IsCommandValid()
        {
            throw new InvalidCommand("Invalid command!");
        }
        public static void IsAcountValid()
        {
            throw new InvalidAcount("Invalid account!");
        }
        public static void IsInsufficientBalance()
        {
            throw new InsufficientBalance("Insufficient balance!");
        }

    }
   
    public class InvalidCommand : Exception
    {
        public InvalidCommand(string message)
            : base(message)
        {

        }
    }
    public class InvalidAcount : Exception
    {
        public InvalidAcount(string message)
            : base(message)
        {

        }
    }
    public class InsufficientBalance : Exception
    {
        public InsufficientBalance(string message)
            : base(message)
        {

        }
    }
}
