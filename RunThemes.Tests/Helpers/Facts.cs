using System;
using Moq;
using StructureMap.AutoMocking;

namespace RunThemes.Tests.Helpers
{
    public class Facts<TClassUnderTest> where TClassUnderTest : class
    {
        protected RhinoAutoMocker<TClassUnderTest> AutoMocker { get; private set; }

        public TClassUnderTest ClassUnderTest
        {
            get
            {
                return AutoMocker.ClassUnderTest;
            }
        }

        public Facts()
        {
            AutoMocker = new RhinoAutoMocker<TClassUnderTest>(MockMode.AAA);
        }

        public Mock<T> Mock<T>(params Object[] args) where T : class
        {
            var autoMock = AutoMocker.Get<T>();
            return Moq.Mock.Get(autoMock);
        }
        
        public TDependency Get<TDependency>() where TDependency : class
        {
            return AutoMocker.Get<TDependency>();
        }
    }
}
