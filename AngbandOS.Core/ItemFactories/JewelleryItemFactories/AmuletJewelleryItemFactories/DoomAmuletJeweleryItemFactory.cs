// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DoomAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private DoomAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "DOOM";
    protected override string? DescriptionSyntax => "& $Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Amulet~ of $Name$";
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.IdentBroken = true;
        item.IdentCursed = true;
        item.TypeSpecificValue = 0 - (Game.DieRoll(5) + item.GetBonusValue(5, level));
        item.BonusArmorClass = 0 - (Game.DieRoll(5) + item.GetBonusValue(5, level));
    }
    public override bool Cha => true;
    public override bool Con => true;
    public override bool Cursed => true;
    public override bool Dex => true;
    public override bool HideType => true;
    public override bool Int => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int InitialTypeSpecificValue => -5;
    public override bool Str => true;
    public override int Weight => 3;
    public override bool Wis => true;
}
