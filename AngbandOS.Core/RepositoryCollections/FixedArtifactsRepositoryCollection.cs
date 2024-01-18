// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class FixedArtifactsRepositoryCollection : KeyedDictionaryRepositoryCollection<string, FixedArtifact>
{
    public FixedArtifactsRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    // Allow the fixed artifacts to load.  This is needed because they are all based on other items.
    public override void Loaded()
    {
        foreach (FixedArtifact fixedArtifact in this)
        {
            fixedArtifact.Loaded();
        }
    }
}