using Microsoft.VisualStudio.TestTools.UnitTesting;
using LootManagerApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootManagerApi.Utils.Tests
{
    [TestClass()]
    public class UtilsEmailTests
    {
        /// <summary>
        /// Test empty string.
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest01()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute(""));
        }

        /// <summary>
        /// Test email is white space
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest02()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("   "));
        }

        /// <summary>
        /// Test email = "oneword"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest03()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("oneword"));
        }

        /// <summary>
        /// Test email = "@"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest04()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("@"));
        }

        /// <summary>
        /// Test email = "name@"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest05()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("name@"));
        }

        /// <summary>
        /// Test email = "@domaine"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest06()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("@domaine"));
        }

        /// <summary>
        /// Test email = "name@domaine"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest07()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("name@domaine."));
        }

        /// <summary>
        /// Test email = "@domaine.com"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest08()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("@domaine.com"));
        }

        /// <summary>
        /// Test email = "@.com"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest09()
        {
            Assert.IsFalse(UtilsEmail.IsValidateEmailAddressAttribute("@.com"));
        }

        /// <summary>
        /// Test email = "name@domaine.com"
        /// </summary>
        [TestMethod()]
        public void IsValidateEmailAddressAttributeTest10()
        {
            Assert.IsTrue(UtilsEmail.IsValidateEmailAddressAttribute("name@domaine.com"));
        }
    }
}