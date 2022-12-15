using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    public class Validator
    {
        public static bool CheckUserLogin(string login)
        {
            Regex regexLogin = new Regex(@"^[A-Za-z\d]+$");
            if (!regexLogin.IsMatch(login) || login.Length < 3 || login.Length > 12)
            {
                return false;
            }
            
            return true;
        }

        public static bool CheckUserPassword(string password)
        {
            Regex regexPassword = new Regex(@"^[A-Za-z\d]+$");
            if (!regexPassword.IsMatch(password) || password.Length < 6 || password.Length > 16)
            {
                return false;
            }
            return true;
        }

        public static bool CheckUserEmail(string email)
        {
            Regex regexEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regexEmail.IsMatch(email) || email.Length < 5 || email.Length > 30)
            {
                return false;
            }
            return true;
        }

        public static bool CheckUserFName(string fName)
        {
            Regex regexFName = new Regex(@"^[А-Яа-я]+$");
            if (!regexFName.IsMatch(fName) || fName.Length < 2 || fName.Length > 30)
            {
                return false;
            }

            return true;
        }
        public static bool CheckUserSName(string sName)
        {
            Regex regexFName = new Regex(@"^[А-Яа-я]+$");
            if (!regexFName.IsMatch(sName) || sName.Length < 3 || sName.Length > 30)
            {
                return false;
            }

            return true;
        }

        public static bool CheckUserPhone(string phone)
        {
            Regex regexPhone = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$");
            if (!regexPhone.IsMatch(phone))
            {
                return false;
            }

            return true;
        }

        public static bool UpperCaseRussianLetters(string str)
        {
            Regex regexTitle = new Regex(@"^[А-Яа-я]");
            if (!regexTitle.IsMatch(str))
            {
                return false;
            }

            int upper = 0;
            foreach (char symbol in str.Where(char.IsUpper))
            {
                upper++;
            }
            if (upper > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public static bool CheckTitle(string title)
        {
            Regex regexTitle = new Regex(@"^[А-Яа-я]+$");
            if (!regexTitle.IsMatch(title))
            {
                return false;
            }

            return true;
        }

        public static bool CheckPublYear(int year)
        {
            Regex regexYear = new Regex(@"[0-9]");
            if (!regexYear.IsMatch(year.ToString()) || year.ToString().Length < 4)
            {
                return false;
            }

            return true;
        }

        public static bool CheckPrice(double price)
        {
            Regex regexMoney = new Regex(@"^[-+]?[0-9]*[.,]?[0-9]+(?:[eE][-+]?[0-9]+)?$");
            if (!regexMoney.IsMatch(price.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
