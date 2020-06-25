using NUnit.Framework;

namespace DelegateSimple
{
    public class LambdaService
    {
        public delegate bool TextIsValidDelegate(string text);

        public bool TryDelegate(TextIsValidDelegate predicate)
        {
            bool result = predicate("mon super text");
            return result;
        }
    }

    public class LambdaTest
    {
        [Test]
        public void InvalidTest()
        {
            var service = new LambdaService();
            bool res = service.TryDelegate((text) => text.Length != 14);
            Assert.IsFalse(res);
        }

        [Test]
        public void ValidTest()
        {
            var service = new LambdaService();
            bool res = service.TryDelegate(text => text.Length == 14);
            Assert.IsTrue(res);
        }
    }
}