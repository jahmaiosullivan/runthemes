﻿using RunThemes.Business.Configuration;
using StructureMap;

namespace WhiteLabel.Business
{
    public class ServiceContainer
    {
        private static IContainer _current;
        public static IContainer Current
        {
            get { return _current ?? (_current = GetWebContainer()); }
            set { _current = value; }
        }

        static IContainer GetWebContainer()
        {
            var container = new Container(x => x.AddRegistry<CoreRegistry>());
            return container;
        }
    }
}