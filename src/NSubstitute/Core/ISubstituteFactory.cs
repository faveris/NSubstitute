using System;

namespace NSubstitute.Core
{
    public interface ISubstituteFactory
    {
        object Create(Type[] typesToProxy, object[] constructorArguments, ProxyBuilder builder);
        object CreatePartial(Type[] typesToProxy, object[] constructorArguments); 
        ICallRouter GetCallRouterCreatedFor(object substitute);
    }
}