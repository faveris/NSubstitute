using System;

namespace NSubstitute.Core
{
    public delegate object ProxyBuilder(Type proxyType, object[] constructorArguments);

    public interface IProxyFactory
    {
        object GenerateProxy(ICallRouter callRouter, Type typeToProxy, Type[] additionalInterfaces, object[] constructorArguments, ProxyBuilder builder);
    }
}