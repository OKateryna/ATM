using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asynchronousTransferMode
{
    public class Client
    {
        private string name;
        private string pin;
        private int balance;
        public Client(string Name, string Pin)
        {
            this.name = Name;
            this.pin = Pin;
            balance = 1000;
        }
        public string Name
            {
            set{ name = value; }
            }
        public string Pin
        {
            set { pin = value; }
        }
        public int Balance
        {
            get { return balance; }
        }


        public void Put (int sum)
        {
            balance = balance + sum;
        }
        public void Withdraw(int sum)
        {
            balance = balance - sum;
        }
        //public void ShowBalance()
        //{
        //    Console.WriteLine(balance);
        //}
    }
}
