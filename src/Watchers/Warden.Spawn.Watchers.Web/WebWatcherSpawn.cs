﻿using System.Collections.Generic;
using Warden.Spawn.Configurations;
using Warden.Spawn.Hooks;

namespace Warden.Spawn.Watchers.Web
{
    public class WebWatcherSpawn : IWatcherSpawn
    {
        public string Name { get; protected set; }
        public string Group { get; protected set; }
        public IWatcherSpawnConfiguration Configuration { get; protected set; }
        public IEnumerable<IWatcherHookSpawnConfiguration> Hooks { get; protected set; }
    }
}