using Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
   public class DAL
    {
        [Test]
        public void t()
        {
            var db = new EmployeeContext();
        }
    }
}
