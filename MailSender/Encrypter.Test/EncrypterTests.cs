using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encrypter.Test
{
    [TestClass]
    public class EncrypterTests
    {
        [TestMethod]
        public void Encrypt_abcd_bcde()
        {
            var input_str = "abcd";
            var key = 1;
            var expected_result = "bcde";

            var actural_result = Encrypter.Crypter.Encrypt(input_str, key);

            Assert.AreEqual(expected_result, actural_result);

        }

        [TestMethod]
        public void Decrypt_bcde_abcd()
        {
            var input_str = "bcde";
            var key = 1;
            var expected_result = "abcd";

            var actural_result = Encrypter.Crypter.Decrypt(input_str, key);

            Assert.AreEqual(expected_result, actural_result);
        }

        [TestMethod]
        public void Encrypt_EmptyString()
        {
            var input = "";
            var key = 1;
            var expected = "";

            var actual = Encrypter.Crypter.Encrypt(input, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decrypt_EmptyString()
        {
            var input = "";
            var key = 1;
            var expected = "";

            var actual = Encrypter.Crypter.Decrypt(input, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Encrypt_NullRef()
        {
            string input = null;
            var key = 1;

            var actual = Encrypter.Crypter.Encrypt(input, key);

            Assert.IsNull(actual);
        }
    }
}
