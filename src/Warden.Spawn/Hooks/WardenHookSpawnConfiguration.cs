﻿namespace Warden.Spawn.Hooks
{
    public class WardenHookSpawnConfiguration : IWardenHookSpawnConfiguration
    {
        public WardenHookType Type { get; set; }
        public Condition Condition { get; set; }
        public string Use { get; set; }
        public object Configuration { get; set; }
    }
}