﻿namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class Configuration
{
    ///// <summary>
    ///// Represents the names of the stores that are available in the game.  These store names can any preconfigured Angband store, or a store with a matching
    ///// name from the Stores Repo.
    ///// </summary>
    //public string[]? StoreNames { get; set; } = default!;
    //public StoreConfiguration[]? StoresRepo { get; set; } = default!;

    /// <summary>
    /// Returns the number of log items that the message history is allowed to store.  A null value indicates that there is no limit.  The default value is 2048.
    /// </summary>
    public virtual int? MaxMessageLogLength => 2048;
}

//public class StoreConfiguration
//{
//    public string Name { get; set; } = default!;
//    public string[] StoreOwnerNames { get; set; } = default!;
//}

//public class StoreOwnerConfiguration
//{
//    public string Name { get; set; } = default!;
//    public int MaxCost { get; set; } = default!;
//    public int MinInflate { get; set; } = default!;
//    public string RaceName { get; set; } = default!;
//}