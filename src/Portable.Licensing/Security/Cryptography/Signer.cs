using System;

namespace Portable.Licensing.Security.Cryptography
{
    public abstract class Signer
    {
        private static Func<ISigner> _createInstance = CreateInstance;
        public static Func<ISigner> CreateSignerFactory
        {
            get => _createInstance;
            set => _createInstance = value;
        }

        public static ISigner Create()
        {
            return _createInstance.Invoke();
        }

        private static ISigner CreateInstance()
        {
#if NET452 || NETSTANDARD2_0
                return new BouncySigner();
#else
            return new NativeSigner();
#endif
        }
    }
}
