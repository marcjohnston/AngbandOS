// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.GetItemProperties;

[Serializable]
internal class CanBeFiredBooleanGetItemProperty : GetItemProperty<bool>
{
    public CanBeFiredBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => "CanBeFired";
    public override bool Get(Item item)
    {
        RangedWeaponWieldSlot rangedWeaponInventorySlot = (RangedWeaponWieldSlot)Game.SingletonRepository.Get<WieldSlot>(nameof(RangedWeaponWieldSlot));
        WeightedRandom<int> weightedRandom = rangedWeaponInventorySlot.WeightedRandom;
        Item? rangedWeapon = Game.GetInventoryItem(weightedRandom.ChooseOrDefault());
        return rangedWeapon != null && item.IsAmmunitionFor(rangedWeapon);
    }
}

