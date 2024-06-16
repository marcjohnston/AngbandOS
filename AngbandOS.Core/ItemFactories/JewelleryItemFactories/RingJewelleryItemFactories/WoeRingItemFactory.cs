// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoeRingItemFactory : RingItemFactory
{
    private WoeRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override bool IsBroken => true;
    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Woe";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        item.IsBroken = true;
        item.IsCursed = true;
        item.BonusArmorClass = 0 - (5 + item.GetBonusValue(10, level));
        item.BonusCharisma = 0 - (1 + item.GetBonusValue(5, level));
        item.BonusWisdom = item.BonusCharisma;
    }
    public override bool Cha => true;
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int InitialBonusWisdom => -5;
    public override bool Teleport => true;
    public override int Weight => 2;
    public override bool Wis => true;
}
