// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class JewelleryItem : Item
{
    public JewelleryItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int? GetBonusRealValue(int value)
    {
        if (BonusArmorClass < 0 || BonusToHit < 0 || BonusDamage < 0)
            return 0;

        return (BonusToHit + BonusDamage + BonusArmorClass) * 100;
    }

    public override int? GetTypeSpecificRealValue(int value)
    {
        return ComputeTypeSpecificRealValue(value);
    }
    public override bool IsStompable()
    {
        if (BonusDamage < 0 || BonusArmorClass < 0 || BonusToHit < 0 || TypeSpecificValue < 0)
        {
            return true;
        }
        return base.IsStompable();
    }
}