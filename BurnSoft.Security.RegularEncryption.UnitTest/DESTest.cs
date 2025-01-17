﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSoft.Security.RegularEncryption.UnitTest
{
    [TestClass]
    public class DESTest
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
        /// The expected value encrypted
        /// </summary>
        private string _expectedValueEncrypted;
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
            _expectedValueEncrypted = "wmraZyDQKGsrThr454koDA==";
        }
        [TestMethod, TestCategory("Encrypt - DES")]
        public void DESEncrypt()
        {
            string value = DES.Do.Encrypt(_testText, "12345678");
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Equals(_expectedValueEncrypted));
        }

        [TestMethod, TestCategory("Decrypt - DES")]
        public void DESDecrypt()
        {
            string value = DES.Do.Decrypt(_expectedValueEncrypted, "12345678");
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Equals(_testText));
        }
    }
}
