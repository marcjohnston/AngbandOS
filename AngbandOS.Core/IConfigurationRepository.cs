// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents the interface an object needs to implement for it to participate in a ConfigurationRepository.
/// </summary>
internal interface IConfigurationRepository
{

    /// <summary>
    /// Returns true, if the configuration object should be excluded from the repository; false, if the configuration object should be added to the repository.
    /// When the configuration repository encounters an excluded singleton object during the load phase; the configuration repository will ignore it.
    /// </summary>
    bool ExcludeFromRepository { get; }

    /// <summary>
    /// Performs any post-load operations.  This phase of the configuration allows objects to reference other objects that may be loaded later.  Example: A town specifies the stores that are
    /// found in the town.  A town does this by specifying the name of the store.  The town and store objects are loaded during the Load() phase.  This is where the objects are created but
    /// the town has a property that returns the actual store objects and this Loaded() phase allows the town to find those stores by name.
    /// </summary>
    void Loaded();
}