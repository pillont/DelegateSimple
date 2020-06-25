using NUnit.Framework;

namespace DelegateSimple
{
    public class DelegateService
    {
        public delegate bool TextIsValidDelegate(string text);

        public bool TryDelegate(TextIsValidDelegate predicate)
        {
            bool result = predicate("mon super text");
            return result;
        }
    }

    public class DelegateTest
    {
        [Test]
        public void InvalidTest()
        {
            var service = new DelegateService();
            bool res = service.TryDelegate(InvalidValidFunc);
            Assert.IsFalse(res);
        }

        [Test]
        public void ValidTest()
        {
            var service = new DelegateService();
            bool res = service.TryDelegate(ValidFunc);
            Assert.IsTrue(res);
        }

        private bool InvalidValidFunc(string text)
        {
            return text.Length != 14;
        }

        private bool ValidFunc(string text)
        {
            return text.Length == 14;
        }
    }
}