using System;
using System.Reflection;
using NSubstitute.Core;

namespace NSubstitute.Proxies
{
    public class ProxyFactory : IProxyFactory
    {
        private readonly IProxyFactory _delegateFactory;
        private readonly IProxyFactory _dynamicProxyFactory;

        public ProxyFactory(IProxyFactory delegateFactory, IProxyFactory dynamicProxyFactory)
        {
            _delegateFactory = delegateFactory;
            _dynamicProxyFactory = dynamicProxyFactory;
        }

        public object GenerateProxy(ICallRouter callRouter, Type typeToProxy, Type[] additionalInterfaces, object[] constructorArguments, ProxyBuilder builder)
        {
            return SelectFactory(typeToProxy).GenerateProxy(callRouter, typeToProxy, additionalInterfaces, constructorArguments, builder);
        }

        private IProxyFactory SelectFactory(Type typeToProxy)
        {
            var isDelegate = typeToProxy.GetTypeInfo().IsSubclassOf(typeof(Delegate));
            return isDelegate ? _delegateFactory : _dynamicProxyFactory;
        }
    }
}