// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FlamesRingItemFactory : RingItemFactory
{
    private FlamesRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string? ActivationName => nameof(BallOfFire50r2AndResistFire1d20p20Activation);
    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Flames";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.BonusArmorClass = 5 + Game.DieRoll(5) + item.GetBonusValue(10, level);
    }
    public override int Cost => 1000;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override bool ResFire => true;
    public override int BonusArmorClass => 15;
    public override int Weight => 2;
}
