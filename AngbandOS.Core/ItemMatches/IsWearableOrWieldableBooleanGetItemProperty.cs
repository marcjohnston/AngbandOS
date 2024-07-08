// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemMatches;

[Serializable]
internal class IsWearableOrWieldableBooleanGetItemProperty : GetItemProperty<bool>
{
    public IsWearableOrWieldableBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => "IsWearableOrWieldable";
    public override bool Get(Item item)
    {
        return item.Factory.IsWearableOrWieldable;
    }
}

