using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace asynchronousTransferMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Begin();
        }
        public static void Begin()
        {
            Console.WriteLine("You are in main menu!" +
                "\nIf you have already registered, please enter '1'," +
                "\nif you want to register - enter '2'." +
                "\nTo exit - enter '3'.");
            string step = Console.ReadLine();
            switch(step)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Registration();
                    break;
                case "3":
                    break;
                default:
                    Message();
                    Begin();
                    break;
            }

        }

            public static void Registration()
        {
            bool state = false;
            while (state != true)
            {
            Console.WriteLine("For creating the card, please, enter the number of your card:");
            string numberOfCard = Console.ReadLine();
            EnterPin();
            string pinCode = Console.ReadLine();
            Console.WriteLine("Enter your pin-code again:");
            string pinCode2 = Console.ReadLine();
                if (pinCode == pinCode2)
                {
                    state = true;
                    Console.WriteLine("Congratulations! You've registered!");
                    using (StreamWriter writer = new StreamWriter(@"E:\Programming\C#\my\asynchronousTransferMode\pins.txt", true))
                    {
                        writer.WriteLine(numberOfCard + " - " + pinCode);
                    }
                    Client client = new Client(numberOfCard, pinCode);
                    Actions(client);
                }
            }
            
        }
        public static void Login()
        {
            Console.WriteLine("Please, enter number of your card:");
            string numberOfCard = Console.ReadLine();
            EnterPin();
            string pinCode = Console.ReadLine();
            string line2 = numberOfCard + " - " + pinCode;

            string[] lines = File.ReadAllLines(@"E:\Programming\C#\my\asynchronousTransferMode\pins.txt");
            bool state = true;
            foreach (string line in lines)
            {
                if (line == line2)
                {
                    state = true;
                    Console.WriteLine("You are in our system!");
                    Client client = new Client(numberOfCard, pinCode);
                    Actions(client);
                    break;
                }
                else
                {
                    state = false;
                }
            }
            if (state == false)
            {
                Console.WriteLine("Your PIN is not correct. " +
                    "\nTo try again - enter '1'" +
                    "\nTo turn back to main meny - enter '2'");

                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Begin();
                        break;
                    default:
                        Message();
                        break;
                }
            }
        }

        public static void Exit(Client client)
        {
            Console.WriteLine("If you want to exit please enter '1', to continue actions with ATM - '2'.");
            string step = Console.ReadLine();
            switch (step)
            {
                case "1":
                    break;
                case "2":
                    Actions(client);
                    break;
                default:
                    Message();
                    Exit(client);
                    break;
            }
        }

        public static void Actions(Client client)
        {
            Console.WriteLine("To put money enter 'put'," +
                "\nto withdraw - 'withdraw'." +
                "\nTo check the balance please enter 'chek'.");
            string action = Console.ReadLine();

            try
            {
                switch (action)
                {
                    case "put":
                       client.Put(EnterMoney());
                       ShowBalance(client);
                        break;
                    case "withdraw":
                        client.Withdraw(EnterMoney());
                        ShowBalance(client);
                        break;
                    case "chek":
                        ShowBalance(client);
                        break;
                }
                Exit(client);
            }
            catch
            {
                Message();
                Actions(client);
            }
            
        }

        public static void Message()
        {
            Console.WriteLine("You've entered wrong symbols!");
        }

        public static void EnterPin()
        {
            Console.WriteLine("Enter your pin-code:");
        }

        public static int EnterMoney()
        {
            Console.WriteLine("Please enter the amount of money:");
            int sum = Convert.ToInt32(Console.ReadLine());
            return sum;
        }

        public static void ShowBalance(Client client)
        {
            Console.WriteLine("Yor balance is: {0}", client.Balance);
        }
    }
    
}
