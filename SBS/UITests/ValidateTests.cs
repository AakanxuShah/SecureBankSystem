using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Tests
{
    [TestClass()]
    public class ValidateTests
    {
        [TestMethod()]
        public void generalValidateTest()
        {
            // Check Alphabetic
            Assert.IsTrue(Validate.generalValidate("AaBbCcDdEeFfGg", true, false));

            Assert.IsFalse(Validate.generalValidate("AaBbCc7DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc_DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc%DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc$DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc&DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc<DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc>DdEeFfGg", true, false));

            // Check Numeric
            Assert.IsTrue(Validate.generalValidate("1234567890", false, true));

            Assert.IsFalse(Validate.generalValidate("12345a67890", false, true));
            Assert.IsFalse(Validate.generalValidate("12345 67890", false, true));
            Assert.IsFalse(Validate.generalValidate("12345-67890", false, true));
            Assert.IsFalse(Validate.generalValidate("12345_67890", false, true));

            // Check Special
            Assert.IsTrue(Validate.generalValidate("!@#$%^&*()<>", false, false, "!@#$%^&*()<>"));
            Assert.IsTrue(Validate.generalValidate("!@#$%^&*()<>", false, false, "!@#$%^&*()<>"));

            Assert.IsFalse(Validate.generalValidate("!@#$2^&*()<>", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate("A", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate(" ", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate("-", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate("!@#$ ^&*()<>", false, false, "!@#$%^&*()<>"));
        }

        [TestMethod()]
        public void isUserNameValidTest()
        {
            Assert.IsTrue(Validate.isUserNameValid("Jon"));
            Assert.IsTrue(Validate.isUserNameValid("Marie-Ann"));
            Assert.IsTrue(Validate.isUserNameValid("Johnson Ash"));
            Assert.IsFalse(Validate.isUserNameValid("ajslkdjf<>"));
            Assert.IsFalse(Validate.isUserNameValid("Fred, Wilma"));
        }

        [TestMethod()]
        public void isZipCodeValidTest()
        {
            Assert.IsTrue(Validate.isZipCodeValid("01234-5678"));
            Assert.IsTrue(Validate.isZipCodeValid("98765"));
            Assert.IsFalse(Validate.isZipCodeValid("98765 1234"));
            Assert.IsFalse(Validate.isZipCodeValid("98a65 1234"));
            Assert.IsFalse(Validate.isZipCodeValid("98765.1234"));
            Assert.IsFalse(Validate.isZipCodeValid("98%65-1234"));
            Assert.IsFalse(Validate.isZipCodeValid("98765-12340"));
        }

        [TestMethod()]
        public void isCityValidTest()
        {
            Assert.IsTrue(Validate.isCityValid("Phoenix"));
            Assert.IsTrue(Validate.isCityValid("New York"));
            Assert.IsTrue(Validate.isCityValid("Raliegh-Duram"));
            Assert.IsFalse(Validate.isCityValid("Raliegh%Duram"));
            Assert.IsFalse(Validate.isCityValid("Raliegh%Duram"));
        }

        [TestMethod()]
        public void isStateValidTest()
        {
            Assert.IsTrue(Validate.isStateValid("AZ"));
            Assert.IsTrue(Validate.isStateValid("NY"));
            Assert.IsTrue(Validate.isStateValid("CA"));
            Assert.IsFalse(Validate.isStateValid("ILL"));
            Assert.IsFalse(Validate.isStateValid("12"));
            Assert.IsFalse(Validate.isStateValid("V-"));
            Assert.IsFalse(Validate.isStateValid("B*"));
        }

        [TestMethod()]
        public void isPhoneNumberValidTest()
        {
            Assert.IsTrue(Validate.isPhoneNumberValid("+01 (480) 415-0904"));
            Assert.IsTrue(Validate.isPhoneNumberValid("480-415-0904"));
            Assert.IsTrue(Validate.isPhoneNumberValid("(480) 415-0904"));
            Assert.IsFalse(Validate.isPhoneNumberValid("+01 (480) 415-0904-2341"));
            Assert.IsFalse(Validate.isPhoneNumberValid("(480)415-0904 x234"));
            Assert.IsFalse(Validate.isPhoneNumberValid("480%415%0904"));
        }

        [TestMethod()]
        public void isEmailAddressValidTest()
        {
            Assert.IsTrue(Validate.isEmailAddressValid("jon.lammers@gd-ms.com"));
            Assert.IsTrue(Validate.isEmailAddressValid("jon_lammers@gdc4s.com"));
            Assert.IsFalse(Validate.isEmailAddressValid("jon lammers@gd-ms.com"));
            Assert.IsFalse(Validate.isEmailAddressValid("jon%lammers@gd-ms.com"));
            Assert.IsFalse(Validate.isEmailAddressValid("jon^lammers@gd-ms.com"));
            Assert.IsFalse(Validate.isEmailAddressValid("jon$lammers@gd-ms.com"));
            Assert.IsFalse(Validate.isEmailAddressValid("jon#lammers@gd-ms.com"));
        }

        [TestMethod()]
        public void isUserIDValidTest()
        {
            Assert.IsTrue(Validate.isUserIDValid("12345"));
            Assert.IsTrue(Validate.isUserIDValid("67890"));
            Assert.IsFalse(Validate.isUserIDValid("Fred"));
            Assert.IsFalse(Validate.isUserIDValid("12345C"));
            Assert.IsFalse(Validate.isUserIDValid("123-453"));
            Assert.IsFalse(Validate.isUserIDValid("123_453"));
        }

        [TestMethod()]
        public void isBranchValidTest()
        {
            Assert.IsTrue(Validate.isBranchValid("12345"));
            Assert.IsTrue(Validate.isBranchValid("67890"));
            Assert.IsFalse(Validate.isBranchValid("Fred"));
            Assert.IsFalse(Validate.isBranchValid("12345C"));
            Assert.IsFalse(Validate.isBranchValid("123-453"));
            Assert.IsFalse(Validate.isBranchValid("123_453"));
        }

        [TestMethod()]
        public void isSecurityQuestionValidTest()
        {
            Assert.IsTrue(Validate.isSecurityQuestionValid("Dog's, name?"));
            Assert.IsTrue(Validate.isSecurityQuestionValid("Childrens first.last name?"));
            Assert.IsTrue(Validate.isSecurityQuestionValid("Comma, dash- ?"));
            Assert.IsFalse(Validate.isSecurityQuestionValid("*"));
            Assert.IsFalse(Validate.isSecurityQuestionValid("x' AND 1=(SELECT COUNT(*) FROM tabname); --"));
        }

        [TestMethod()]
        public void isSecurityAnswerValidTest()
        {
            Assert.IsTrue(Validate.isSecurityQuestionValid("Maxwell-Scratchington,III"));
            Assert.IsTrue(Validate.isSecurityQuestionValid("Jessi.Lammers"));
            Assert.IsTrue(Validate.isSecurityQuestionValid("Miranda'Boo"));
            Assert.IsFalse(Validate.isSecurityQuestionValid("*"));
            Assert.IsFalse(Validate.isSecurityQuestionValid("x' AND 1=(SELECT COUNT(*) FROM tabname); --"));
        }

        [TestMethod()]
        public void isDescriptionValidTest()
        {
            Assert.IsTrue(Validate.isSecurityQuestionValid("Dog's, name?"));
            Assert.IsTrue(Validate.isSecurityQuestionValid("Childrens first.last name?"));
            Assert.IsTrue(Validate.isSecurityQuestionValid("Comma, dash- ?"));
            Assert.IsFalse(Validate.isSecurityQuestionValid("*"));
            Assert.IsFalse(Validate.isSecurityQuestionValid("x' AND 1=(SELECT COUNT(*) FROM tabname); --"));
        }

        [TestMethod()]
        public void isAccountNumberValidTest()
        {
            Assert.IsTrue(Validate.isAccountNumberValid("12345"));
            Assert.IsTrue(Validate.isAccountNumberValid("67890"));
            Assert.IsFalse(Validate.isAccountNumberValid("Fred"));
            Assert.IsFalse(Validate.isAccountNumberValid("12345C"));
            Assert.IsFalse(Validate.isAccountNumberValid("123-453"));
            Assert.IsFalse(Validate.isAccountNumberValid("123_453"));
        }

        [TestMethod()]
        public void isAmountValidTest()
        {
            Assert.IsTrue(Validate.isAmountValid("123"));
            Assert.IsTrue(Validate.isAmountValid("678.90"));
            Assert.IsTrue(Validate.isAmountValid("0.90"));
            Assert.IsTrue(Validate.isAmountValid(".90"));
            Assert.IsTrue(Validate.isAmountValid("9999999.99"));
            Assert.IsFalse(Validate.isAmountValid("10000000.00"));
            Assert.IsFalse(Validate.isAmountValid("12345C"));
            Assert.IsFalse(Validate.isAmountValid("123-453"));
            Assert.IsFalse(Validate.isAmountValid("123_453"));
        }

        [TestMethod()]
        public void isPaswordValidTest()
        {
            Assert.IsTrue(Validate.isPasswordValid("Ab-45678"));
            Assert.IsTrue(Validate.isPasswordValid("12345-xX"));
            Assert.IsTrue(Validate.isPasswordValid("!@#$_a8A"));
            Assert.IsFalse(Validate.isPasswordValid("!@#$_-8A"));
            Assert.IsFalse(Validate.isPasswordValid("1234Abc%"));
            Assert.IsFalse(Validate.isPasswordValid("12345678"));
            Assert.IsFalse(Validate.isPasswordValid("AbcdEfG1"));
            Assert.IsFalse(Validate.isPasswordValid("!@#$!@#$"));
            Assert.IsFalse(Validate.isPasswordValid("Ab123$#"));
            Assert.IsFalse(Validate.isPasswordValid("Ab1$"));
        }
    }
}