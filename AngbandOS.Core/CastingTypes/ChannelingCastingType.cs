// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CastingTypes;

[Serializable]
internal class ChannelingCastingType : CastingType
{
    private ChannelingCastingType(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns true, because channeling casting allows the player to use mana instead of consuming the item.
    /// </summary>
    public override bool CanUseManaInsteadOfConsumingItem => true;
}