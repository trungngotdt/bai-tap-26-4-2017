// <copyright file="TransTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf_4_26_2017;

namespace Wpf_4_26_2017.Tests
{
    /// <summary>This class contains parameterized unit tests for Trans</summary>
    [PexClass(typeof(Trans))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class TransTest
    {
        /// <summary>Test stub for _chuyen(String)</summary>
        [PexMethod]
        internal string _chuyenTest([PexAssumeUnderTest]Trans target, string input)
        {
            string result = target._chuyen(input);
            return result;
            // TODO: add assertions to method TransTest._chuyenTest(Trans, String)
        }
    }
}
