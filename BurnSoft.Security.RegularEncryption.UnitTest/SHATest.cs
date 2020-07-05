using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSoft.Security.RegularEncryption.UnitTest
{
    [TestClass]
    public class SHATest
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }
        /// <summary>
        /// The test text
        /// </summary>
        private string _testText;
        /// <summary>
        /// The test text URL
        /// </summary>
        private string _testTextUrl;
        /// <summary>
        /// The test text session identifier
        /// </summary>
        private string _testTextSessionId;
        /// <summary>
        /// The test text verify m d5
        /// </summary>
        private string _testTextVerifyMd5;
        /// <summary>
        /// The test text verifymd52
        /// </summary>
        private string _testTextVerifymd52;
        /// <summary>
        /// The test text verify sha
        /// </summary>
        private string _testTextVerifySha;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _testText = "hashThis";
            _testTextUrl = "http://www.burnsoft.net/test.aspx";
            _testTextSessionId = "428095ur3948htirhgkerhg04t34t";
            _testTextVerifyMd5 = "51-CA-F8-84-41-C7-7A-C1-49-11-A3-D1-03-3A-C1-FE";
            _testTextVerifymd52 = "826a37cd6191450b00488f8d1ee34127";
            _testTextVerifySha = "aGFzaFRoaXM=";

        }
        /// <summary>
        /// Defines the test method EncryptShaTest.
        /// </summary>
        [TestMethod, TestCategory("Encrypt - SHA")]
        public void EncryptShaTest()
        {
            string value = SHA.One.Encrypt(_testText);
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Equals(_testTextVerifySha));
        }
        /// <summary>
        /// Defines the test method EncryptUrlTest.
        /// </summary>
        [TestMethod, TestCategory("Encrypt - SHA")]
        public void EncryptUrlTest()
        {
            string value = SHA.One.EncryptURL(_testTextUrl, _testTextSessionId);
            TestContext.WriteLine(value);
            string value2 = SHA.One.DecryptURL(value);
            TestContext.WriteLine(value2);
            Assert.IsTrue(value2.Equals(_testTextUrl));
        }
        /// <summary>
        /// Defines the test method DecryptShaTest.
        /// </summary>
        [TestMethod, TestCategory("Decrypt - SHA")]
        public void DecryptShaTest()
        {
            string value = SHA.One.Decrypt(_testTextVerifySha);
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Equals(_testText));
        }
        /// <summary>
        /// Defines the test method DecryptUrlTest.
        /// </summary>
        [TestMethod, TestCategory("Decrypt - SHA")]
        public void DecryptUrlTest()
        {
            string value = SHA.One.DecryptURL(SHA.One.EncryptURL(_testTextUrl, _testTextSessionId));
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Equals(_testTextUrl));
        }
    }
}
