using System;
using Rhino.Mocks;

namespace MFramework.Infrastructure.ServiceLocator.AutoMocker.RhinoMocks
{
    public class RhinoMockAdapter : IMockAdapter
    {
        private MockRepository repository;

        public MockMode MockingMode { get; set; }

        public MockRepository Repository
        {
            get { return repository; }
        }
        public RhinoMockAdapter()
            : this(new MockRepository(), MockMode.RecordAndReplay)
        {
        }

        public RhinoMockAdapter(MockMode mockingMode)
            : this(new MockRepository(), mockingMode)
        {
        }

        public RhinoMockAdapter(MockRepository repository)
            : this(repository, MockMode.RecordAndReplay)
        {
        }

        public RhinoMockAdapter(MockRepository repository, MockMode mockingMode)
        {
            this.repository = repository;
            MockingMode = mockingMode;
        }

        #region IMockAdapter Members

        public object Mock(Type type, params object[] parameters)
        {
            var mock = repository.DynamicMock(type, parameters);

            if (MockingMode == MockMode.AAA)
                mock.Replay();
            return mock;
        }

        public object Stub(Type type, params object[] parameters)
        {
            var stub = repository.Stub(type, parameters);
            if (MockingMode == MockMode.AAA)
                stub.Replay();
            return stub;
        }

        #endregion
    }

    public enum MockMode
    {
        RecordAndReplay,
        AAA
    }
}
