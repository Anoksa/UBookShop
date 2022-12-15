using NUnit.Framework;
using UBookShop.Model;

namespace UBookShopTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("koks")]
        [TestCase("ado")]
        [TestCase("KOKS")]
        public void CheckUserLogin_TrueTest(string login)
        {
            bool value = Validator.CheckUserLogin(login);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("������")]
        [TestCase("��")]
        [TestCase("qwertyuiopasd")]
        public void CheckUserLogin_FalseTest(string login)
        {
            bool value = Validator.CheckUserLogin(login);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase("Qwerty")]
        [TestCase("qwerty")]
        [TestCase("qwerty12")]
        [TestCase("12qwerty")]
        public void CheckUserPassword_TrueTest(string password)
        {
            bool value = Validator.CheckUserPassword(password);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("������")]
        [TestCase("qwert")]
        [TestCase("qwertyuioasdfghjkl")]
        public void CheckUserPassword_FlaseTest(string password)
        {
            bool value = Validator.CheckUserPassword(password);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase("example@gmail.com")]
        [TestCase("Example@gmail.com")]
        [TestCase("longexample@mail.ru")]
        public void CheckUserEmail_TrueTest(string email)
        {
            bool value = Validator.CheckUserEmail(email);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("wrong@gmail")]
        [TestCase("wronggmail.com")]
        [TestCase("q")]
        [TestCase("!example@gmail.com")]
        public void CheckUserEmail_FalseTest(string email)
        {
            bool value = Validator.CheckUserEmail(email);
            Assert.IsFalse(value);
        }


        [Test]
        [TestCase("+375338442510")]
        [TestCase("375338902156")]
        [TestCase("80296442915")]
        public void CheckUserPhone_TrueTest(string phone)
        {
            bool value = Validator.CheckUserPhone(phone);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("3451278")]
        [TestCase("123434329529356934659252")]
        [TestCase("12")]
        [TestCase("������")]
        public void CheckUserPhone_FalseTest(string phone)
        {
            bool value = Validator.CheckUserPhone(phone);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase("������")]
        [TestCase("������")]
        [TestCase("����")]
        public void CheckUserFName_TrutTest(string fName)
        {
            bool value = Validator.CheckUserFName(fName);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("Oksana")]
        [TestCase("������12")]
        [TestCase("!����")]
        [TestCase("�")]
        [TestCase("��������������������������������")]
        public void CheckUserFName_FalseTest(string fName)
        {
            bool value = Validator.CheckUserFName(fName);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase("����������")]
        [TestCase("���������")]
        [TestCase("������")]
        public void CheckUserSName_TrueTest(string sName)
        {
            bool value = Validator.CheckUserSName(sName);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("Karpushevich")]
        [TestCase("���������!")]
        [TestCase("�")]
        [TestCase("��������������������������������")]
        public void CheckUserSName_FalseTest(string sName)
        {
            bool value = Validator.CheckUserSName(sName);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase("����� �����")]
        [TestCase("���������� ����")]
        [TestCase("������������� �����������")]
        [TestCase("�����������")]
        [TestCase("������")]
        public void CheckUpperCaseRussianLetters_True(string title)
        {
            bool value = Validator.UpperCaseRussianLetters(title);
            Assert.IsTrue(value);
        }

        [Test]
        [TestCase("����� �����")]
        [TestCase("���������� ����")]
        [TestCase("������������� �����������")]
        [TestCase("�����������")]
        [TestCase("Demian")]
        public void CheckUpperCaseRussianLetters_False(string title)
        {
            bool value = Validator.UpperCaseRussianLetters(title);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase(1234)]
        [TestCase(2020)]
        [TestCase(2014)]
        [TestCase(1999)]
        [TestCase(2022)]
        public void CheckPublYear_True(int year)
        {
            bool value = Validator.CheckPublYear(year);
            Assert.IsTrue(value);
        }
        
        [Test]
        [TestCase("1994")]
        [TestCase(3)]
        [TestCase(999)]
        [TestCase(19999)]
        [TestCase(234)]
        public void CheckPublYear_False(int year)
        {
            bool value = Validator.CheckPublYear(year);
            Assert.IsFalse(value);
        }

        [Test]
        [TestCase(13)]
        [TestCase(14.2)]
        [TestCase(1.1)]
        public void CheckPrice_True(double price)
        {
            bool value = Validator.CheckPrice(price);
            Assert.IsTrue(value);
        }
        
       
    }
}