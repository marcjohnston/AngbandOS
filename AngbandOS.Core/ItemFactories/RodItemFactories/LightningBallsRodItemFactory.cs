// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightningBallsRodItemFactory : RodItemFactory
{
    private LightningBallsRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Lightning Balls";
    protected override string? DescriptionSyntax => "$Flavor$ Rod~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Rod~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Rod~ of $Name$";
    public override int Cost => 4000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 55;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (55, 1)
    };
    public override int Weight => 15;
    protected override (string, string, bool, int)? ZapBinderDetails => (nameof(ElectricityBall32r2IdentifiedAndUsedScriptItemAndDirection), "23", true, 250);
}
