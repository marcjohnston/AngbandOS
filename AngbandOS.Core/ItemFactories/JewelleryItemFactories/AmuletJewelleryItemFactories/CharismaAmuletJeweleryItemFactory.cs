// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CharismaAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private CharismaAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Charisma";
    protected override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";
    protected override string? BreaksDuringEnchantmentProbabilityExpression => "1/2";
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        item.BonusCharisma = 1 + item.GetBonusValue(5, level);
        if (power < 0)
        {
            item.IsBroken = true;
            item.IsCursed = true;
            item.BonusCharisma = 0 - item.BonusCharisma;
        }
    }
    public override bool Cha => true;
    public override int Cost => 500;
    public override bool HideType => true;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 3;

}
