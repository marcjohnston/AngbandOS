// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class FlaggedActionsRepositoryCollection : DictionaryRepositoryCollection<string, FlaggedAction>
{
    public FlaggedActionsRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    // Allow the flagged actions to load.  This is needed because some of them are grouped on other flagged actions.
    public override void Loaded()
    {
        foreach (FlaggedAction flaggedAction in this)
        {
            flaggedAction.Bind();
        }
    }

}