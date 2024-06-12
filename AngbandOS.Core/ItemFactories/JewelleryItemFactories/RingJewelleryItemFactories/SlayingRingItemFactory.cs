// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlayingRingItemFactory : RingItemFactory
{
    private SlayingRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Slaying";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (power == 0 && Game.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.BonusDamage = Game.DieRoll(7) + item.GetBonusValue(10, level);
        item.BonusHit = Game.DieRoll(7) + item.GetBonusValue(10, level);
        if (power < 0)
        {
            item.IsBroken = true;
            item.IsCursed = true;
            item.BonusHit = 0 - item.BonusHit;
            item.BonusDamage = 0 - item.BonusDamage;
        }
    }

    public override int Cost => 1000;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 2;
}
