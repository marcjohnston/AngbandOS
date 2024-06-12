// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
/// <summary>
/// Represents jewellery items.  Amulets and rings are both armor classes.
/// </summary>
internal abstract class JewelleryItemFactory : ItemFactory
{
    public JewelleryItemFactory(Game game) : base(game) { }

    public override int? GetBonusRealValue(Item item, int value)
    {
        if (item.BonusArmorClass < 0 || item.BonusHit < 0 || item.BonusDamage < 0)
            return 0;

        return (item.BonusHit + item.BonusDamage + item.BonusArmorClass) * 100;
    }

    public override bool IsWorthless(Item item)
    {
        if (item.TypeSpecificValue < 0 || item.BonusArmorClass < 0 || item.BonusHit < 0 || item.BonusDamage < 0)
        {
            return true;
        }
        return false;
    }
}
