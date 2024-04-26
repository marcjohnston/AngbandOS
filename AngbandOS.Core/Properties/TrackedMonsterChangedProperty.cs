// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Properties;

/// <summary>
/// Represents a property that is used to manually track when the tracked monster is updated.  This property is only used to flag a manual refresh for the tracked monster.
/// </summary>
[Serializable]
internal class TrackedMonsterChangedProperty : Property
{
    private TrackedMonsterChangedProperty(Game game) : base(game) { } // This object is a singleton.
    public new void SetChangedFlag() // We need to make the SetChangedFlag property public
    {
        base.SetChangedFlag();
    }
}
