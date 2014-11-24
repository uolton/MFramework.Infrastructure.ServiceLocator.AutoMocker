using System;
using MFramework.Infrastructure.ServiceLocator.Registrations;
using MFramework.Infrastructure.ServiceLocator.Registrations.Stores;
using MFramework.Infrastructure.ServiceLocator.RegistrationTemplates;
using MFramework.Infrastructure.ServiceLocator.RegistrationTemplates.Default;

namespace MFramework.Infrastructure.ServiceLocator.AutoMocker
{
    public class AutoMockRegistration : InstanceRegistration<object>
    {
        private readonly Type from;
        private readonly DefaultInstanceRegistrationTemplate defaultInstanceRegistrationTemplate = new DefaultInstanceRegistrationTemplate();
        private readonly DefaultRegistrationStore defaultRegistrationStore = new DefaultRegistrationStore();

        public AutoMockRegistration(Type from, object to)
        {
            this.from = from;
            this.implementation = to;
        }

        public override IRegistrationStore GetRegistrationStore()
        {
            return defaultRegistrationStore;
        }

        public override IRegistrationTemplate GetRegistrationTemplate()
        {
            return defaultInstanceRegistrationTemplate;
        }

        public override Type GetMappedFromType()
        {
            return from;
        }
    }
}
