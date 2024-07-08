// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FrostBoltsRodItemFactory : ItemFactory
{
    private FrostBoltsRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Frost Bolts";
    protected override string? DescriptionSyntax => "$Flavor$ Rod~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Rod~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Rod~ of $Name$";
    public override int Cost => 2500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 25;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (25, 1)
    };
    public override int Weight => 15;
    protected override (string, string, bool, int)? ZapBinderDetails => (nameof(ColdBolt5d8IdentifiedAndUsedScriptItemAndDirection), "13", true, 250);
    protected override string ItemClassName => nameof(RodsItemClass);

    protected override string? RechargeScriptName => nameof(RechargeRodScript);

    protected override string? EatMagicScriptName => nameof(RodEatMagicScript);

    /// <summary>
    /// Returns true, because rods are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;
    public override bool EasyKnow => true;
    public override int PackSort => 13;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
}
