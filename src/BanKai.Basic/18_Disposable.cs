﻿using System;
using System.Text;
using BanKai.Basic.Common;
using Xunit;

namespace BanKai.Basic
{
    public class Disposable
    {
        [Fact]
        public void should_call_dispose_anyway_using_try_finally()
        {
            var tracer = new StringBuilder();
            DisposableWithTracingDemoClass demoDisposable = null;

            try
            {
                demoDisposable = new DisposableWithTracingDemoClass(tracer);
            }
            finally
            {
                if (demoDisposable != null)
                {
                    demoDisposable.Dispose();
                }
            }

            // change variable value to fix test.
            string expectedTracingMessage = "constructor called." + Environment.NewLine + "dispose called."+Environment.NewLine;

            Assert.Equal(expectedTracingMessage, tracer.ToString());
        }

        [Fact]
        public void should_use_using_statement_for_simplicity()
        {
            
            var tracer = new StringBuilder();

            using (var demoDisposable = new DisposableWithTracingDemoClass(tracer))
            {
                // blah, blah, ...
            }

            // change the variable value to fix the test.
            string expectedTracingMessage = "constructor called." + Environment.NewLine + "dispose called."+Environment.NewLine;

            Assert.Equal(expectedTracingMessage, tracer.ToString());
        }
    }
}