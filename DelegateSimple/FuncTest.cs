using System;
using NUnit.Framework;

namespace DelegateSimple
{
    public class FuncService
    {
        public void ApplyAction(Action<string> predicate)
        {
            predicate("mon super text");
        }

        // delegate bool TextIsValidDelegate(string text);
        public bool TryFunc(Func<string, bool> predicate)
        {
            bool result = predicate("mon super text");
            return result;
        }
    }

    public class FuncTest
    {
        [Test]
        public void ActionTest()
        {
            string value = default;
            var service = new FuncService();
            service.ApplyAction(text =>
            {
                value = text;
            });

            Assert.AreEqual("mon super text", value);
        }

        [Test]
        public void InvalidTest()
        {
            var service = new FuncService();
            bool res = service.TryFunc((text) => text.Length != 14);
            Assert.IsFalse(res);
        }

        [Test]
        public void ValidTest()
        {
            var service = new FuncService();
            bool res = service.TryFunc(text => text.Length == 14);
            Assert.IsTrue(res);
        }
    }
}