using System;

namespace MFramework.Infrastructure.ServiceLocator.AutoMocker
{
    public interface IMockAdapter
    {
        object Mock(Type type, params object[] parameters);
        object Stub(Type type, params object[] parameters);
    }
}
