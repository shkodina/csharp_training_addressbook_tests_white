﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class TestBase
    {
        public ApplicationManager app;
        [SetUp]
        public void InitApp()
        {
            app = new ApplicationManager();
        }
        
        [TearDown]
        public void StopApp()
        {
            app.Stop();
        }
    }
}
