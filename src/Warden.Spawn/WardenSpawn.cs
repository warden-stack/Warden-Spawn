﻿using Warden.Core;
using Warden.Spawn.Configurations;

namespace Warden.Spawn
{
    public class WardenSpawn : IWardenSpawn
    {
        private readonly IWardenSpawnConfigurationInstance _configuration;

        public WardenSpawn(IWardenSpawnConfigurationInstance configuration)
        {
            _configuration = configuration;
        }

        public IWarden Spawn()
        {
            var wardenConfiguration = WardenConfiguration
                .Create();

            foreach (var integration in _configuration.Integrations)
            {
                if (integration is EmptyIntegration)
                    continue;

                wardenConfiguration.AddIntegration(integration);
            }
            foreach (var watcherWithHooks in _configuration.Watchers)
            {
                wardenConfiguration.AddWatcher(watcherWithHooks.Watcher, watcherWithHooks.Hooks);
            }
            wardenConfiguration.SetHooks(_configuration.Hooks);
            wardenConfiguration.SetGlobalWatcherHooks(_configuration.GlobalWatcherHooks);
            wardenConfiguration.SetAggregatedWatcherHooks(_configuration.AggregatedWatcherHooks);

            return WardenInstance.Create(_configuration.WardenName, wardenConfiguration.Build());
        }
    }
}