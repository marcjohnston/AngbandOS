// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightRodItemFactory : ItemFactory
{
    private LightRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(MinusSignSymbol);
    public override string Name => "Light";
    protected override string? DescriptionSyntax => "$Flavor$ Rod~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Rod~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Rod~ of $Name$";
    public override int Cost => 500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 15;
    protected override (string, string, bool, int)? ZapBindingTuple => (nameof(LightBoltIdentifiedAndUsedScriptItemAndDirection), "9", true, 250);
    protected override string ItemClassBindingKey => nameof(RodsItemClass);

    protected override string? RechargeScriptBindingKey => nameof(RechargeRodScript);

    protected override string? EatMagicScriptBindingKey => nameof(RodEatMagicScript);

    /// <summary>
    /// Returns true, because rods are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;
    public override bool EasyKnow => true;
    public override int PackSort => 13;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
}
