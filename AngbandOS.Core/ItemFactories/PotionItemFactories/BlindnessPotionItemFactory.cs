// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BlindnessPotionItemFactory : ItemFactory
{
    private BlindnessPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Blindness";
    protected override string? DescriptionSyntax => "$Flavor$ Potion~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Potion~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Potion~ of $Name$";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int Weight => 4;

    protected override (string, string?, int)? PotionBinderDetails => (nameof(Blindness1d100p100Script), nameof(DarkProjectileUnfriendlyScript), 20);
 
    /// <summary>
    /// Returns true, because potions are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true; // TODO: This should be a built-in function depending on what the potion does

    protected override string ItemClassName => nameof(PotionsItemClass);

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    protected override string BreakageChanceProbabilityExpression => "100/100";
    public override bool EasyKnow => true;
    public override int PackSort => 11;

    /// <summary>
    /// Returns 20 gold because unknown potions are not worth much.
    /// </summary>
    public override int BaseValue => 20;

    /// <summary>
    /// Returns true because potions are susceptible to freezing.
    /// </summary>
    public override bool HatesCold => true;
    public override ColorEnum Color => ColorEnum.Blue;
}
